namespace Minesharp.Nbt.Reader;

public class TagReader : IDisposable
{
    private readonly BigEndianBinaryReader reader;

    public TagReader(Stream stream)
    {
        reader = new BigEndianBinaryReader(stream);
    }
    
    public CompoundTag ReadTag()
    {
        var type = (TagType)reader.ReadByte();
        if (type != TagType.Compound)
        {
            throw new InvalidOperationException("Root tag must be Compound");
        }

        var name = reader.ReadString();
        var compound = new CompoundTag(name);
        while (true)
        {
            var childType = (TagType)reader.ReadByte();
            if (childType == TagType.End)
            {
                break;
            }

            var childName = reader.ReadString();
            compound[childName] = Read(childType);
        }

        return compound;
    }

    private Tag Read(TagType type)
    {
        switch (type)
        {
            case TagType.Byte:
                return new ByteTag(reader.ReadByte());
            case TagType.Int:
                return new IntTag(reader.ReadInt());
            case TagType.Short:
                return new ShortTag(reader.ReadShort());
            case TagType.Long:
                return new LongTag(reader.ReadLong());
            case TagType.Float:
                return new FloatTag(reader.ReadFloat());
            case TagType.Double:
                return new DoubleTag(reader.ReadDouble());
            case TagType.String:
                return new StringTag(reader.ReadString());
            case TagType.ByteArray:
            {
                var array = new ByteArrayTag();
                var length = reader.ReadInt();
                for (var i = 0; i < length; i++)
                {
                    array.Add(reader.ReadByte());
                }
                return array;
            }
            case TagType.List:
            {
                var list = new ListTag();
                var childType = (TagType)reader.ReadByte();
                var length = reader.ReadInt();
                for (var i = 0; i < length; i++)
                {
                    list.Add(Read(childType));
                }
                return list;
            }
            case TagType.Compound:
            {
                var compound = new CompoundTag();
                while (true)
                {
                    var childType = (TagType)reader.ReadByte();
                    if (childType == TagType.End)
                    {
                        break;
                    }

                    var childName = reader.ReadString();
                    compound[childName] = Read(childType);
                }

                return compound;
            }
            case TagType.IntArray:
            {
                var array = new IntArrayTag();
                var length = reader.ReadInt();
                for (var i = 0; i < length; i++)
                {
                    array.Add(reader.ReadInt());
                }

                return array;
            }
            case TagType.LongArray:
            {
                var array = new LongArrayTag();
                var length = reader.ReadInt();
                for (var i = 0; i < length; i++)
                {
                    array.Add(reader.ReadLong());
                }

                return array;
            }
            default:
                throw new InvalidOperationException();
        }
    }

    public void Dispose()
    {
        reader.Dispose();
    }
}