namespace ACS.Utils.IO
{
    public interface ValueTokenFormatter<T>
    {
        string Format(T value);
    }
}
