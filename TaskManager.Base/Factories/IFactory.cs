namespace TaskManager.Base.Factories
{
    public interface IFactory<T>
    {
        /// <summary>
        /// Produces a new instance of T
        /// </summary>
        T Produce();
    }
}
