namespace Minesharp.Nbt;

public abstract class Tag
{
    public string Name { get; internal set; }

    public Tag Parent { get; internal set; }
    
    public abstract TagType Type { get; }

    public IEnumerable<Tag> Ancestors
    {
        get
        {
            var output = new List<Tag>();
            var parent = Parent;
            while (parent is not null)
            {
                output.Add(parent);
                parent = parent.Parent;
            }

            return output;
        }
    }
    internal abstract object GetValue();
}

public abstract class Tag<T> : Tag
{
    private readonly T value;
    
    public Tag(T value)
    {
        this.value = value;
    }

    public static implicit operator T(Tag<T> tag)
    {
        if (tag is null)
        {
            return default;
        }
        
        return tag.value;
    }

    internal override object GetValue()
    {
        return value;
    }
    
}