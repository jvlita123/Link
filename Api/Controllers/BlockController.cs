using Data.Dto_s.User;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace Api.Controllers
{
    public class BlockController : Controller
    {
        private BlockService _blockService;
        private UserService _userService;
        private AccountService _accountService;

        public BlockController(BlockService blockService, UserService userService, AccountService accountService)
        {
            _blockService = blockService;
            _userService = userService;
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            List<Block> blocks = _blockService.GetAll();

            return View(blocks);
        }

        [HttpGet]
        [Route("/NewBlock")]
        public IActionResult AddNewBlock()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [Route("/NewBlock")]
        public IActionResult AddNewBlock(int blockedUserId)
        {
            Account account = _accountService.GetByEmail(HttpContext.User.Identity.Name);
            User? user = _userService.GetByAccId(account.Id);

            var newBlock = _blockService.AddNewBlock(user.Id, blockedUserId);

            return View();
        }

        [HttpGet]
        [Route("/Unblock")]
        public IActionResult Unblock()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [Route("/Unblock")]
        public IActionResult Unblock(int blockedUserId)
        {
            Account account = _accountService.GetByEmail(HttpContext.User.Identity.Name);
            User? user = _userService.GetByAccId(account.Id);

            _blockService.Unblock(user.Id, blockedUserId);

            return View();
        }

        [HttpGet]
        [Authorize]
        [Route("/BlockList")]
        public IActionResult GetUserBlocksList()
        {
            Account account = _accountService.GetByEmail(HttpContext.User.Identity.Name);
            MyUserDto? user = _userService.MyUser(account.Id);
            List<Block?> blocks = _blockService.GetUserBlocksList(user.Id);

            return View(blocks);
        }
    }
}
