using Newtonsoft.Json;
using System.IO;

namespace TaskManager.Storage.JSON
{
    public static class JsonUtil
    {
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
