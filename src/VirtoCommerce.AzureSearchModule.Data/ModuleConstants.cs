using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using VirtoCommerce.Platform.Core.Settings;

namespace VirtoCommerce.AzureSearchModule.Data
{
    [ExcludeFromCodeCoverage]
    public static class ModuleConstants
    {
        public const string ProviderName = "AzureSearch";

        public const string NGramFilterName = "custom_ngram";
        public const string EdgeNGramFilterName = "custom_edge_ngram";

        public static class Settings
        {
            public static class Indexing
            {
                public static SettingDescriptor TokenFilter { get; } = new()
                {
                    Name = "VirtoCommerce.Search.AzureSearch.TokenFilter",
                    GroupName = "Search|Azure Search|General",
                    ValueType = SettingValueType.ShortText,
                    DefaultValue = EdgeNGramFilterName,
                    AllowedValues = new object[] { EdgeNGramFilterName, NGramFilterName },
                };

                public static SettingDescriptor MinGram { get; } = new()
                {
                    Name = "VirtoCommerce.Search.AzureSearch.NGramTokenFilter.MinGram",
                    GroupName = "Search|Azure Search|General",
                    ValueType = SettingValueType.Integer,
                    DefaultValue = 1,
                };

                public static SettingDescriptor MaxGram { get; } = new()
                {
                    Name = "VirtoCommerce.Search.AzureSearch.NGramTokenFilter.MaxGram",
                    GroupName = "Search|Azure Search|General",
                    ValueType = SettingValueType.Integer,
                    DefaultValue = 20,
                };

                public static IEnumerable<SettingDescriptor> AllIndexingSettings
                {
                    get
                    {
                        yield return TokenFilter;
                        yield return MinGram;
                        yield return MaxGram;
                    }
                }
            }

            public static class Semantic
            {
                public static SettingDescriptor Enabled { get; } = new()
                {
                    Name = "VirtoCommerce.Search.AzureSearch.Semantic.Enabled",
                    GroupName = "Search|Azure Search|Semantic",
                    ValueType = SettingValueType.Boolean,
                    DefaultValue = false,
                };

                public static SettingDescriptor PrimaryLanguage { get; } = new()
                {
                    Name = "VirtoCommerce.Search.AzureSearch.Semantic.PrimaryLanguage",
                    GroupName = "Search|Azure Search|Semantic",
                    ValueType = SettingValueType.ShortText,
                    DefaultValue = "en-US",
                };

                public static IEnumerable<SettingDescriptor> AllSemanticSettings
                {
                    get
                    {
                        yield return Enabled;
                        yield return PrimaryLanguage;
                    }
                }
            }

            public static class Vectorizer
            {
                public static SettingDescriptor EmbeddingModel { get; } = new()
                {
                    Name = "VirtoCommerce.Search.AzureSearch.Semantic.Vectorizer.EmbeddingModel",
                    GroupName = "Search|Azure Search|Vectorizer",
                    ValueType = SettingValueType.ShortText,
                    DefaultValue = "text-embedding-3-large",
                    AllowedValues = new object[]
                    {
                        "text-embedding-3-large",
                        "text-embedding-3-small",
                        "text-embedding-ada-002",
                    },
                };

                public static SettingDescriptor EmbeddingDeployment { get; } = new()
                {
                    Name = "VirtoCommerce.Search.AzureSearch.Semantic.Vectorizer.EmbeddingDeployment",
                    GroupName = "Search|Azure Search|Vectorizer",
                    ValueType = SettingValueType.ShortText,
                    DefaultValue = "text-embedding-3-large",
                };

                public static SettingDescriptor EmbeddingDimensions { get; } = new()
                {
                    Name = "VirtoCommerce.Search.AzureSearch.Semantic.Vectorizer.EmbeddingDimensions",
                    GroupName = "Search|Azure Search|Vectorizer",
                    ValueType = SettingValueType.Integer,
                    DefaultValue = 3072,
                };

                public static SettingDescriptor EmbeddingBatchSize { get; } = new()
                {
                    Name = "VirtoCommerce.Search.AzureSearch.Semantic.Vectorizer.EmbeddingBatchSize",
                    GroupName = "Search|Azure Search|Vectorizer",
                    ValueType = SettingValueType.Integer,
                    DefaultValue = 16,
                };

                public static IEnumerable<SettingDescriptor> AllVectorizerSettings
                {
                    get
                    {
                        yield return EmbeddingModel;
                        yield return EmbeddingDeployment;
                        yield return EmbeddingDimensions;
                        yield return EmbeddingBatchSize;
                    }
                }
            }

            public static class Agentic
            {
                public static SettingDescriptor Enabled { get; } = new()
                {
                    Name = "VirtoCommerce.Search.AzureSearch.Agentic.Enabled",
                    GroupName = "Search|Azure Search|Agentic",
                    ValueType = SettingValueType.Boolean,
                    DefaultValue = false,
                };

                public static SettingDescriptor KnowledgeBaseDescription { get; } = new()
                {
                    Name = "VirtoCommerce.Search.AzureSearch.Agentic.KnowledgeBase.Description",
                    GroupName = "Search|Azure Search|Agentic",
                    ValueType = SettingValueType.ShortText,
                    DefaultValue = string.Empty,
                };

                public static SettingDescriptor KnowledgeBaseRetrievalInstructions { get; } = new()
                {
                    Name = "VirtoCommerce.Search.AzureSearch.Agentic.KnowledgeBase.RetrievalInstructions",
                    GroupName = "Search|Azure Search|Agentic",
                    ValueType = SettingValueType.ShortText,
                    DefaultValue = "E-commerce catalog assistant. Prioritize retrieval by SKU/code, product name, brand, category and localized description fields. If a SKU is present, treat it as an exact match. Prefer active/in-stock items when available. Ensure retrieved items include key identifiers and product URL when present.",
                };

                public static SettingDescriptor KnowledgeBaseRetrievalReasoningEffort { get; } = new()
                {
                    Name = "VirtoCommerce.Search.AzureSearch.Agentic.KnowledgeBase.RetrievalReasoningEffort",
                    GroupName = "Search|Azure Search|Agentic",
                    ValueType = SettingValueType.ShortText,
                    DefaultValue = "minimal",
                    AllowedValues = new object[] { "minimal", "low", "medium" },
                };

                public static SettingDescriptor KnowledgeBaseModel { get; } = new()
                {
                    Name = "VirtoCommerce.Search.AzureSearch.Agentic.Model",
                    GroupName = "Search|Azure Search|Agentic",
                    ValueType = SettingValueType.ShortText,
                    DefaultValue = string.Empty,
                };

                public static SettingDescriptor KnowledgeBaseDeployment { get; } = new()
                {
                    Name = "VirtoCommerce.Search.AzureSearch.Agentic.Deployment",
                    GroupName = "Search|Azure Search|Agentic",
                    ValueType = SettingValueType.ShortText,
                    DefaultValue = string.Empty,
                };

                public static IEnumerable<SettingDescriptor> AllAgenticSettings
                {
                    get
                    {
                        yield return Enabled;
                        yield return KnowledgeBaseDescription;
                        yield return KnowledgeBaseModel;
                        yield return KnowledgeBaseDeployment;
                        yield return KnowledgeBaseRetrievalInstructions;
                        yield return KnowledgeBaseRetrievalReasoningEffort;
                    }
                }
            }

            public static IEnumerable<SettingDescriptor> AllSettings
            {
                get
                {
                    foreach (var setting in Indexing.AllIndexingSettings)
                    {
                        yield return setting;
                    }

                    foreach (var setting in Semantic.AllSemanticSettings)
                    {
                        yield return setting;
                    }

                    foreach (var setting in Vectorizer.AllVectorizerSettings)
                    {
                        yield return setting;
                    }

                    foreach (var setting in Agentic.AllAgenticSettings)
                    {
                        yield return setting;
                    }
                }
            }
        }
    }
}
