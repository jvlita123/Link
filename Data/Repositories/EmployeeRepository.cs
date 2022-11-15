using Api.Data;
using Data.Entities;

namespace Data.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        private DataContext _dataContext;

        public EmployeeRepository(DataContext context) : base(context)
        {
            _dataContext = context;
        }
    }
}