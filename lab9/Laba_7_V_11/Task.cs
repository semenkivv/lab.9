using System;
using System.Text.Json.Serialization;

namespace Laba_7_V_11
{
    [Serializable]
    public class Task
    {
        private bool _isCompleted;
        private string _description;
        private DateTime _dateCreated;
        private DateTime _dateCompleated;

        public Task(string description)
        {
            IsCompleted = false;
            Description = description;
            DateCreated = GenerateRandomDate();
        }

        [JsonPropertyName("IsCompleted")]
        /// <summary>
        /// Свойство выполнена ли задача
        /// </summary>
        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {
                if (value)
                {
                    DateCompleated = DateTime.Now;
                }
                _isCompleted = value;
            }
        }

        [JsonPropertyName("Description")]
        /// <summary>
        /// Свойство описание задачи , возвращает ArgumentNullException, если пытаемся присвоить пустую строку
        /// </summary>
        public string Description
        {
            get => _description;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _description = value.Trim();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        [JsonPropertyName("DateCreated")]
        /// <summary>
        ///  Свойство дата создания задачи, возвращает ArgumentException если некоректная дата
        /// </summary>
        public DateTime DateCreated
        {
            get => _dateCreated;
            init
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException();
                }
                else
                {
                    _dateCreated = value;
                }
            }
        }

        [JsonPropertyName("DateCompleated")]
        /// <summary>
        ///  Свойство дата, когда выполненили задачу, возвращает ArgumentException если некоректная дата
        /// </summary>
        public DateTime DateCompleated
        {
            get => _dateCompleated;
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException();
                }
                else
                {
                    _dateCompleated = value;
                }
            }
        }
        public override string ToString()
        {
            string isCompleted = (IsCompleted ? "" : "not ")+ "compleated" + (IsCompleted ? " at ="+DateCompleated : "") ;
            return $"Task ({isCompleted})\nDescription={Description};  \nCreated  ={DateCreated}; \n";
        }

        /// <summary>
        /// Генерация рандомной даты
        /// </summary>
        /// <returns></returns>
        private DateTime GenerateRandomDate()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(new Random().Next(range));
        }

        /// <summary>
        /// Сортировка по возростанию 
        /// </summary>
        /// <param name="left">первая задача</param>
        /// <param name="right">вторая задача</param>
        /// <returns></returns>
        public static bool OrderByDateCreated(Task left, Task right)
        {
            return DateTime.Compare(left.DateCreated, right.DateCreated) > 0;
        }

        /// <summary>
        /// Сортировка по убыванию 
        /// </summary>
        /// <param name="left">первая задача</param>
        /// <param name="right">вторая задача</param>
        /// <returns></returns>
        public static bool OrderByDescendingDateCreated(Task left, Task right)
        {
            return DateTime.Compare(left.DateCreated, right.DateCreated) < 0;
        }

        /// <summary>
        /// Фильтрация по описанию задачи
        /// </summary>
        /// <param name="task">задача</param>
        /// <param name="value">фильтрующий параметр</param>
        /// <returns></returns>
        public static bool FilterByDescription(Task task, string value)
        {
            return task.Description.Contains(value, StringComparison.OrdinalIgnoreCase);
        }

    }
}
