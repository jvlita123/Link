using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace Api.Controllers
{
    public class MessageController : Controller
    {
        private MessageService _messageService;
        private UserService _userService;
        private AccountService _accountService;

        public MessageController(MessageService messageService, UserService userService, AccountService accountService)
        {
            _messageService = messageService;
            _userService = userService;
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            List<Message> messages = _messageService.GetAll();

            return View(messages);
        }

        [HttpGet]
        [Route("/SendMessage")]
        public IActionResult SendMessageConversation(int secondUserId, string text)
        {

            Account account = _accountService.GetByEmail(HttpContext.User.Identity.Name);
            User? user = _userService.GetByAccId(account.Id);

            _messageService.SendMessage(user.Id, secondUserId, text);
            return View();
                }

        [HttpPost]
        [Authorize]
        [Route("/SendMessage")]
        public IActionResult SendMessage(int secondUserId, string text)
        {
            Account account = _accountService.GetByEmail(HttpContext.User.Identity.Name);
            User? user = _userService.GetByAccId(account.Id);

            _messageService.SendMessage(user.Id, secondUserId, text);

            //return View();
            return RedirectToAction("GetConversation", new { id = secondUserId });

        }

        [HttpGet]
        [Authorize]
        [Route("/ReceivedMessages")]
        public IActionResult GetReceivedMessages()
        {
            Account account = _accountService.GetByEmail(HttpContext.User.Identity.Name);
            User? user = _userService.GetByAccId(account.Id);
            List<Message> messages = _messageService.GetUserMessages(user.Id);

            return View(messages);
        }

        [HttpGet]
        [Authorize]
        [Route("/SentMessages")]
        public IActionResult GetSentMessages()
        {
            Account account = _accountService.GetByEmail(HttpContext.User.Identity.Name);
            User user = _userService.GetByAccId(account.Id);
            List<Message> messages = _messageService.GetSentMessages(user.Id);

            return View(messages);
        }

        [HttpGet]
        [Authorize]
        [Route("/UserConversations")]
        public IActionResult GetUserConversations()
        {
            Account account = _accountService.GetByEmail(HttpContext.User.Identity.Name);
            User user = _userService.GetByAccId(account.Id);
            List<User> userConversation = _messageService.GetUserConversations(user.Id);
            return View(userConversation);
        }

        [HttpGet]
        [Authorize]
        [Route("/GetConversation")]
        public IActionResult GetConversation(int id)
        {
            Account account = _accountService.GetByEmail(HttpContext.User.Identity.Name);
            User user = _userService.GetByAccId(account.Id);

            List<Message> conversation = new List<Message>();
            conversation = _messageService.GetConversation(user.Id, id);

            return View(conversation);
        }
    }
}
