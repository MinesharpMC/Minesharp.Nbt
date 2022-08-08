namespace Minesharp.Nbt.Example;

public static class Program
{
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
    }
}