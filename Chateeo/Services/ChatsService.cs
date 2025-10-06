using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Chateeo.Services
{
	public class ChatsService
	{
		private readonly FetchService _fetchService;
		public ChatsService(FetchService fetchService)
		{
			_fetchService = fetchService;
		}
		public async Task<Chats[]> GetChats()
		{
			var result = await _fetchService.FetchServiceHandler("Chats/GetAccountsChats", null);
			var chats = await result.Content.ReadFromJsonAsync<Chats[]>();
            return chats;
		}
	}
}
