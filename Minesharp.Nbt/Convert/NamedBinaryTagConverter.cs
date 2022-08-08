using System.Text;
using Minesharp.Nbt.Reader;
using Minesharp.Nbt.Writer;

namespace Minesharp.Nbt.Convert;

public static class NamedBinaryTagConverter
{
    public static byte[] GetBytes(CompoundTag tag, bool compressed = false)
    {
        using var stream = new MemoryStream();
        using (var writer = compressed ? new CompressedTagWriter(stream) : new TagWriter(stream))
        {
            writer.Write(tag);
        }

        return stream.ToArray();
    }

    public static CompoundTag FromBytes(byte[] bytes, bool compressed = false)
    {
        using var stream = new MemoryStream(bytes);
        using (var reader = compressed ? new CompressedTagReader(stream) : new TagReader(stream))
        {
            return reader.ReadTag();
        }
    }

    public static string GetString(Tag tag)
    {
        var indentation = string.Empty;
        for (var i = 0; i < tag.Ancestors.Count(); i++)
        {
            indentation += "    ";
        }
        
        var sb = new StringBuilder($"{indentation}TAG_{tag.Type}({(tag.Name is null ? "None" : $"'{tag.Name}'")}): ");
        switch (tag.Type)
        {
            case TagType.String:
                sb.Append($"'{tag.GetValue()}'").Append('\n');
                break;
            case TagType.Compound:
                var compound = (CompoundTag)tag;
                sb.Append($"{compound.Count} entries").Append('\n');
                sb.Append(indentation).Append('{').Append('\n');
                foreach (var value in compound)
                {
                    sb.Append(GetString(value));
                }
                sb.Append(indentation).Append('}').Append('\n');
                break;
            case TagType.List:
                var list = (ListTag)tag;
                sb.Append($"{list.Count} entries of type {list.ChildType}").Append('\n');
                sb.Append(indentation).Append('{').Append('\n');
                foreach (var value in list)
                {
                    sb.Append(GetString(value));
                }
                sb.Append(indentation).Append('}').Append('\n');
                break;
            case TagType.ByteArray:
                var byteArray = (ByteArrayTag)tag;
                sb.Append('[').Append(string.Join(", ", byteArray)).Append(']').Append('\n');
                break;
            case TagType.IntArray:
                var intArray = (IntArrayTag)tag;
                sb.Append('[').Append(string.Join(", ", intArray)).Append(']').Append('\n');
                break;
            case TagType.LongArray:
                var longArray = (LongArrayTag)tag;
                sb.Append('[').Append(string.Join(", ", longArray)).Append(']').Append('\n');
                break;
            default:
                sb.Append(tag.GetValue()).Append('\n');
                break;
        }

        return sb.ToString();
    }
}