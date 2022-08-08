namespace Minesharp.Nbt;

/// <summary>
/// A single, big endian IEEE-754 double-precision floating point number (NaN possible)
/// </summary>
public class DoubleTag : Tag<double>
{
    public DoubleTag(double value) : base(value)
    {
    }
    
    public static explicit operator DoubleTag(double d) => new(d);

    public override TagType Type => TagType.Double;
}