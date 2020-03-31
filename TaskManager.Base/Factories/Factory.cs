using System;

namespace TaskManager.Base.Factories
{
    public class Factory<T> : IFactory<T>
    {
        protected Func<T> creator;

        public Factory(Func<T> creator)
        {
            this.creator = creator;
        }

        public T Produce()
        {
            return creator();
        }
    }
}
