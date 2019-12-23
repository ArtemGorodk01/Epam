using System;
using BLL.Interface.Entities.Accounts;
using BLL.Interface.Entities.Accounts.Abstract;
using BLL.Interface.Entities.BonusSystems;
using BLL.Interface.Entities.BonusSystems.Abstract;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    public static class AccountMapper
    {
        public static AccountDTO ToAccountDTO(this Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            return new AccountDTO
            {
                AccountType = account.GetType().ToString(),
                BonusSystemType = account.GetType().ToString(),
                IsClosed = account.IsClosed,
                Id = account.Id,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Balance = account.Balance,
                Cashback = 0,
                CashbackPercent = 0,
            };
        }

        public static AccountDTO ToAccountDTO(this CashbackAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            var dto = ((Account)account).ToAccountDTO();
            dto.CashbackPercent = account.CashbackPercent;
            dto.Cashback = account.Cashback;
            return dto;
        }

        public static Account ToAccount(this AccountDTO dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            BonusSystem bonusSystem = null;
            if (dto.BonusSystemType == typeof(BaseBonusSystem).ToString())
            {
                bonusSystem = new BaseBonusSystem();
            }
            else if (dto.BonusSystemType == typeof(GoldBonusSystem).ToString())
            {
                bonusSystem = new GoldBonusSystem();
            }
            else if (dto.BonusSystemType == typeof(GoldBonusSystem).ToString())
            {
                bonusSystem = new PlatinumBonusSystem();
            }
            else
            {
                throw new InvalidCastException("Can't cast AccountDTO to Account.");
            }

            Account account = null;
            if(dto.AccountType == typeof(DefaultAccount).ToString())
            {
                account = new DefaultAccount(dto.Id, bonusSystem, dto.IsClosed);
            }
            else if (dto.AccountType == typeof(CashbackAccount).ToString())
            {
                account = new CashbackAccount(dto.Id, bonusSystem, dto.Cashback, dto.IsClosed);
                ((CashbackAccount)account).CashbackPercent = dto.CashbackPercent;
            }
            else
            {
                throw new InvalidCastException("Can't cast AccountDTO to Account.");
            }

            account.FirstName = dto.FirstName;
            account.LastName = dto.LastName;
            account.Balance = dto.Balance;

            return account;
        }
    }
}
