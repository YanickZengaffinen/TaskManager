namespace TaskManager.Base.Factories
{
    public interface IFactory { }

    public interface IFactory<T> : IFactory
    {
        /// <summary>
        /// Produces a new instance of T
        /// </summary>
        T Produce();
    }
}
