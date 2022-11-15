using Data.Entities;
using Data.Repositories;

namespace Service.Services
{
    public class StatusService
    {
        private readonly StatusRepository _statusRepository;

        public StatusService(StatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public List<Status> GetAll()
        {
            List<Status> statuses = _statusRepository.GetAll().ToList();

            return statuses;
        }
    }
}