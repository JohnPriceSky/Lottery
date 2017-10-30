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
    class AdminWindow : ConsoleWindow, IConsoleWindow
    {
        private string username;
        private List<LotteryDTO> lotteryList;
        private LotteryService _lotteryService;

        public AdminWindow(string username)
        {
            this.username = username;
            _lotteryService = new LotteryService();
        }

        public void Print()
        {
            DrawMenu();
            lotteryList = _lotteryService.GetLotteries().Result.ToList();

            DisplayList(lotteryList);
            ChooseLotteryOrAction(lotteryList);
        }

        private void ChooseLotteryOrAction(List<LotteryDTO> lotteryList)
        {
            int index = 0;
            while (true)
            {
                index %= lotteryList.Count;
                if (index < 0)
                    DisplayList(lotteryList, index + lotteryList.Count);
                else
                    DisplayList(lotteryList, index);
                ConsoleKeyInfo cki = System.Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.DownArrow:
                        index++;
                        break;
                    case ConsoleKey.UpArrow:
                        index--;
                        break;
                    case ConsoleKey.Enter:
                        int lotteryDetailIndex;
                        if (index < 0)
                            lotteryDetailIndex = index + lotteryList.Count;
                        else
                            lotteryDetailIndex = index;
                        break;
                    case ConsoleKey.A:
                        AddNewLottery(lotteryList);
                        lotteryList = _lotteryService.GetLotteries().Result.ToList();
                        break;
                    case ConsoleKey.D:
                        if (index < 0)
                            _lotteryService.DeleteLottery(lotteryList[index + lotteryList.Count].Id).Wait();
                        else
                            _lotteryService.DeleteLottery(lotteryList[index].Id).Wait();

                        lotteryList = _lotteryService.GetLotteries().Result.ToList();
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            }
        }

        private void AddNewLottery(List<LotteryDTO> lotteryList)
        {
            for (int top = 6; top < 21; top++)
            {
                System.Console.SetCursorPosition(30, top);
                System.Console.BackgroundColor = ConsoleColor.DarkCyan;
                System.Console.Write(new string(' ', 60));
            }
            System.Console.SetCursorPosition(52, 8);
            System.Console.Write("Add new lottery");

            System.Console.SetCursorPosition(34, 11);
            System.Console.Write("Name:");
            System.Console.SetCursorPosition(34, 13);
            System.Console.Write("Prize:");
            System.Console.SetCursorPosition(34, 15);
            System.Console.Write("Date:");
            System.Console.SetCursorPosition(40, 11);
            System.Console.Write(new string('_', 40));
            System.Console.SetCursorPosition(40, 13);
            System.Console.Write(new string('_', 40));
            System.Console.SetCursorPosition(40, 15);
            System.Console.Write(new string('_', 40));

            System.Console.SetCursorPosition(50, 18);
            System.Console.Write("<< GO BACK");
            System.Console.SetCursorPosition(63, 18);
            System.Console.Write("ADD");

            System.Console.CursorVisible = true;
            System.Console.SetCursorPosition(40, 11);
            string name = System.Console.ReadLine();
            System.Console.SetCursorPosition(40, 13);
            string prize = System.Console.ReadLine();
            System.Console.SetCursorPosition(40, 15);
            string date = System.Console.ReadLine();

            if (GoBackOrAdd())
            {
                //add lottery
                var newLottery = new LotteryDTO();
                newLottery.LotteryName = name;
                newLottery.Prize = prize;
                newLottery.DrowTime = DateTime.Parse(date);
                if (_lotteryService.AddLottery(newLottery).Result)
                {
                    System.Console.WriteLine("OK");
                }
            }
        }

        private bool GoBackOrAdd()
        {
            bool isAdd = true;
            while (true)
            {
                System.Console.BackgroundColor = ConsoleColor.DarkCyan;
                System.Console.ForegroundColor = ConsoleColor.Black;
                if (!isAdd)
                {
                    System.Console.SetCursorPosition(50, 18);
                    System.Console.BackgroundColor = ConsoleColor.Blue;
                    System.Console.ForegroundColor = ConsoleColor.White;
                    System.Console.Write("<< GO BACK");
                    System.Console.BackgroundColor = ConsoleColor.DarkCyan;
                    System.Console.ForegroundColor = ConsoleColor.Black;
                    System.Console.SetCursorPosition(63, 18);
                    System.Console.Write("ADD");
                }
                else
                {
                    System.Console.SetCursorPosition(50, 18);
                    System.Console.Write("<< GO BACK");
                    System.Console.SetCursorPosition(63, 18);
                    System.Console.BackgroundColor = ConsoleColor.Blue;
                    System.Console.ForegroundColor = ConsoleColor.White;
                    System.Console.Write("ADD");
                    System.Console.BackgroundColor = ConsoleColor.DarkCyan;
                    System.Console.ForegroundColor = ConsoleColor.Black;
                }
                ConsoleKeyInfo cki = System.Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.LeftArrow:
                        isAdd = false;
                        break;
                    case ConsoleKey.RightArrow:
                        isAdd = true;
                        break;
                    case ConsoleKey.Enter:
                        return isAdd;
                    default:
                        break;
                }
            }
        }

        private void DisplayList(List<LotteryDTO> lotteryList, int index = -1)
        {
            ClearContent();
            System.Console.SetCursorPosition(6, 28);
            System.Console.Write("[a] - add new lottery, [d] - delete selected lottery");
            int top = 4;
            foreach (var item in lotteryList)
            {
                if (index >= 0 && lotteryList[index] == item)
                    System.Console.BackgroundColor = ConsoleColor.DarkGray;
                else
                    System.Console.BackgroundColor = ConsoleColor.Gray;

                for (int i = 0; i < 3; i++)
                {
                    System.Console.SetCursorPosition(0, top + i);
                    System.Console.Write(new string(' ', 120));
                }
                top++;
                System.Console.SetCursorPosition(6, top);
                System.Console.Write(item.LotteryName);
                System.Console.SetCursorPosition(50, top);
                System.Console.Write("Prize: " + item.Prize);
                System.Console.SetCursorPosition(70, top);
                System.Console.Write("DrowTime: " + item.DrowTime);
                top++;
                top++;
                System.Console.SetCursorPosition(0, top++);
                System.Console.Write(new string('-', 120));
            }
        }

        private void DrawMenu()
        {
            ClearHeader();
            System.Console.SetCursorPosition(6, 1);
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write("ADMIN DASHBOARD");
            System.Console.SetCursorPosition(80, 1);
            System.Console.Write($"Logged as {username}");
            ClearContent();
            System.Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
