namespace Minesharp.Nbt;

/// <summary>
/// 	A single signed, big endian 64 bit integer
/// </summary>
public class LongTag : Tag<long>
{
    public LongTag(long value) : base(value)
    {
    }

    public static explicit operator LongTag(long i) => new(i);
    
    public override TagType Type => TagType.Long;
}