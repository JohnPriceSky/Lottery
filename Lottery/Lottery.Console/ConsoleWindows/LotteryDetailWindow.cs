using Lottery.Application.Abstract;
using Lottery.Application.DTO;
using Lottery.Application.Services;
using Lottery.Console.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Console.ConsoleWindows
{
    class LotteryDetailWindow : ConsoleWindow, IConsoleWindow
    {
        private LotteryDetailsDTO lotteryDetails;
        private ILotteryService _lotteryService;
        private long userId;
        private long lotteryId;

        public LotteryDetailWindow(long userId, long lotteryId, ILotteryService lotteryService)
        {
            this.lotteryId = lotteryId;
            this.userId = userId;
            _lotteryService = lotteryService;
            lotteryDetails = _lotteryService.GetLotteryDetails(lotteryId).Result;
        }

        public void Print()
        {
            DrawMenu();
            PrintDetail();
        }

        private void PrintDetail()
        {
            System.Console.SetCursorPosition(6, 4);
            System.Console.Write(lotteryDetails.LotteryProperties.LotteryName);
            System.Console.SetCursorPosition(6, 5);
            System.Console.Write(lotteryDetails.LotteryProperties.Prize);
            System.Console.SetCursorPosition(6, 6);
            System.Console.Write(lotteryDetails.LotteryProperties.DrowTime);

            var i = 8;
            foreach (var user in lotteryDetails.UsersList)
            {
                System.Console.SetCursorPosition(6, i);
                System.Console.Write(user.UserName);
                i++;
            }
            System.Console.SetCursorPosition(6, 8);

            //More data

            System.Console.SetCursorPosition(6, 25);
            System.Console.Write("< GO BACK");
            System.Console.SetCursorPosition(45, 25);
            System.Console.Write("SIGN UP");
            if (GoBackOrSignUp())
            {
                if(_lotteryService.SignInToLottery(userId, lotteryId).Result);
                for (int top = 9; top < 18; top++)
                {
                    System.Console.SetCursorPosition(30, top);
                    System.Console.BackgroundColor = ConsoleColor.DarkCyan;
                    System.Console.Write(new string(' ', 60));
                }
                System.Console.SetCursorPosition(53, 11);
                System.Console.Write("You signed up!");
                System.Console.SetCursorPosition(55, 15);
                System.Console.BackgroundColor = ConsoleColor.Blue;
                System.Console.ForegroundColor = ConsoleColor.White;
                System.Console.Write("<< GO BACK");
                System.Console.ReadKey();
                System.Console.ForegroundColor = ConsoleColor.Black;
            }
        }

        private bool GoBackOrSignUp()
        {
            bool isSignUp = true;
            while (true)
            {
                System.Console.BackgroundColor = ConsoleColor.Gray;
                System.Console.ForegroundColor = ConsoleColor.Black;
                if (!isSignUp)
                {
                    System.Console.SetCursorPosition(6, 25);
                    System.Console.BackgroundColor = ConsoleColor.Blue;
                    System.Console.ForegroundColor = ConsoleColor.White;
                    System.Console.Write("< GO BACK");
                    System.Console.BackgroundColor = ConsoleColor.Gray;
                    System.Console.ForegroundColor = ConsoleColor.Black;
                    System.Console.SetCursorPosition(45, 25);
                    System.Console.Write("SIGN UP");
                }
                else
                {
                    System.Console.SetCursorPosition(6, 25);
                    System.Console.Write("< GO BACK");
                    System.Console.SetCursorPosition(45, 25);
                    System.Console.BackgroundColor = ConsoleColor.Blue;
                    System.Console.ForegroundColor = ConsoleColor.White;
                    System.Console.Write("SIGN UP");
                    System.Console.BackgroundColor = ConsoleColor.Gray;
                    System.Console.ForegroundColor = ConsoleColor.Black;
                }
                ConsoleKeyInfo cki = System.Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.LeftArrow:
                        isSignUp = false;
                        break;
                    case ConsoleKey.RightArrow:
                        isSignUp = true;
                        break;
                    case ConsoleKey.Enter:
                        return isSignUp;
                    default:
                        break;
                }
            }
        }

        private void DrawMenu()
        {
            System.Console.SetCursorPosition(6, 1);
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.BackgroundColor = ConsoleColor.Blue;
            System.Console.Write("LOTTERY DETAIL");
            ClearContent();
            System.Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
