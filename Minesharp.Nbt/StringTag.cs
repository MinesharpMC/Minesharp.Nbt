namespace Minesharp.Nbt;

/// <summary>
/// A length-prefixed modified UTF-8 string. The prefix is an unsigned short (thus 2 bytes) signifying the length of the string in bytes
/// </summary>
public class StringTag : Tag<string>
{
    public StringTag(string value) : base(value)
    {
    }

    public static explicit operator StringTag(string i) => new(i);
    
    public override TagType Type => TagType.String;
}