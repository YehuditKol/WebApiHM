using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ourProject.FileService
{
    public class FileService : Ifile
    {
        public string FileName { get; set; }
        private string FilePath { get; set; }

        public FileService()
        {
            //this.FilePath = Path.Combine(Environment.CurrentDirectory, "files", "myFile.json");
            this.FilePath = Path.Combine(Environment.CurrentDirectory, "files");
        }

        public void WriteMessage(string message)
        {

            //if (File.Exists(Path.Combine(FilePath,FileName)))
            {
                File.WriteAllText(Path.Combine(FilePath, FileName), $" {message}");
            }
        }
        public void AddItem<T>(T item)
        {
            string json = File.ReadAllText(Path.Combine(FilePath, FileName));
            var TList = JsonSerializer.Deserialize<List<T>>(json);
            TList.Add(item);
            json = JsonSerializer.Serialize(TList);
            WriteMessage(json);
        }
        public List<T> Get<T>()
        {
            string json = File.ReadAllText(Path.Combine(FilePath, FileName));
            var TList = JsonSerializer.Deserialize<List<T>>(json);
            if (TList != null)
                return TList;
            return default(List<T>);
        }
        public void Update<T>(List<T> list)
        {
            string json = JsonSerializer.Serialize(list);
            WriteMessage(json);
        }


    }
}