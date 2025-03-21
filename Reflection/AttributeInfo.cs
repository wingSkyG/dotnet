using System.Reflection;
using System.Reflection.Metadata;

[AttributeUsage(AttributeTargets.All)]
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

[Sample("attribute on class(public field).", "attribute on class(private field).")]
public class SampleClass
{
    [Sample("attribute on public field(attribute field public).", "attribute on field(attribute field private).")]
    public string sampleClassFieldPublic = "sampleClassFieldPublic";
    [Sample("attribute on private field(attribute field public).", "attribute on field(attribute field private).")]
    private string sampleClassFieldPrivate = "sampleClassFieldPrivate";

    [Sample("attribute on property(attribute field public).", "attribute on field(attribute field private).")]
    public string? SampleClassProperty {  get; set; }

    [Sample("attribute on constructor(attribute field public).", "attribute on field(attribute field private).")]
    public SampleClass()
    {

    }

    [Sample("attribute on method(public field).", "attribute on method(private field).")]
    public void MyMethod(int i)
    {
        return;
    }
}

//[Sample("This is a string of public.", "This is a string of private.")]
internal class AttributeInfo
{
    private static void Main(string[] args)
    {
        // 方法一：使用MemberInfo的方法
        Type type = typeof(SampleClass);
        Console.WriteLine("获取所有特性:");
        MemberInfo[] mi2 = type.GetMembers();
        foreach (MemberInfo mi in mi2)
        {
            Console.WriteLine("{0} CustomerAttribute:", mi.Name);
            object[] attibutes2 = mi.GetCustomAttributes(typeof(SampleAttribute), false);
            foreach (SampleAttribute ca in attibutes2)
            {
                Console.WriteLine("attribute name:{0}, attribute field value:{1}", ca.ToString(), ca.sampleFieldPublic);
            }
        }
        Console.WriteLine();

        MemberInfo mi1 = typeof(SampleClass);
        Console.WriteLine("获取类特性:");
        Console.WriteLine("{0} CustomerAttribute:", mi1.Name);
        object[] attibutes1 = mi1.GetCustomAttributes(typeof(SampleAttribute), true);
        foreach (SampleAttribute attrib in attibutes1)
        {
            Console.WriteLine(attrib.sampleFieldPublic);
        }
        Console.WriteLine();

        MemberInfo p = type.GetProperty("SampleClassProperty");
        Console.WriteLine("获取属性特性:");
        Console.WriteLine("{0} CustomerAttribute:", p.Name);
        object[] a = p.GetCustomAttributes(typeof(SampleAttribute), true);
        foreach (SampleAttribute attrib in a)
        {
            Console.WriteLine(attrib.sampleFieldPublic);
        }
        Console.WriteLine();

        Console.WriteLine("获取指定特性:");
        MemberInfo[] mi3 = type.GetMembers();
        foreach (MemberInfo mi in mi3)
        {
            if(mi.MemberType != MemberTypes.Constructor)
            {
                continue;
            }

            Console.WriteLine("{0} CustomerAttribute:", mi.Name);
            object[] attibutes2 = mi.GetCustomAttributes(typeof(SampleAttribute), false);
            foreach (SampleAttribute ca in attibutes2)
            {
                Console.WriteLine("attribute name:{0}, attribute field value:{1}", ca.ToString(), ca.sampleFieldPublic);
            }
        }
        Console.WriteLine();

        // 方法二：使用Attribute的方法
        Console.WriteLine("通过Attribute的GetCustomAttributes接口获取特性");
        MemberInfo mi4 = type.GetMethod("MyMethod");
        //MemberInfo mi4 = type.GetProperty("SampleClassProperty");
        //Type mi4 = typeof(SampleClass); // Attribute方式无法获取类型属性
        Console.WriteLine("{0} CustomerAttribute:", mi4.Name);
        Attribute[] attibutes3 = Attribute.GetCustomAttributes(mi4, true);
        foreach (SampleAttribute ca in attibutes3)
        {
            Console.WriteLine("attribute name:{0}, attribute field value:{1}", ca.ToString(), ca.sampleFieldPublic);
        }
        Console.WriteLine();

        Console.ReadKey();
    }
}
