namespace Data.Parsing.Converting.Abstract
{
    /// <summary>
    /// Provaides converting from string to data with type T.
    /// </summary>
    /// <typeparam name="T">Type of data.</typeparam>
    public interface IConverter<T>
    {
        /// <summary>
        /// Converts string into data with type T.
        /// </summary>
        /// <param name="line">Source string.</param>
        /// <returns>Data with type T.</returns>
        T Convert(string line);
    }
}
