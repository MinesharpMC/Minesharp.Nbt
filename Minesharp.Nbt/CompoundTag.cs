using System.Collections;

namespace Minesharp.Nbt;

/// <summary>
/// Effectively a list of a named tags. Order is not guaranteed.
/// </summary>
public class CompoundTag : Tag, IEnumerable<Tag>
{
    public override TagType Type => TagType.Compound;

    private readonly Dictionary<string, Tag> tags = new();

    public int Count => tags.Count;
    
    public Tag this[string name]
    {
        get => tags[name];
        set
        {
            if (value is null)
            {
                return;
            }

            value.Name = name;
            value.Parent = this;

            tags[name] = value;
        }
    }

    public CompoundTag() : this(string.Empty)
    {
        
    }
    
    public CompoundTag(string name)
    {
        Name = name;
    }
    
    public T Get<T>(string name) where T : Tag
    {
        return tags.GetValueOrDefault(name) as T;
    }

    internal override object GetValue()
    {
        return new List<Tag>(tags.Values);
    }

    public IEnumerator<Tag> GetEnumerator()
    {
        return tags.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}