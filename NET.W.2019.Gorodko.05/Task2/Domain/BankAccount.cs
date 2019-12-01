using System;
using Task2.Domain.BonusSystem.Abstract;

namespace Task2.Domain
{
    /// <summary>
    /// Defines state and behavior of bank account
    /// </summary>
    public class BankAccount
    {
        #region Private fields

        /// <summary>
        /// First name of account owner
        /// </summary>
        private string _firstName;

        /// <summary>
        /// Last nam of account owner
        /// </summary>
        private string _lastName;

        /// <summary>
        /// Bonus system
        /// </summary>
        private BonusSystemBase _bonusSystem;

        /// <summary>
        /// Type of bonus system
        /// </summary>
        private Type _bonusSystemType;

        #endregion

        /// <summary>
        /// Initials new bank account
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="balance"></param>
        /// <param name="bonusSystem"></param>
        /// <param name="accountType"></param>
        public BankAccount(int id, string firstName, string lastName, 
               decimal balance, Type bonusSystemType, AccountType accountType = AccountType.Base, bool isActive = true)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
            BonusSystemType = bonusSystemType;
            AccountType = accountType;
            IsActive = isActive;

            var constructor = bonusSystemType.GetConstructor(new Type[] { typeof(AccountType), typeof(decimal) });
            _bonusSystem = constructor.Invoke(new object[] { accountType, balance }) as BonusSystemBase;

            if (_bonusSystem == null)
            {
                throw new InvalidOperationException();
            }
        }

        #region Properties

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Type of account
        /// </summary>
        public AccountType AccountType { get; private set; }

        /// <summary>
        /// Is account active
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// Current balance
        /// </summary>
        public decimal Balance { get; private set; }

        /// <summary>
        /// First name of account owner
        /// </summary>
        public string FirstName
        {
            get => _firstName;
            private set => _firstName = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Last name of account owner
        /// </summary>
        public string LastName
        {
            get => _lastName;
            private set => _lastName = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Type of bonus system
        /// </summary>
        public Type BonusSystemType
        {
            get => _bonusSystemType;
            private set => _bonusSystemType = value ??
                throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Bonus points
        /// </summary>
        public int BonusPoints
        {
            get => _bonusSystem.Points;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Closes account
        /// </summary>
        public void CloseAccount()
        {
            IsActive = false;
        }

        /// <summary>
        /// Adds money to account
        /// </summary>
        /// <param name="deposit">deposit</param>
        public void Deposit(decimal deposit)
        {
            Balance += deposit;
            _bonusSystem.OnDeposit(deposit);
        }

        /// <summary>
        /// Takes money from account
        /// </summary>
        /// <param name="withdraw">withdraw</param>
        public void Withdraw(decimal withdraw)
        {
            if (withdraw > Balance)
            {
                throw new ArgumentException("Withdraw cannot be larger than balance");
            }

            Balance -= withdraw;
            _bonusSystem.OnWithdraw(withdraw);
        }

        #endregion

        #region Object overrides

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (object.ReferenceEquals(obj, this))
            {
                return true;
            }

            if (!(obj is BankAccount account))
            {
                return false;
            }

            if (account.Id == this.Id)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }

        #endregion
    }
}
