namespace _2048.Common
{
    public interface IConverter
    {
        string Serialize<T>(T item);
        T Deserialize<T>(string data);
    }
}
