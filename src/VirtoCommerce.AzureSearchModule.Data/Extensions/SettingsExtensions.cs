using System;
using VirtoCommerce.Platform.Core.Settings;

namespace VirtoCommerce.AzureSearchModule.Data.Extensions
{
    public static class SettingsExtensions
    {
        public static string GetTokenFilterName(this ISettingsManager settingsManager)
        {
            return settingsManager.GetValue<string>(ModuleConstants.Settings.Indexing.TokenFilter);
        }

        public static int GetMinGram(this ISettingsManager settingsManager)
        {
            return settingsManager.GetValue<int>(ModuleConstants.Settings.Indexing.MinGram);
        }

        public static int GetMaxGram(this ISettingsManager settingsManager)
        {
            return settingsManager.GetValue<int>(ModuleConstants.Settings.Indexing.MaxGram);
        }

        public static bool GetSemanticEnabled(this ISettingsManager settingsManager)
        {
            return settingsManager.GetValue<bool>(ModuleConstants.Settings.Semantic.Enabled);
        }

        public static string GetSemanticPrimaryLanguage(this ISettingsManager settingsManager)
        {
            return settingsManager.GetValue<string>(ModuleConstants.Settings.Semantic.PrimaryLanguage);
        }

        public static string GetSemanticEmbeddingModel(this ISettingsManager settingsManager)
        {
            return settingsManager.GetValue<string>(ModuleConstants.Settings.Vectorizer.EmbeddingModel);
        }

        public static string GetSemanticEmbeddingDeployment(this ISettingsManager settingsManager)
        {
            return settingsManager.GetValue<string>(ModuleConstants.Settings.Vectorizer.EmbeddingDeployment);
        }

        public static int GetSemanticEmbeddingDimensions(this ISettingsManager settingsManager)
        {
            var model = settingsManager.GetSemanticEmbeddingModel();

            if (string.Equals(model, "text-embedding-3-large", StringComparison.OrdinalIgnoreCase))
            {
                return 3072;
            }

            if (string.Equals(model, "text-embedding-3-small", StringComparison.OrdinalIgnoreCase))
            {
                return 1536;
            }

            if (string.Equals(model, "text-embedding-ada-002", StringComparison.OrdinalIgnoreCase))
            {
                return 1536;
            }

            return settingsManager.GetValue<int>(ModuleConstants.Settings.Vectorizer.EmbeddingDimensions);
        }

        public static int GetSemanticEmbeddingBatchSize(this ISettingsManager settingsManager)
        {
            return settingsManager.GetValue<int>(ModuleConstants.Settings.Vectorizer.EmbeddingBatchSize);
        }

        public static string GetSemanticVectorizerEmbeddingModel(this ISettingsManager settingsManager)
        {
            return settingsManager.GetSemanticEmbeddingModel();
        }

        public static string GetSemanticVectorizerEmbeddingDeployment(this ISettingsManager settingsManager)
        {
            return settingsManager.GetSemanticEmbeddingDeployment();
        }

        public static int GetSemanticVectorizerEmbeddingDimensions(this ISettingsManager settingsManager)
        {
            return settingsManager.GetSemanticEmbeddingDimensions();
        }

        public static bool GetAgenticEnabled(this ISettingsManager settingsManager)
        {
            return settingsManager.GetValue<bool>(ModuleConstants.Settings.Agentic.Enabled);
        }

        public static string GetAgenticKnowledgeBaseModel(this ISettingsManager settingsManager)
        {
            var model = settingsManager.GetValue<string>(ModuleConstants.Settings.Agentic.KnowledgeBaseModel);

            return string.IsNullOrWhiteSpace(model)
                ? settingsManager.GetSemanticVectorizerEmbeddingModel()
                : model;
        }

        public static string GetAgenticKnowledgeBaseDeployment(this ISettingsManager settingsManager)
        {
            var deployment = settingsManager.GetValue<string>(ModuleConstants.Settings.Agentic.KnowledgeBaseDeployment);

            return string.IsNullOrWhiteSpace(deployment)
                ? settingsManager.GetSemanticVectorizerEmbeddingDeployment()
                : deployment;
        }
    }
}
