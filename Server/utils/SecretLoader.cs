using System.IO;
using static CitizenFX.Core.Native.API;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace core_ztzbx.Server
{
    public class SecretKey
    {
        public string secret { get; set; }
    }

    public class YamlConfig
    {
        public SecretKey data;
        public YamlConfig(string filePath)
        {
            string contents = File.ReadAllText($"{GetResourcePath(GetCurrentResourceName())}/{filePath}");
            var deserializer = new DeserializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .Build();
            data = deserializer.Deserialize<SecretKey>(contents);
        }
    }
}