using System.IO.Compression;

namespace Minesharp.Nbt.Writer;

public class CompressedTagWriter : TagWriter
{
    public CompressedTagWriter(Stream stream) : base(new GZipStream(stream, CompressionMode.Compress))
    {
    }
}