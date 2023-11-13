
using System.Collections.Generic;


namespace Laba_7_V_11
{
    public class ListTasksExtention
    {
        public delegate bool CompareDelegate(Task left, Task right);
        public delegate bool SearchDelegate(Task task, string searchValue);

        /// <summary>
        /// Сортировка листа заданий
        /// </summary>
        /// <param name="listTasks">лист заданий</param>
        /// <param name="compareDelegate">делегат для сравнения елементов листа</param>
        public static void Sort(List<Task> listTasks, CompareDelegate compareDelegate)
        {
            for (int i = 0; i < listTasks.Count - 1; i++)
            {
                for (int j = 0; j < listTasks.Count - 1; j++)
                {
                    if (compareDelegate(listTasks[j], listTasks[j + 1]))
                    {
                        (listTasks[j], listTasks[j + 1]) = (listTasks[j + 1], listTasks[j]);
                    }
                }
            }
        }


        /// <summary>
        /// Поиск в листе заданий
        /// </summary>
        /// <param name="listTasks">лист заданий</param>
        /// <param name="searchValue"> по какому значению фильтровать</param>
        /// <param name="searchDelegate"> делегат для фильтрования елементов листа</param>
        /// <returns></returns>
        public static List<Task> Search(List<Task> listTasks, string searchValue, SearchDelegate searchDelegate)
        {
            List<Task> temp = new List<Task>();

            for (int i = 0; i < listTasks.Count; i++)
            {
                if (searchDelegate(listTasks[i], searchValue))
                {
                    temp.Add(listTasks[i]);
                }
            }
            return temp;
        }
    }
}
