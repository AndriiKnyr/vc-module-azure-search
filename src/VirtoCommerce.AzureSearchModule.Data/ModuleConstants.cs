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

                public static IEnumerable<SettingDescriptor> AllVectorizerSettings
                {
                    get
                    {
                        yield return EmbeddingModel;
                        yield return EmbeddingDeployment;
                        yield return EmbeddingDimensions;
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

                public static IEnumerable<SettingDescriptor> AllAgenticSettings
                {
                    get
                    {
                        yield return Enabled;
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
