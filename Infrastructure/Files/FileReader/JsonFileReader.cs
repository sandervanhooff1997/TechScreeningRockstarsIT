using System;
using System.IO;
using Newtonsoft.Json;

namespace Infrastructure.Files.FileReader
{
    /// <summary>
    /// Reads the given json file and deserializes to type T.
    /// </summary>
    public class JsonFileReader : IJsonFileReader
    {
        public T ReadAndDeserialize<T>(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentNullException(nameof(filePath));

            using StreamReader file = File.OpenText(filePath);
            JsonSerializer serializer = new JsonSerializer();
            
            return (T)serializer.Deserialize(file, typeof(T));
        }
    }
}