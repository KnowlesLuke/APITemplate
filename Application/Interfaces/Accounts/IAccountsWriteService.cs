using Application.DTOs.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Accounts
{
    public interface IAccountsWriteService
    {
        public Task<AccountResponse> CreateAccountAsync(AccountRequest request);

        public Task<AccountResponse> UpdateAccountAsync(int accountId, AccountPut request);

        public Task DeleteAccountAsync(int accountId, string DeletedBy);
    }
}
