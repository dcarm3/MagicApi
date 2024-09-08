using MagicApi;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class DeckController : ControllerBase {
    private readonly ScryfallService _scryfallService;

    public DeckController(ScryfallService scryfallService) {
        _scryfallService = scryfallService;
    }

    [HttpGet]
    [Route("get-commander/{colors}")]
    public async Task<IActionResult> GetCommander(string colors) {
        var commander = await _scryfallService.GetCommandersAsync(colors);
        return Ok(commander);
    }

    [HttpGet]
    [Route("get-deck/{colors}")]
    public async Task<IActionResult> GetDeck(string colors) {
        var deck = await _scryfallService.GetDeckCardsAsync(colors);
        return Ok(deck);
    }

    [HttpPost]
    [Route("save-deck")]
    public IActionResult SaveDeck([FromBody] JObject deck) {
        System.IO.File.WriteAllText("deck.json", deck.ToString());
        return Ok("Deck salvo com sucesso.");
    }
}
