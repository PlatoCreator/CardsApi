using CardsApi.Models;
using CardsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardsController : ControllerBase
    {
        private readonly CardsService _cardsService;

        public CardsController(CardsService cardsService) =>
            _cardsService = cardsService;

        [HttpGet]
        public async Task<List<Card>> Get() =>
            await _cardsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Card>> Get(string id)
        {
            var card = await _cardsService.GetAsync(id);

            if (card is null)
            {
                return NotFound();
            }

            return card;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Card newCard)
        {
            await _cardsService.CreateAsync(newCard);
            return CreatedAtAction(nameof(Get), new { id = newCard.Id }, newCard);
        }

    }
}
