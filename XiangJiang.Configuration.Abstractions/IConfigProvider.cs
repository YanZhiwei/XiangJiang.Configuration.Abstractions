using System;

namespace XiangJiang.Configuration.Abstractions
{
    /// <summary>
    ///     配置服务接口
    /// </summary>
    public interface IConfigProvider
    {
        #region Methods

        /// <summary>
        ///     根据名称获取配置
        /// </summary>
        /// <param name="name">配置名称</param>
        /// <param name="pathExtrasCondition">路径额外条件</param>
        /// <returns>配置内容</returns>
        string GetConfig(string name, Func<string> pathExtrasCondition = null);

        /// <summary>
        ///     保存配置
        /// </summary>
        /// <param name="name">配置名称</param>
        /// <param name="content">配置内容</param>
        /// <param name="pathExtrasCondition">路径额外条件</param>
        void SaveConfig(string name, string content, Func<string> pathExtrasCondition = null);

        /// <summary>
        ///     获取配置索引
        /// </summary>
        /// <param name="index">索引名称</param>
        /// <param name="pathExtrasCondition">路径额外条件</param>
        /// <returns>索引</returns>
        string GetClusteredIndex<T>(string index = null, Func<string> pathExtrasCondition = null) where T : class, new();

        #endregion Methods
    }
}