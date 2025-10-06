using Chateeo.Services.Authentication;

namespace Chateeo.Views
{
	public partial class AuthenticationPage : ContentPage
	{
        private readonly AuthenticationService _authenticationService;
        public AuthenticationPage(AuthenticationService authenticationService) { 
            InitializeComponent();
            _authenticationService = authenticationService;
        }
        protected override async void OnAppearing()
		{
            base.OnAppearing();
            if (await _authenticationService.IsAuthenticated())
            {
                App.Current.MainPage = new NavigationPage(new MainPage());
            } 
        }
        
    }
}
