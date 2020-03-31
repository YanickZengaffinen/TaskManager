namespace TaskManager.Data
{
    public interface IData
    {
        /// <summary>
        /// The unique id of the data element
        /// </summary>
        long Id { get; }

        /// <summary>
        /// Clones this data object but assigns a new id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IData CloneUsingId(long id);
    }
}
