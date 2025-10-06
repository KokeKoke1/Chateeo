using Chateeo.API.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chateeo.API.Services
{
	public class ChatHub : Hub
	{
		private readonly AppDbContext appDbContext;
		public ChatHub(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}
		public override async Task OnConnectedAsync()
		{
			var httpContext = Context.GetHttpContext();
			var chatId = httpContext.Request.Query["chatId"].ToString();
			await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
			var history = appDbContext.Chats.Where(c => c.ChatId == chatId).ToList();
			await Clients.Client(Context.ConnectionId).SendAsync("History", history);
			await base.OnConnectedAsync();
		}
		public async Task SendMessage(string message, string chatId, string service, string userName, string email = null)
		{
			var typeCon = TypeConversation.account;
			if (email != null) typeCon = TypeConversation.email;
			var entity = appDbContext.Chats.Add(new ChatModel()
			{
				ChatId = chatId,
				SenderName = userName,
				Message = message,
				Date = DateTime.Now,
				Service = service,
				Type = typeCon
			}).Entity;
			await appDbContext.SaveChangesAsync();
			await Clients.Group(chatId).SendAsync("ReciveMessage", entity);
		}
	}
}
