using System.Collections;

namespace Minesharp.Nbt;

/// <summary>
/// A length-prefixed array of signed longs. The prefix is a signed integer (thus 4 bytes) and indicates the number of 8 byte longs.
/// </summary>
public class LongArrayTag : Tag, IEnumerable<long>
{
    public override TagType Type => TagType.LongArray;
    
    private readonly List<long> values = new();

    public int Count => values.Count;
    
    public LongArrayTag()
    {
        
    }
    
    public LongArrayTag(long[] values)
    {
        this.values = new List<long>(values);
    }
    
    public static explicit operator LongArrayTag(long[] a) => new(a);
    
    public void Add(long value)
    {
        values.Add(value);
    }
    
    public static implicit operator long[](LongArrayTag tag)
    {
        return tag.values.ToArray();
    }

    public long Get(int index)
    {
        return values[index];
    }
    
    internal override object GetValue()
    {
        return values;
    }

    public IEnumerator<long> GetEnumerator()
    {
        return values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}