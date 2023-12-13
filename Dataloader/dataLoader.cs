namespace Dataloader
{
    public abstract class dataLoader<T> where T : class
    {
        public virtual void Loader(T obj)
        {
        }

        public virtual void Loader(T obj1, string obj2)
        {
        }
    }
}