using Newtonsoft.Json;
using System.IO;

namespace TaskManager.Storage.JSON
{
    public static class JsonUtil
    {
        /// <summary>
        /// Serializes some data into json and writes it to the file at the specified location.
        /// Generates a new file if it does not already exist. Uses Truncate mode.
        /// </summary>
        public static void SaveToFile<T>(string path, T data)
        {
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }

            if(!File.Exists(path))
            {
                File.Create(path).Close();
            }

            var file = File.Open(path, FileMode.Truncate);

            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.Write(JsonConvert.SerializeObject(data));
            }
        }

        /// <summary>
        /// Read all content of a file located at the specified path and try to deserialize its content.
        /// </summary>
        public static T ReadFromFile<T>(string path)
        {
            if(File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    return JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
                }
            }

            return default;
        }
    }
}
