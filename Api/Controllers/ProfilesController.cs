using AutoMapper;
using Data.Dto_s.User;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Service.Models.Profiles;

namespace Api.Controllers
{
    [Route("Profile")]
    public class ProfilesController : Controller
    {
        private RelationUserRepository _relationUserRepository;
        private RelationUserService _relationUserService;
        private RelationService _relationService;
        private readonly IMapper _mapper;

        public ProfilesController(RelationUserRepository relationUserRepository, RelationUserService relationUserService, IMapper
        mapper, RelationService relationService)
        {
            _relationUserRepository = relationUserRepository;
            _relationUserService = relationUserService;
            _relationService = relationService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetProfiles(GetProfileViewModel profileViewModel)
        {
            var userId = Convert.ToInt32(this.User.Identity.Name);
            var relId = _relationService.GetByName("Love").Id;
            var profiles = _relationUserRepository.GetUserWithProfiles(userId);
            var pro = _mapper.Map<IEnumerable<GetUserDto>>(profiles);
            _relationUserService.GetProfile(userId, relId);

            return View(profileViewModel);
        }



    }
}
