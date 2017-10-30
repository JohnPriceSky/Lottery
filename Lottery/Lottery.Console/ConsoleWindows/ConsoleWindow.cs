using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Console.ConsoleWindows
{
    class ConsoleWindow
    {
        protected void ClearHeader()
        {
            System.Console.BackgroundColor = ConsoleColor.Blue;
            for (int top = 0; top < 3; top++)
            {
                System.Console.SetCursorPosition(0, top);
                System.Console.Write(new string(' ', 120));
            }
        }

        protected void ClearContent()
        {
            System.Console.BackgroundColor = ConsoleColor.Gray;
            for (int top = 3; top < 29; top++)
            {
                System.Console.SetCursorPosition(0, top);
                System.Console.Write(new string(' ', 120));
            }
        }
    }
}
