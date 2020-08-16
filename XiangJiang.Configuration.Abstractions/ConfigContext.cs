using System;
using XiangJiang.Infrastructure.Abstractions;

namespace XiangJiang.Configuration.Abstractions
{
    public class ConfigContext
    {
        /// <summary>
        ///     配置服务
        /// </summary>
        protected readonly IConfigProvider ConfigService;

        protected readonly ISerializer Serializer;

        public ConfigContext(IConfigProvider configService, ISerializer serializer)
        {
            ConfigService = configService ?? throw new ArgumentNullException(nameof(configService));
            Serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
        }

        public ConfigContext()
        {
        }

        public virtual void Save<T>(T configGroup, string index = null, Func<string> pathExtrasCondition = null)
            where T : class, new()
        {
            var clusteredIndex = ConfigProviderHelper.CreateClusteredIndex<T>(index);
            ConfigService.SaveConfig(clusteredIndex, Serializer.Serialize(configGroup), pathExtrasCondition);
        }

        public virtual T Get<T>(string index = null, Func<string> pathExtrasCondition = null) where T : class, new()
        {
            var clusteredIndex = ConfigProviderHelper.CreateClusteredIndex<T>(index);
            var context = ConfigService.GetConfig(clusteredIndex, pathExtrasCondition);

            return string.IsNullOrEmpty(context) ? null : Serializer.Deserialize<T>(context);
        }

        public virtual string GetClusteredIndex<T>(string index = null, Func<string> pathExtrasCondition = null)
            where T : class, new()
        {
            return ConfigService.GetClusteredIndex<T>(index, pathExtrasCondition);
        }
    }
}