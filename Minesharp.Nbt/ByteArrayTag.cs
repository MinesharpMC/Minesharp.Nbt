using System.Collections;

namespace Minesharp.Nbt;

public class ByteArrayTag : Tag, IEnumerable<sbyte>
{
    public override TagType Type => TagType.ByteArray;
    
    private readonly List<sbyte> values = new();

    public int Count => values.Count;

    public ByteArrayTag()
    {
        
    }
    
    public ByteArrayTag(sbyte[] values)
    {
        this.values = new List<sbyte>(values);
    }
    
    public static explicit operator ByteArrayTag(sbyte[] a) => new(a);
    
    public void Add(sbyte value)
    {
        values.Add(value);
    }

    public static implicit operator sbyte[](ByteArrayTag tag)
    {
        return tag.values.ToArray();
    }
    
    public sbyte Get(int index)
    {
        return values[index];
    }
    
    internal override object GetValue()
    {
        return values;
    }

    public IEnumerator<sbyte> GetEnumerator()
    {
        return values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}