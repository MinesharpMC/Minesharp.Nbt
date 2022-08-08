using System.Text;

namespace Minesharp.Nbt.Writer;

public class BigEndianBinaryWriter : IDisposable
{
    private readonly BinaryWriter writer;

    public BigEndianBinaryWriter(Stream stream)
    {
        this.writer = new BinaryWriter(stream);
    }
    
    public void WriteInt(int value)
    {
        var bytes = BitConverter.GetBytes(value);
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }
        writer.Write(bytes);
    }

    public void WriteByte(sbyte value)
    {
        writer.Write(value);
    }

    public void WriteString(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);

        WriteUnsignedShort((ushort)bytes.Length);
        writer.Write(bytes);
    }

    public void WriteShort(short value)
    {
        var bytes = BitConverter.GetBytes(value);
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }
        writer.Write(bytes);
    }
    
    public void WriteLong(long value)
    {
        var bytes = BitConverter.GetBytes(value);
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }
        writer.Write(bytes);
    }
    
    public void WriteDouble(double value)
    {
        var bytes = BitConverter.GetBytes(value);
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }
        writer.Write(bytes);
    }
    
    public void WriteFloat(float value)
    {
        var bytes = BitConverter.GetBytes(value);
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }
        writer.Write(bytes);
    }

    public void WriteUnsignedShort(ushort value)
    {
        var bytes = BitConverter.GetBytes(value);
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }
        writer.Write(bytes);
    }
    
    public void Dispose()
    {
        writer.Dispose();
    }
}