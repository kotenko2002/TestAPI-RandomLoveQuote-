using System;
using System.Net.Http;
using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI.Services
{
    public class LoveQuoteServices : ILoveQuoteServices
    {
		public async Task<LoveQuote> GetRandomLoveQuote()
		{
			start:
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://love-quote.p.rapidapi.com/lovequote"),
				Headers =
				{
					{ "X-RapidAPI-Key", "2e4099ea3bmshc981a9448410147p1223dajsn750965188f7e" },
					{ "X-RapidAPI-Host", "love-quote.p.rapidapi.com" },
				},
			};

			using (var response = await Helper.ApiClient.SendAsync(request))
			{
				if (response.IsSuccessStatusCode)
				{
					var result = await response.Content.ReadAsAsync<LoveQuote>();

					if(result.title == null)
                    {
						goto start;
					}

					return result;
				}
				else
				{
					throw new Exception(response.ReasonPhrase);
				}
			}
		}
	}
}
