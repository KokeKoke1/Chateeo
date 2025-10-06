using Chateeo.API.Infrastructure;
using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Chateeo.API.Services
{
	public class ChatsService
	{
		private readonly AppDbContext appDbContext;
		private readonly IConfiguration config;
		public ChatsService(AppDbContext appDbContext, IConfiguration config)
		{
			this.appDbContext = appDbContext;
			this.config = config;
		}
		public List<Chats> GetAllFromAccount()
		{
			List<Chats> chats = new List<Chats>();
			var chatsIds = appDbContext.Chats.Select(x => x.ChatId).Distinct().ToList();
			foreach (var id in chatsIds)
			{
				var chat = appDbContext.Chats.Where(x => x.ChatId ==  id).FirstOrDefault();
				chats.Add(new Chats()
				{
					ChatId = chat.ChatId,
					Name = chat.SenderName,
					Service = chat.Service,
				});

			}
			return chats;
		}
		
	}
}
