using System.IO.Compression;

namespace Minesharp.Nbt.Reader;

public class CompressedTagReader : TagReader
{
    public CompressedTagReader(Stream stream) : base(new GZipStream(stream, CompressionMode.Decompress))
    {
    }
}