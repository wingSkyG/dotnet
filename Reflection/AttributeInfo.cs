using System.Reflection;
using System.Reflection.Metadata;

public class SampleAttribute : Attribute
{
    public string sampleFieldPublic;
    private string sampleFieldPrivate;

    public SampleAttribute(string sampleFieldPublic, string sampleFieldPrivate)
    {
        this.sampleFieldPublic = sampleFieldPublic;
        this.sampleFieldPrivate = sampleFieldPrivate;
    }

    public string V { get; }
}

[Sample("This is a string of public.", "This is a string of private.")]
internal class AttributeInfo
{
    private static void Main(string[] args)
    {
        Type type = typeof(AttributeInfo);

        // 通过Type的GetCustomAttributes接口获取特性
        var attibutes1 = type.GetCustomAttributes(typeof(SampleAttribute), true);
        Console.WriteLine("attibutes1 num: {0}", attibutes1.Length);
        foreach (SampleAttribute attrib in attibutes1)
        {
            Console.WriteLine(attrib.sampleFieldPublic);
        }

        // 通过Attribute的GetCustomAttributes接口获取特性
        var attibutes2 = Attribute.GetCustomAttributes(type, true);
        Console.WriteLine("attibutes2 num: {0}", attibutes2.Length);
        foreach (SampleAttribute attrib in attibutes2)
        {
            Console.WriteLine(attrib.sampleFieldPublic);
        }

        Console.ReadKey();
    }
}
