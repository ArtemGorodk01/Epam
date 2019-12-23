using System;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// DTO for account.
    /// </summary>
    public class AccountDTO
    {
        /// <summary>
        /// The type of account.
        /// </summary>
        public string AccountType { get; set; }

        /// <summary>
        /// The type of bonus system.
        /// </summary>
        public string BonusSystemType { get; set; }

        /// <summary>
        /// Is account closed.
        /// </summary>
        public bool IsClosed { get; set; }

        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Owner first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Owner last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Current balance.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Cashback percent.
        /// </summary>
        public double CashbackPercent { get; set; }

        /// <summary>
        /// Cashback.
        /// </summary>
        public decimal Cashback { get; set; }
    }
}
