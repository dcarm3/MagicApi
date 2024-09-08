namespace MagicApi {
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;

    public class ScryfallService {
        private static readonly HttpClient _httpClient = new HttpClient();
        public async Task<JObject> SearchCardsAsync(string query) {
            var response = await _httpClient.GetAsync($"https://api.scryfall.com/cards/search?q={query}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JObject.Parse(content);
        }

        public async Task<JObject> GetCommandersAsync(string colors) {
            var response = await _httpClient.GetAsync($"https://api.scryfall.com/cards/search?q=type:legendary+type:creature+color:{colors}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JObject.Parse(content);
        }

        public async Task<JObject> GetDeckCardsAsync(string colors) {
            var response = await _httpClient.GetAsync($"https://api.scryfall.com/cards/search?q=color:{colors}&unique=prints");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JObject.Parse(content);
        }
    }

}
