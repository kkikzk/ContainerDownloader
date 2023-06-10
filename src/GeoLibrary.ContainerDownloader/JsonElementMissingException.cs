using System;
using System.Runtime.Serialization;

namespace GeoLibrary.ContainerDownloader;

public class JsonElementMissingException : ContainerDownloaderException
{
    public string ElementName { get; } = string.Empty;

    public JsonElementMissingException()
    {
    }

    public JsonElementMissingException(string elementName)
        : base($"Json element does not exist. [element name={elementName}]")
    {
        ElementName = elementName;
    }

    public JsonElementMissingException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    protected JsonElementMissingException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
