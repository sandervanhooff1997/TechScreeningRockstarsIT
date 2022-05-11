namespace Infrastructure.Files.FileReader
{
    public interface IJsonFileReader
    {
        T ReadAndDeserialize<T>(string filePath);
    }
}