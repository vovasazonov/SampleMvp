namespace Core.Content
{
    public interface IContentGenerator<out T>
    {
        IDisposableContent<T> Generate();
    }
}