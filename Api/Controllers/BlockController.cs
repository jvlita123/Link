using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace Api.Controllers
{
    public class BlockController : Controller
    {
        private BlockService _blockService;

        public BlockController(BlockService blockService)
        {
            _blockService = blockService;
        }
        public IActionResult Index()
        {
            List<Block> blocks = _blockService.GetAll();

            return View(blocks);
        }

        [HttpPost]
        [Route("/NewBlock")]
        public IActionResult newBlock(User usr, User usrToBlock)//zmienić usr na już zalogowanego usera
        {
           
                var newBlock = new Block()
                {
                    UserId = usr.Id,
                    BlockedUserId = usrToBlock.Id,
                    BlockedUser = usrToBlock,
                    User = usr
                };

                usr.Blocks.Add(newBlock);

                _blockService.Update(newBlock);
                _blockService.Add(newBlock);
            

            return View();
        }
    }
}
