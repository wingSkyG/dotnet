using System.Reflection;

internal class TypeInfo
{
    public int sampleField = 1;

    public int SampleProperty {  get; set; }

    public void SampleMethod(string sampleMethodParam)
    {

    }

    private static void Main(string[] args)
    {
        Type t = typeof(TypeInfo); // 获取Program类型的Assembly

        Console.WriteLine("member info:");
        MemberInfo[] mis = t.GetMembers();
        PrintMembers(mis);

        Console.WriteLine("constructor info:");
        ConstructorInfo[] cis = t.GetConstructors();
        PrintMembers(cis);

        Console.WriteLine("field info:");
        FieldInfo[] fis = t.GetFields();
        PrintMembers(fis);

        Console.WriteLine("property info:");
        PropertyInfo[] pis = t.GetProperties();
        PrintMembers(pis);

        Console.WriteLine("method info:");
        MethodInfo[] methodInfos = t.GetMethods();
        PrintMembers(methodInfos);

        Console.WriteLine("event info:");
        EventInfo[] eis = t.GetEvents();
        PrintMembers(eis);

        Console.ReadKey();
    }

    public static void PrintMembers(MemberInfo[] ms) // MemberInfo是ConstructorInfo、FieldInfo、PropertyInfo、MethodInfo、EventInfo的基类
    {
        foreach (MemberInfo m in ms)
        {
            Console.WriteLine("{0}{1}", "     ", m);
        }
        Console.WriteLine();
    }
}