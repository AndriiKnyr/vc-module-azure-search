using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace VirtoCommerce.AzureSearchModule.Data
{
    public interface IEmbeddingService
    {
        Task<ReadOnlyMemory<float>> GetEmbeddingAsync(string text, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<ReadOnlyMemory<float>>> GetEmbeddingsAsync(IEnumerable<string> texts, CancellationToken cancellationToken = default);
    }
}
