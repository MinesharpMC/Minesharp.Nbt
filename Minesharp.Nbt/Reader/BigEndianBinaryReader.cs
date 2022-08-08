using System.Text;

namespace Minesharp.Nbt.Reader;

public class BigEndianBinaryReader : IDisposable
{
    private readonly BinaryReader reader;

    public BigEndianBinaryReader(Stream stream)
    {
        this.reader = new BinaryReader(stream);
    }

    public sbyte ReadByte()
    {
        return reader.ReadSByte();
    }
    
    public int ReadInt()
    {
        var bytes = reader.ReadBytes(4);
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }

        return BitConverter.ToInt32(bytes);
    }

    public long ReadLong()
    {
        var bytes = reader.ReadBytes(8);
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }

        return BitConverter.ToInt64(bytes);
    }

    public short ReadShort()
    {
        var bytes = reader.ReadBytes(2);
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }

        return BitConverter.ToInt16(bytes);
    }

    public ushort ReadUnsignedShort()
    {
        var bytes = reader.ReadBytes(2);
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }

        return BitConverter.ToUInt16(bytes);
    }

    public double ReadDouble()
    {
        var bytes = reader.ReadBytes(8);
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }

        return BitConverter.ToDouble(bytes);
    }
    
    public float ReadFloat()
    {
        var bytes = reader.ReadBytes(4);
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }

        return BitConverter.ToSingle(bytes);
    }

    public string ReadString()
    {
        var length = ReadUnsignedShort();
        var bytes = reader.ReadBytes(length);

        return Encoding.UTF8.GetString(bytes);
    }
    
    public void Dispose()
    {
        reader.Dispose();
    }
}