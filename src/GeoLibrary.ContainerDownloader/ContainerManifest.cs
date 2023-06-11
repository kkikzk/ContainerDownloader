using System.Text.Json.Serialization;

namespace GeoLibrary.ContainerDownloader;

public readonly record struct ContainerManifest
{
    public readonly record struct ConfigData
    {
        [JsonPropertyName("mediaType")]
        public string MediaType { get; }
        [JsonPropertyName("digest")]
        public string Digest { get; }
        [JsonPropertyName("size")]
        public int Size { get; }

        [JsonConstructor]
        public ConfigData(string mediaType, string digest, int size) =>
            (MediaType, Digest, Size) = (mediaType, digest, size);
    }

    public readonly record struct Layer
    {
        [JsonPropertyName("mediaType")]
        public string MediaType { get; }
        [JsonPropertyName("digest")]
        public string Digest { get; }
        [JsonPropertyName("size")]
        public int Size { get; }

        [JsonConstructor]
        public Layer(string mediaType, string digest, int size) =>
            (MediaType, Digest, Size) = (mediaType, digest, size);
    }

    [JsonPropertyName("schemaVersion")]
    public int SchemaVersion { get; }
    [JsonPropertyName("mediaType")]
    public string MediaType { get; }
    [JsonPropertyName("config")]
    public ConfigData Config { get; }
    [JsonPropertyName("layers")]
    public Layer[] Layers { get; }

    [JsonConstructor]
    public ContainerManifest(int schemaVersion, string mediaType, ConfigData config, Layer[] layers) =>
      (SchemaVersion, MediaType, Config, Layers) = (schemaVersion, mediaType, config, layers);
}
