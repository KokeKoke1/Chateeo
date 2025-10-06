using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
	public class ChatModel
	{
		public int Id { get; set; }
		public string Service { get; set; }
		public string ChatId { get; set; }
		public string SenderName { get; set; }
		public string Message { get; set; }
		public DateTime Date { get; set; }
		public TypeConversation Type { get; set; }

	}
	public enum TypeConversation
	{
		account, email
	}
}
