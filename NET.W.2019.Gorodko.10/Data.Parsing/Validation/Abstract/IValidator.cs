namespace Data.Parsing.Validation.Abstract
{
    /// <summary>
    /// Provides validation of the string.
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Validates the string.
        /// </summary>
        /// <param name="line">Source string.</param>
        /// <returns>Is string valid.</returns>
        bool Validate(string line);
    }
}
