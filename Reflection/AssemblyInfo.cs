using System.Reflection;

internal class AssemblyInfo
{
    private int factor;
    public AssemblyInfo(int f)
    {
        factor = f;
    }

    public int SampleMethod(int x)
    {
        Console.WriteLine("\nExample.SampleMethod({0}) executes.", x);
        return x * factor;
    }

    private static void Main(string[] args)
    {
        Assembly assem = typeof(AssemblyInfo).Assembly; // 获取Program类型的Assembly
        Console.WriteLine("Assembly full name: {0}", assem.FullName);

        AssemblyName assemName = assem.GetName();
        Console.WriteLine("assemName info: {0}\n{1}\n{2}", assemName.Name, assemName.Version, assemName.CultureName);



        Console.ReadKey();
    }
}