using System;
using Task2.Domain;
using Task2.Domain.BonusSystem;
using Task2.Service;
using Task2.Storage;

namespace Task2.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new BankService(FileStorage.Instance);
            var account = new BankAccount(1, "first name 1", "last name 1",
                1, typeof(DefaultBonusSystem), AccountType.Gold, true);

            service.AddAccount(account);

            service.Save();

            service.RemoveAccount(account);

            service.Load();

            Console.WriteLine(service[0].FirstName);
            Console.WriteLine(service[0].BonusSystemType.ToString());
            Console.WriteLine("----------------------------------");

            var account1 = new BankAccount(2, "first name 2", "last name 2",
               2, typeof(DefaultBonusSystem), AccountType.Platinum, true);

            service.AddAccount(account1);
            service.Save();

            Console.WriteLine(service[1].BonusPoints);
            Console.WriteLine(service[1].Balance);
            Console.WriteLine("----------------------------------");

            service[1].Deposit(12);

            Console.WriteLine(service[1].BonusPoints);
            Console.WriteLine(service[1].Balance);
            Console.WriteLine("----------------------------------");

            service.Save();
        }
    }
}
