
using Firebase.Auth;
using Chateeo.Models;
using Newtonsoft.Json;

namespace Chateeo.Services.Authentication
{
    public class AuthenticationService
    {
        public string webApiKey = "AIzaSyDyjL6is775nFBJaELt1RL9WGRNY5pkY7Y";
		public async Task Init()
        { 
			var auth = await GetAuthenticationAsync();
            if (auth != null)
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
                var newAuth = await authProvider.RefreshAuthAsync(auth);
                var serializedContent = JsonConvert.SerializeObject(newAuth);
                await SecureStorage.Default.SetAsync("UserSession", serializedContent);
            }
            //var device = App.DeviceToken;
            //FetchService fetchService = new FetchService(this);
			//HttpResponseMessage result = await fetchService.FetchServiceHandler("Users/AddDevice", device);
		}
		public async Task<bool> IsAuthenticated()
        {
            var x = await SecureStorage.Default.GetAsync("UserSession");
            return (x != null);
        }
        public async Task<FirebaseAuth> GetAuthenticationAsync()
        {
            if (await SecureStorage.Default.GetAsync("UserSession") != null)
            {
                return JsonConvert.DeserializeObject<FirebaseAuth>(await SecureStorage.Default.GetAsync("UserSession"));
            } else
            {
                return null;
            }
        }
        public async Task<bool> AuthenticationLoginAsync(LoginModel model)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(model.Email, model.Password);
                var content = await auth.GetFreshAuthAsync();
                var serializedContent = JsonConvert.SerializeObject(content);
                await SecureStorage.Default.SetAsync("UserSession", serializedContent);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task AuthenticationLogoutAsync()
        {
            SecureStorage.Default.Remove("UserSession");
        }

    }
}
