namespace Minesharp.Nbt;

/// <summary>
/// 	A single signed, big endian 32 bit integer
/// </summary>
public class IntTag : Tag<int>
{
    public IntTag(int value) : base(value)
    {
    }
    
    public static explicit operator IntTag(int i) => new(i);

    public override TagType Type => TagType.Int;
}