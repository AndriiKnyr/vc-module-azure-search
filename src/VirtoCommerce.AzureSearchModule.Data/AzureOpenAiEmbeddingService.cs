using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenAI.Embeddings;
using System.ClientModel;
using VirtoCommerce.AzureSearchModule.Data.Extensions;
using VirtoCommerce.Platform.Core.Settings;

namespace VirtoCommerce.AzureSearchModule.Data
{
    public class AzureOpenAiEmbeddingService : IEmbeddingService
    {
        private readonly AzureOpenAIClient _client;
        private readonly ISettingsManager _settingsManager;
        private readonly ILogger<AzureOpenAiEmbeddingService> _logger;

        public AzureOpenAiEmbeddingService(
            IOptions<AzureSearchOptions> azureSearchOptions,
            ISettingsManager settingsManager,
            ILogger<AzureOpenAiEmbeddingService> logger)
        {
            if (azureSearchOptions == null)
            {
                throw new ArgumentNullException(nameof(azureSearchOptions));
            }

            _settingsManager = settingsManager ?? throw new ArgumentNullException(nameof(settingsManager));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            var options = azureSearchOptions.Value;
            var endpoint = options.AzureOpenAI?.Endpoint;
            var key = options.AzureOpenAI?.Key;

            if (string.IsNullOrWhiteSpace(endpoint))
            {
                throw new InvalidOperationException("Azure OpenAI endpoint is not configured.");
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new InvalidOperationException("Azure OpenAI key is not configured.");
            }

            _client = new AzureOpenAIClient(new Uri(endpoint), new ApiKeyCredential(key));
        }

        public async Task<ReadOnlyMemory<float>> GetEmbeddingAsync(string text, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("Text must be provided.", nameof(text));
            }

            var embeddings = await GetEmbeddingsAsync(new[] { text }, cancellationToken).ConfigureAwait(false);
            return embeddings[0];
        }

        public async Task<IReadOnlyList<ReadOnlyMemory<float>>> GetEmbeddingsAsync(IEnumerable<string> texts, CancellationToken cancellationToken = default)
        {
            if (texts == null)
            {
                throw new ArgumentNullException(nameof(texts));
            }

            var inputs = texts.Where(text => !string.IsNullOrWhiteSpace(text)).ToList();
            if (inputs.Count == 0)
            {
                return Array.Empty<ReadOnlyMemory<float>>();
            }

            var deployment = _settingsManager.GetSemanticEmbeddingDeployment();
            var model = _settingsManager.GetSemanticEmbeddingModel();
            var deploymentOrModel = !string.IsNullOrWhiteSpace(deployment) ? deployment : model;
            if (string.IsNullOrWhiteSpace(deploymentOrModel))
            {
                throw new InvalidOperationException("Azure OpenAI embedding deployment is not configured.");
            }

            try
            {
                var embeddingClient = _client.GetEmbeddingClient(deploymentOrModel);
                var response = await embeddingClient.GenerateEmbeddingsAsync(inputs, cancellationToken: cancellationToken).ConfigureAwait(false);
                return response.Value.Select(item => item.ToFloats()).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to generate embeddings using deployment {Deployment}.", deploymentOrModel);
                throw;
            }
        }
    }
}
