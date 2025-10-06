using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Chateeo.Services.Authentication;

namespace Chateeo.Services
{
    public class FetchService
    {
		private readonly AuthenticationService authenticationService;
		public FetchService(AuthenticationService authenticationService)
		{
			this.authenticationService = authenticationService;
		}

		public async Task<HttpResponseMessage> FetchServiceHandler(string url, object model) {
			var user = await authenticationService.GetAuthenticationAsync();
			var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
            HttpClient client = new HttpClient(handler);
			if (App.Token != null)
			{
				client.DefaultRequestHeaders.Add("X-Tunnel-Authorization", "tunnel " + App.Token);
			}
			client.DefaultRequestHeaders.Add("Authorization", "Bearer " + user.FirebaseToken);
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			return await client.PostAsJsonAsync("https://" + App.ServerAddress + "/" + url, model);
		}


		public string AsTimeAgo(DateTime dateTime)
		{
			TimeSpan timeSpan = DateTime.Now.Subtract(dateTime);

			return timeSpan.TotalSeconds switch
			{
				<= 60 => $"{timeSpan.Seconds} sekund temu",

				_ => timeSpan.TotalMinutes switch
				{
					<= 1 => "około minuty temu",
					< 60 => $"{timeSpan.Minutes} minut temu",
					_ => timeSpan.TotalHours switch
					{
						<= 1 => "godzine temu",
						< 24 => $"{timeSpan.Hours} godzin temu",
						_ => timeSpan.TotalDays switch
						{
							<= 1 => "wczoraj",
							<= 30 => $"{timeSpan.Days} dni temu",

							<= 60 => "okolo miesiaca temu",
							< 365 => $"{timeSpan.Days / 30} miesiecy temu",

							<= 365 * 2 => "rok temu",
							_ => $"{timeSpan.Days / 365} lata"
						}
					}
				}
			};
		}
	}
}
