using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailjetDemoApp
{
    public static class Ensure
    {
        public static void ConditionIsMet(bool condition, Func<Exception> exceptionFunc)
        {
            if (condition)
            {
                return;
            }
            throw exceptionFunc();
        }
    }
}
