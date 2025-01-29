using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers;

public class ErrorLogger
{
    public void ErrorMessage(string message)
    {
        Debug.WriteLine(message);
    }
}
