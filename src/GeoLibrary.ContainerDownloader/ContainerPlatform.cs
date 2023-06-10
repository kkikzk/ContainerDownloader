using System.Diagnostics;

namespace GeoLibrary.ContainerDownloader;

public readonly record struct ContainerPlatform
{
    public string Architecture { get; }
    public string Os { get; }
    public string Variant { get; }

    [DebuggerStepThrough]
    public ContainerPlatform(string architecture, string os) =>
            (Architecture, Os, Variant) = (architecture, os, string.Empty);

    [DebuggerStepThrough]
    public ContainerPlatform(string architecture, string os, string variant) =>
        (Architecture, Os, Variant) = (architecture, os, variant);
}
