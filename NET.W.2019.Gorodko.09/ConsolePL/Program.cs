using System;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();
        }

        static void Main(string[] args)
        {
            IAccountService service = resolver.Get<IAccountService>();

            service.CreateAccount(AccountType.CashbackAccount, BonusSystemType.Base);
            service.CreateAccount(AccountType.DefaultAccount, BonusSystemType.Platinum);
            service.CreateAccount(AccountType.DefaultAccount, BonusSystemType.Gold);
            service.CreateAccount(AccountType.CashbackAccount, BonusSystemType.Base);

            var creditNumbers = service.Accounts.Select(acc => acc.Id).ToArray();

            foreach (var t in creditNumbers)
            {
                service.Deposit(t, 100);
            }

            foreach (var item in service.Accounts)
            {
                Console.WriteLine(item.Balance);
            }

            foreach (var t in creditNumbers)
            {
                service.Withdraw(t, 10);
            }

            foreach (var item in service.Accounts)
            {
                Console.WriteLine(item.Balance);
            }
        }
    }
}