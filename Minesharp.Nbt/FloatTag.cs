namespace Minesharp.Nbt;

/// <summary>
/// 	A single, big endian IEEE-754 single-precision floating point number (NaN possible)
/// </summary>
public class FloatTag : Tag<float>
{
    public FloatTag(float value) : base(value)
    {
    }
    
    public static explicit operator FloatTag(float f) => new(f);

    public override TagType Type => TagType.Float;
}