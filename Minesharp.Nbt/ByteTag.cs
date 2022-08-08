namespace Minesharp.Nbt;

/// <summary>
/// A single signed byte
/// </summary>
public class ByteTag : Tag<sbyte>
{
    public ByteTag(sbyte value) : base(value)
    {
    }
    
    public static explicit operator ByteTag(sbyte b) => new(b);

    public override TagType Type => TagType.Byte;
}