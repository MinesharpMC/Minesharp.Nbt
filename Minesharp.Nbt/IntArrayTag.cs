using System.Collections;

namespace Minesharp.Nbt;

/// <summary>
/// A length-prefixed array of signed integers. The prefix is a signed integer (thus 4 bytes) and indicates the number of 4 byte integers.
/// </summary>
public class IntArrayTag : Tag, IEnumerable<int>
{
    public override TagType Type => TagType.IntArray;
    
    private readonly List<int> values = new();

    public int Count => values.Count;

    public IntArrayTag()
    {
        
    }
    
    public IntArrayTag(int[] values)
    {
        this.values = new List<int>(values);
    }
    
    public static explicit operator IntArrayTag(int[] a) => new(a);
    
    public void Add(int value)
    {
        values.Add(value);
    }
    
    public static implicit operator int[](IntArrayTag tag)
    {
        return tag.values.ToArray();
    }

    public int Get(int index)
    {
        return values[index];
    }
    
    internal override object GetValue()
    {
        return values;
    }

    public IEnumerator<int> GetEnumerator()
    {
        return values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}