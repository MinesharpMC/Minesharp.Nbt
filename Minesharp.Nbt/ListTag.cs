using System.Collections;

namespace Minesharp.Nbt;

/// <summary>
/// A list of nameless tags, all of the same type.
/// The list is prefixed with the Type ID of the items it contains (thus 1 byte), and the length of the list as a signed integer (a further 4 bytes).
/// If the length of the list is 0 or negative, the type may be 0 (TAG_End) but otherwise it must be any other type.
/// (The notchian implementation uses TAG_End in that situation, but another reference implementation by Mojang uses 1 instead; parsers should accept any type if the length is <= 0).
/// </summary>
public class ListTag : Tag, IEnumerable<Tag>
{
    public override TagType Type => TagType.List;
    public TagType ChildType { get; private set; }

    public int Count => tags.Count;
    
    private readonly List<Tag> tags = new();

    public void Add(Tag tag)
    {
        if (tags.Count == 0)
        {
            ChildType = tag.Type;
        }
        
        if (tag.Type != ChildType)
        {
            throw new InvalidOperationException();
        }
        
        tag.Name = null;
        tag.Parent = this;

        tags.Add(tag);
    }
    
    public T Get<T>(int index) where T : Tag
    {
        var tag = tags[index] as T;
        if (tag is null)
        {
            return null;
        }

        return tag;
    }

    public IEnumerable<T> As<T>() where T : Tag
    {
        return tags.Cast<T>();
    }

    internal override object GetValue()
    {
        return tags;
    }

    public IEnumerator<Tag> GetEnumerator()
    {
        return tags.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}