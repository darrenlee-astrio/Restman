using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Restman.Winform.Common.Helpers;

public static class YamlHelper
{
    private static readonly ISerializer _serializer;
    private static readonly IDeserializer _deserializer;

    static YamlHelper()
    {
        var namingConvention = HyphenatedNamingConvention.Instance;

        _serializer = new SerializerBuilder()
            .WithNamingConvention(namingConvention)
            .Build();

        _deserializer = new DeserializerBuilder()
            .WithNamingConvention(namingConvention)
            .Build();
    }

    public static string Serialize<T>(T model)
    {
        if (model is null)
        {
            throw new ArgumentNullException(nameof(model));
        }

        return _serializer.Serialize(model);
    }

    public static T Deserialize<T>(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        var configuration = File.ReadAllText(path);
        return _deserializer.Deserialize<T>(configuration);
    }
}
