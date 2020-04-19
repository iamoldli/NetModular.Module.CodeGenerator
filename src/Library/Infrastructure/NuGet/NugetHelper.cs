using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using NetModular.Lib.Config.Abstractions;
using NetModular.Lib.Utils.Core.Attributes;
using Newtonsoft.Json;

namespace NetModular.Module.CodeGenerator.Infrastructure.NuGet
{
    /// <summary>
    /// NuGet帮助类
    /// </summary>
    [Singleton]
    public class NuGetHelper
    {
        private const string QueryUrl = "https://azuresearch-usnc.nuget.org/query?q={0}&take=1";
        private readonly Dictionary<string, PropertyInfo> _infos = new Dictionary<string, PropertyInfo>();
        private readonly HttpClient _client;
        private NuGetPackageVersions _versions;
        private DateTime _lastSearchTime = DateTime.Now;

        public NuGetHelper(IConfigProvider configProvider, IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient();
            var config = configProvider.Get<CodeGeneratorConfig>();
            var properties = typeof(NuGetPackageVersions).GetProperties();
            foreach (var propertyInfo in properties)
            {
                var name = $"{config.Prefix}.{propertyInfo.Name.Replace("_", ".")}";
                _infos.Add(name, propertyInfo);
            }
        }

        /// <summary>
        /// 获取最新包版本信息
        /// </summary>
        /// <returns></returns>
        public NuGetPackageVersions GetVersions()
        {
            //加个缓存机制，2小时
            if (_lastSearchTime.AddHours(2) > DateTime.Now && _versions != null)
                return _versions;

            _versions = new NuGetPackageVersions();
            var tasks = new Dictionary<PropertyInfo, Task<string>>();
            foreach (var info in _infos)
            {
                tasks.Add(info.Value, GetVersion(info.Key));
            }

            Task.WaitAll(tasks.Values.ToArray());

            foreach (var task in tasks)
            {
                task.Key.SetValue(_versions, task.Value.Result);
            }

            return _versions;
        }

        /// <summary>
        /// 查询指定包ID的最新版本号
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns></returns>
        public async Task<string> GetVersion(string packageId)
        {
            var url = string.Format(QueryUrl, packageId);
            var jsonStr = await _client.GetStringAsync(url);
            if (jsonStr.NotNull())
            {
                var model = JsonConvert.DeserializeAnonymousType(jsonStr, new
                {
                    data = new[]
                    {
                        new
                        {
                            Version = ""
                        }
                    }
                });

                if (model != null && model.data != null && model.data.Length > 0)
                {
                    return model.data[0].Version;
                }
            }

            return "";
        }
    }
}
