namespace TaskManager.Data
{
    public interface IData
    {
        long Id { get; }

        /// <summary>
        /// Clones this data object but assigns a new id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IData CloneUsingId(long id);
    }
}
