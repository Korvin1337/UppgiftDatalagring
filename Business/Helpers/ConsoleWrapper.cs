using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers;

public class ConsoleWrapper
{
    public virtual void Clear()
    {
        Console.Clear();
    }

    public virtual void ReadKey()
    {
        Console.ReadKey();
    }

    public virtual void Write(string message)
    {
        Console.WriteLine(message);
    }

    public virtual string ReadLine() => Console.ReadLine()!;
}
