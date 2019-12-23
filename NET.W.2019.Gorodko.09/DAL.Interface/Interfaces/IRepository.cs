using System.Collections.Generic;
using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    /// <summary>
    /// Provides working with repository.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Saves all records.
        /// </summary>
        /// <param name="accounts">Collection with all accounts to save.</param>
        void Save(IEnumerable<AccountDTO> accounts);

        /// <summary>
        /// Returns all records in collection.
        /// </summary>
        /// <returns>All records in collection.</returns>
        IEnumerable<AccountDTO> Load();
    }
}
