using Chateeo.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chateeo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatsController : ControllerBase
    {
        private readonly ChatsService chatsService;
        public ChatsController(ChatsService chatsService)
		{
			this.chatsService = chatsService;
		}


		[Authorize]
		[HttpPost("GetAccountsChats")]
		public async Task<IActionResult> AccountsChats()
        {
            var result = chatsService.GetAllFromAccount();
			return Ok(result);
		}

	}
}
