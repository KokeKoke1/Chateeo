using Chateeo.Services.Authentication;
using Chateeo.Views;
using SharedLibrary.Models;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Chateeo
{
    public partial class App : Application
    {
        public static string Token { get; set; }
        public static string ServerAddress { get; set; }
        public static Chats SelectedChat { get; set; }
        public static string DeviceToken { get; set; }
        private readonly AuthenticationService authenticationService;

        public IPAddress IP;
        public App(AuthenticationService authenticationService)
        {
            InitializeComponent();
            this.authenticationService = authenticationService;
            MainPage = new LoadingPage();
            if (IPAddress.TryParse("127.0.0.1", out IP))
            {
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    //s.Connect("192.168.101.100", 7242);
                    ServerAddress = "chateeo.neteeo.com";//"rd1rzddt-7199.euw.devtunnels.ms";
					//Token = "eyJhbGciOiJFUzI1NiIsImtpZCI6IjNGRkVFNzgyNzFBODE1MTc1MzYyNEVCODNCMDBBODIyMkRDODYxRDYiLCJ0eXAiOiJKV1QifQ.eyJjbHVzdGVySWQiOiJldXciLCJ0dW5uZWxJZCI6InJkMXJ6ZGR0Iiwic2NwIjoiY29ubmVjdCIsImV4cCI6MTcwODQ0NTQ0NiwiaXNzIjoiaHR0cHM6Ly90dW5uZWxzLmFwaS52aXN1YWxzdHVkaW8uY29tLyIsIm5iZiI6MTcwODM1ODE0Nn0.Wr1AUCFfEG_FhmD_qYneVIzBArjDtxSz7pGEREw2ZUYQ6H_dNWQSWvFRO8kbgbvRKDS9LKr7jM2HYTrAug8PbQ";
                }
                catch
                {
                    ServerAddress = "chateeo.neteeo.com";
                }
                //if (Preferences.ContainsKey("DeviceToken"))
                //{
                //    DeviceToken = Preferences.Get("DeviceToken", "");
                //}
                Start();
            }
        }
        private async void Start()
        {
            try
            {
                //Ping pingSender = new Ping();
                //PingReply reply = await pingSender.SendPingAsync(ServerAddress);

                await authenticationService.Init();
                if (!await authenticationService.IsAuthenticated())
                {
                    MainPage = new AuthenticationPage(authenticationService);
                }
                else
                {
                    MainPage = new NavigationPage(new MainPage());
                }
            }
            catch
            {

            }
        }
    }
}
