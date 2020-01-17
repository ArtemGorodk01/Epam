using System.Data.Entity;
using DAL.Interface.DTO;

namespace DAL
{
    public class AccountContext : DbContext
    {
        public DbSet<AccountDTO> Accounts { get; set; }
    }
}
