namespace Minesharp.Nbt;

/// <summary>
/// A single signed, big endian 16 bit integer
/// </summary>
public class ShortTag : Tag<short>
{
    public ShortTag(short value) : base(value)
    {
    }
    
    public static explicit operator ShortTag(short i) => new(i);

    public override TagType Type => TagType.Short;
}