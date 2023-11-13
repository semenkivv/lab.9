using System;
using System.Collections.Generic;

namespace Laba_7_V_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task1 = new Task("do work");
            Task task2 = new Task("do sleap");
            Task task3 = new Task("do laba 3");
            Task task4 = new Task("meet with manager");
            Task task5 = new Task("do relax");
            ListTasks listTasks = new ListTasks(task4, task3, task5);
            listTasks.AddElement(task1);
            listTasks.AddElement(task2);

            Console.WriteLine("ListTasks  :");
            Console.WriteLine(listTasks);
            Console.WriteLine("------------------------------------");

            ListTasksExtention.Sort(listTasks.tasks, Task.OrderByDateCreated);
            Console.WriteLine("ListTasks sort by DateCreated in ascending order:");
            Console.WriteLine(listTasks);
            Console.WriteLine("------------------------------------");

            ListTasksExtention.Sort(listTasks.tasks, Task.OrderByDescendingDateCreated);
            Console.WriteLine("ListTasks sort by DateCreated in descending order:");
            Console.WriteLine(listTasks);
            Console.WriteLine("------------------------------------");

            //Лямбда выражение
            ListTasksExtention.Sort(listTasks.tasks, (Task left, Task right)=> DateTime.Compare(left.DateCreated, right.DateCreated) > 0);
            Console.WriteLine("ListTasks sort by DateCreated in ascending order:");
            Console.WriteLine(listTasks);
            Console.WriteLine("------------------------------------");


            List<Task> filteredListTasks1 = ListTasksExtention.Search(listTasks.tasks, "o", Task.FilterByDescription);
            Console.WriteLine("Filter by Description query=O:\n");
            foreach (var item in filteredListTasks1)
            {
                Console.WriteLine(item + "\n");
            }
            Console.WriteLine("------------------------------------");

            //Лямбда выражение
            List<Task> filteredListTasks2 = ListTasksExtention.Search(listTasks.tasks, "D", (Task task, string searchValue) => task.Description.Contains(searchValue, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Filter by Description query=D:\n");
            foreach (var item in filteredListTasks2)
            {
                Console.WriteLine(item + "\n");
            }
            Console.WriteLine("------------------------------------");

        }
    }
}
