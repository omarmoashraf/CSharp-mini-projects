using System;
using System.Collections.Generic;

namespace TaskTracker
{
    class Program
    {
        static List<string> tasks = new List<string>();
        static HashSet<int> completedTasks = new HashSet<int>(); // track completed tasks

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Welcome to Task Tracker ===");
            Console.ResetColor();

            while (true)
            {
                ShowMenu();
                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1": AddTask(); break;
                    case "2": ViewTasks(); break;
                    case "3": MarkTaskAsDone(); break;
                    case "4": RemoveTask(); break;
                    case "5": ExitProgram(); break;
                    default: ShowError("Invalid option. Please try again."); break;
                }
                Pause();
            }
        }

        private static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nChoose an option:");
            Console.ResetColor();

            Console.WriteLine("1. Add task");
            Console.WriteLine("2. View tasks");
            Console.WriteLine("3. Mark task as done");
            Console.WriteLine("4. Remove task");
            Console.WriteLine("5. Exit");
            Console.Write(" Your choice: ");
        }

        private static void AddTask()
        {
            Console.Write("Enter task: ");
            string task = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(task))
            {
                tasks.Add(task);
                ShowSuccess("Task added successfully!");
            }
            else
            {
                ShowError("Task cannot be empty.");
            }
        }

        private static void ViewTasks()
        {
            if (tasks.Count == 0)
            {
                ShowError("No tasks found.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nYour Tasks:");
            Console.ResetColor();

            for (int i = 0; i < tasks.Count; i++)
            {
                string status = completedTasks.Contains(i) ? "[✔]" : "[ ]";
                Console.WriteLine($"{i + 1}. {status} {tasks[i]}");
            }
        }

        private static void MarkTaskAsDone()
        {
            if (!GetTaskNumber(out int index)) return;
            if (!completedTasks.Contains(index))
            {
                completedTasks.Add(index);
                ShowSuccess("Task marked as done!");
            }
            else
            {
                ShowError("Task is already marked as done.");
            }
        }

        private static void RemoveTask()
        {
            if (!GetTaskNumber(out int index)) return;
            tasks.RemoveAt(index);
            completedTasks.Remove(index); // cleanup
            ShowSuccess("Task removed.");
        }

        private static void ExitProgram()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nThanks for using Task Tracker. Goodbye!");
            Console.ResetColor();
            Environment.Exit(0);
        }

        // Helpers
        private static bool GetTaskNumber(out int index)
        {
            Console.Write("Enter task number: ");
            if (!int.TryParse(Console.ReadLine(), out int num) || num < 1 || num > tasks.Count)
            {
                ShowError("Invalid task number.");
                index = -1;
                return false;
            }
            index = num - 1;
            return true;
        }

        private static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void ShowSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
