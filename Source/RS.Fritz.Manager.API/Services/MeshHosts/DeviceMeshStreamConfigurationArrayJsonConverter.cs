using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using RS.Fritz.Manager.API.Services.MeshHosts.Entities;

namespace RS.Fritz.Manager.API.Services.MeshHosts;

internal sealed class DeviceMeshStreamConfigurationArrayJsonConverter : JsonConverter<DeviceMeshStreamConfiguration[]>
{
    public override bool CanConvert(Type typeToConvert) =>
        typeof(DeviceMeshStreamConfiguration[]).IsAssignableFrom(typeToConvert);

    public override DeviceMeshStreamConfiguration[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
            throw new JsonException();

        var deviceMeshStreamConfigurations = new Collection<DeviceMeshStreamConfiguration>();

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndArray)
                return deviceMeshStreamConfigurations.ToArray();

            if (reader.TokenType != JsonTokenType.StartArray)
                throw new JsonException();

            _ = reader.Read();

            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException();

            string channelWidth = reader.GetString()!;

            _ = reader.Read();

            if (reader.TokenType != JsonTokenType.Number)
                throw new JsonException();

            int supportedStreamCount = reader.GetInt32();

            _ = reader.Read();

            if (reader.TokenType != JsonTokenType.EndArray)
                throw new JsonException();

            deviceMeshStreamConfigurations.Add(new DeviceMeshStreamConfiguration(channelWidth, supportedStreamCount));
        }

        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, DeviceMeshStreamConfiguration[] value, JsonSerializerOptions options)
    {
        throw new NotSupportedException();
    }
}