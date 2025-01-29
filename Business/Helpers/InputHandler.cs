using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers;

public class InputHandler(ConsoleWrapper consoleWrapper)
{
    private readonly ConsoleWrapper _consoleWrapper = consoleWrapper;

    public virtual string GetInput(string prompt)
    {
        string input;
        do
        {
            _consoleWrapper.Write(prompt);
            input = _consoleWrapper.ReadLine();
        } while (string.IsNullOrWhiteSpace(input));
        return input;
    }
}
