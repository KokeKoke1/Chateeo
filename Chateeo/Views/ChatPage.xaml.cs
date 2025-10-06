using Chateeo.Services.Authentication;
using Microsoft.AspNetCore.Components;
using SharedLibrary.Models;

namespace Chateeo.Views
{
	public partial class ChatPage : ContentPage
	{
        private readonly AuthenticationService _authenticationService;
        
        public string ChatId;
        public ChatPage(AuthenticationService authenticationService, Chats chats) { 
            InitializeComponent();
            _authenticationService = authenticationService;
            Title = chats.Name;
            App.SelectedChat = chats;
		}
		protected override async void OnAppearing()
		{
            base.OnAppearing();
        }
    }
}
