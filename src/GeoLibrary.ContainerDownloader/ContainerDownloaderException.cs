using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace GeoLibrary.ContainerDownloader;

public class ContainerDownloaderException : ApplicationException
{
    [DebuggerStepThrough]
    public ContainerDownloaderException()
    {
    }

    [DebuggerStepThrough]
    public ContainerDownloaderException(string message)
        : base(message)
    {
    }

    [DebuggerStepThrough]
    public ContainerDownloaderException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    [DebuggerStepThrough]
    protected ContainerDownloaderException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
