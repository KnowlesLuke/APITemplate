using Application.DTOs.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Accounts
{
    public interface IAccountsReadService
    {
        public Task<IEnumerable<AccountResponse>> GetAccountsAsync();

        public Task<AccountResponse?> GetAccountByIdAsync(int accountId);

        public Task<IEnumerable<AccountResponse>> SearchAccountsAsync(string searchTerm);
    }
}
