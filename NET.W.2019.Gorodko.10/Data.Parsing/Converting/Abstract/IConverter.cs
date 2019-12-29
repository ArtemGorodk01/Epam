namespace Data.Parsing.Converting.Abstract
{
    public interface IConverter<T>
    {
        T Convert(string line);
    }
}
