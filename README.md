# NamedBinaryTag
### Using static methods
```csharp
public static void Main(string[] args)
{
    var tag = new CompoundTag
    {
        ["MyShort"] = new ShortTag(456),
        ["MyInt"] = new IntTag(4),
        ["MyDouble"] = new DoubleTag(57.5),
        ["MyCompound"] = new CompoundTag
        {
            ["MyByte"] = new ByteTag(1),
            ["MyLong"] = new LongTag(48747),
            ["MyFloat"] = new FloatTag(49.84f)
        },
        ["MyList"] = new ListTag
        {
            new StringTag("Named"),
            new StringTag("Binary"),
            new StringTag("Tag")
        },
        ["MyByteArray"] = new ByteArrayTag { 1, 2, 3 },
        ["MyIntArray"] = new IntArrayTag { 1, 2, 3 },
        ["MyLongArray"] = new LongArrayTag { 1, 2, 3 }
    };

    var compressedBytes = NamedBinaryTagConverter.GetBytes(tag, true);
    var compressed = NamedBinaryTagConverter.FromBytes(compressedBytes, true);
    
    var uncompressedBytes = NamedBinaryTagConverter.GetBytes(tag);
    var uncompressed = NamedBinaryTagConverter.FromBytes(uncompressedBytes);
    
    var serialized = NamedBinaryTagConverter.GetString(tag);
}
```
### Using streams
```csharp
public static void Main(string[] args)
{
    var tag = new CompoundTag
    {
        ["MyShort"] = new ShortTag(456),
        ["MyInt"] = new IntTag(4),
        ["MyDouble"] = new DoubleTag(57.5),
        ["MyCompound"] = new CompoundTag
        {
            ["MyByte"] = new ByteTag(1),
            ["MyLong"] = new LongTag(48747),
            ["MyFloat"] = new FloatTag(49.84f)
        },
        ["MyList"] = new ListTag
        {
            new StringTag("Named"),
            new StringTag("Binary"),
            new StringTag("Tag")
        },
        ["MyByteArray"] = new ByteArrayTag { 1, 2, 3 },
        ["MyIntArray"] = new IntArrayTag { 1, 2, 3 },
        ["MyLongArray"] = new LongArrayTag { 1, 2, 3 }
    };

    // Without compression
    using (var file = File.Create("example.nbt"))
    using (var writer = new TagWriter(file))
    {
        writer.Write(tag);
    }
    
    // With compression
    using (var file = File.Create("example.nbt"))
    using (var writer = new CompressedTagWriter(file))
    {
        writer.Write(tag);
    }

    // Without compression
    using (var file = File.OpenRead("example.nbt"))
    using (var reader = new TagReader(file))
    {
        tag = reader.ReadTag();
    }
    
    // With compression
    using (var file = File.OpenRead("example.nbt"))
    using (var reader = new CompressedTagReader(file))
    {
        tag = reader.ReadTag();
    }
}
```
