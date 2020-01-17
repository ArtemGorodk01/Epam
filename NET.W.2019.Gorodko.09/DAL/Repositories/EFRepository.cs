using System;
using System.Collections.Generic;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    public class EFRepository : IRepository
    {
        public IEnumerable<AccountDTO> Load()
        {
            throw new NotImplementedException();
        }

        public void Save(IEnumerable<AccountDTO> accounts)
        {
            throw new NotImplementedException();
        }
    }
}
