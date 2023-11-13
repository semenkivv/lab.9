using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace Laba_7_V_11
{
    class FileManager
    {
        private static BinaryFormatter _binaryFormatter = new BinaryFormatter();

        /// <summary>
        /// Сериализация listTasks в файл json ,если listTasks равен нулю или строка fileName не заканчивается на ".json" ,то возвращает ArgumentException 
        /// </summary>
        /// <param name="listTasks">лист, который сериализуется</param>
        /// <param name="fileName">имя файла , в который запишется listTasks </param>
        public static void SerializationToJSON(List<Task> listTasks, string fileName)
        {
            if (listTasks is not null && fileName.EndsWith(".json"))
            {
                string output = JsonSerializer.Serialize(listTasks);
                using var outFile = new FileStream(fileName, FileMode.Create);
                using StreamWriter writer = new StreamWriter(outFile);
                writer.Write(output);
            }
            else
            {
                throw new ArgumentException();
            }
        }
        /// <summary>
        /// Десериализация из файла json в listTasks , если строка fileName не заканчивается на ".json", то возвращает ArgumentException 
        /// </summary>
        /// <param name="fileName">имя файла , из которого десериализуем </param>
        public static List<Task> DeserializationFromJSON(string fileName)
        {
            if (fileName.EndsWith(".json"))
            {
                using var file = new FileStream(fileName, FileMode.Open);
                using StreamReader reader = new StreamReader(file);
                string json = reader.ReadToEnd();
                return JsonSerializer.Deserialize<List<Task>>(json);
            }
            else
            {
                throw new ArgumentException();
            }
        }
        /// <summary>
        /// Сериализация listTasks в бинарнный файл  ,если listTasks равен нулю или строка fileName не заканчивается на ".bin", то возвращает ArgumentException 
        /// </summary>
        /// <param name="listTasks">лист, который сериализуется</param>
        /// <param name="fileName">имя файла , в который запишется listTasks </param>
        public static void SerializationToBinary(List<Task> listTasks, string fileName)
        {
            if (listTasks is not null && fileName.EndsWith(".bin"))
            {
                using var file = new FileStream(fileName, FileMode.Create);
                _binaryFormatter.Serialize(file, listTasks);
            }
            else
            {
                throw new ArgumentException();
            }
        }
        /// <summary>
        /// Десериализация из бинарного файла  в listTasks, если строка fileName не заканчивается на ".bin", то возвращает ArgumentException 
        /// </summary>
        /// <param name="fileName">имя файла , из которого десериализуем лист продуктов</param>
        public static List<Task> DeserializationFromBinary(string fileName)
        {
            if (fileName.EndsWith(".bin"))
            {
                using var file = new FileStream(fileName, FileMode.Open);
                return (List<Task>)_binaryFormatter.Deserialize(file);
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
