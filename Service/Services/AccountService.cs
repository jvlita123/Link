using Data.Entities;
using Data.Repositories;

namespace Service.Services
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepository;

        public AccountService(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account? Get(int id)
        {
            Account? account = _accountRepository.GetById(id);

            return account;
        }

        public List<Account> GetAll()
        {
            List<Account> accounts = _accountRepository.GetAll().ToList();

            return accounts;
        }

        public Account Add(Account account)
        {
            Account? newAccount = _accountRepository.AddAndSaveChanges(account);

            return newAccount;
        }

        public void Update(Account account)
        {
            _accountRepository.UpdateAndSaveChanges(account);
        }


    }
}