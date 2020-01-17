using System;
using System.Collections.Generic;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    /// <inheritdoc/>
    public class EFRepository : IRepository
    {
        private readonly AccountContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EFRepository"/> class.
        /// </summary>
        /// <param name="context"></param>
        public EFRepository(AccountContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public IEnumerable<AccountDTO> Load()
        {
            return this.context.Accounts;
        }

        /// <inheritdoc/>
        public void Save(IEnumerable<AccountDTO> accounts)
        {
            if (accounts == null)
            {
                throw new ArgumentNullException(nameof(accounts));
            }

            this.context.Accounts.RemoveRange(this.context.Accounts);
            this.context.Accounts.AddRange(accounts);
            this.context.SaveChanges();
        }
    }
}
