using Data.Entities;
using Data.Repositories;

namespace Service
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepository;

        public AccountService(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public List<Account> GetAccounts()
        {
            List<Account>? accounts = _accountRepository.GetAll().ToList();

            return accounts;
        }
    }
}