namespace Minesharp.Nbt.Writer;

public class TagWriter : IDisposable
{
    private readonly BigEndianBinaryWriter writer;

    public TagWriter(Stream stream)
    {
        writer = new BigEndianBinaryWriter(stream);
    }

    public void Write(Tag tag)
    {
        if (tag.Parent?.Type != TagType.List)
        {
            writer.WriteByte((sbyte)tag.Type);
            writer.WriteString(tag.Name ?? string.Empty);
        }
        
        switch (tag.Type)
        {
            case TagType.Byte:
                writer.WriteByte((sbyte)tag.GetValue());
                break;
            case TagType.Int:
                writer.WriteInt((int)tag.GetValue());
                break;
            case TagType.Long:
                writer.WriteLong((long)tag.GetValue());
                break;
            case TagType.Short:
                writer.WriteShort((short)tag.GetValue());
                break;
            case TagType.Float:
                writer.WriteFloat((float)tag.GetValue());
                break;
            case TagType.Double:
                writer.WriteDouble((double)tag.GetValue());
                break;
            case TagType.String:
                writer.WriteString((string)tag.GetValue());
                break;
            case TagType.List:
                var list = (ListTag)tag;
                writer.WriteByte((sbyte)list.ChildType);
                writer.WriteInt(list.Count);

                foreach (var child in list)
                {
                    Write(child);
                }
                break;
            case TagType.Compound:
                var compound = (CompoundTag)tag;
                foreach (var child in compound)
                {
                    Write(child);
                }
                writer.WriteByte((sbyte)TagType.End);
                break;
            case TagType.ByteArray:
                var byteArray = (ByteArrayTag)tag;
                writer.WriteInt(byteArray.Count);
                foreach (var value in byteArray)
                {
                    writer.WriteByte(value);
                }
                break;
            case TagType.IntArray:
                var intArray = (IntArrayTag)tag;
                writer.WriteInt(intArray.Count);
                foreach (var value in intArray)
                {
                    writer.WriteInt(value);
                }
                break;
            case TagType.LongArray:
                var longArray = (LongArrayTag)tag;
                writer.WriteInt(longArray.Count);
                foreach (var value in longArray)
                {
                    writer.WriteLong(value);
                }
                break;
            default:
                break;
        }
    }
    
    public void Dispose()
    {
        writer.Dispose();
    }
}