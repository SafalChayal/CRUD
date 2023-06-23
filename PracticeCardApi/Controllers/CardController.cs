using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeCardApi.Data;
using PracticeCardApi.Models;

namespace PracticeCardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly CardDbContext cardDbContext;

        public CardController(CardDbContext cardDbContext) {
            this.cardDbContext= cardDbContext;
        }
        //GetAll Cards
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await cardDbContext.cards.ToListAsync();
            return Ok(res);

        }

        [HttpGet("id")]
        [ActionName("GetOne")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            
            var res = await cardDbContext.cards.FirstOrDefaultAsync(x => x.Id == id);
            if(res != null)
            {
                return Ok(res);
            }
            return NotFound("Card not found");

        }

        //Adding a card
        [HttpPost]
        public async Task<IActionResult> AddCard(Card card)
        {
            card.Id = Guid.NewGuid();
            await cardDbContext.cards.AddAsync(card);
            cardDbContext.SaveChanges();
            return CreatedAtAction(nameof(GetOne), card.Id, card);


        }

        //Updating a card
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id,Card card)
        {
            var res = await cardDbContext.cards.FirstOrDefaultAsync(x => x.Id == id);
            if(res != null)
            {
                res.CardholderName = card.CardholderNumber;
                res.CardholderNumber = card.CardholderNumber;
                res.ExpiryMonth = card.ExpiryMonth;
                res.ExpiryYear = card.ExpiryYear;
                res.CVV = card.CVV;
                await cardDbContext.SaveChangesAsync();

                return Ok(res);
            }
            else
            {
                return NotFound("Please enter the valid Id, that is in the database.");
            }



        }

        //Delete a card
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var res = await cardDbContext.cards.FirstOrDefaultAsync(x => x.Id == id);
            if (res != null)
            {

                cardDbContext.Remove(res);
                await cardDbContext.SaveChangesAsync();
                return Ok(res);
            }
            else
            {
                return NotFound("Please enter the valid Id, that is in the database.");
            }



        }



    }

}
