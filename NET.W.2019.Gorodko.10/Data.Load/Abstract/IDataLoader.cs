namespace Data.Load.Abstract
{
    /// <summary>
    /// Provides loading string from out source.
    /// </summary>
    public interface IDataLoader
    {
        /// <summary>
        /// Loads data.
        /// </summary>
        /// <returns>String with data.</returns>
        string Load();
    }
}
