using Microsoft.AspNetCore.Mvc;
using Karpaty.API.Models;

namespace Karpaty.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaceController : ControllerBase
    {
        private static readonly List<Place> places = new List<Place>
        {
            new Place
            {
                Id = 1,
                Title = "Озеро Синевир",
                Description = "Найбільше та найглибше високогірне озеро України.",
                Category = PlaceCategory.Озеро,
                ImageUrl = "https://example.com/synevyr.jpg",
                Rating = 4.9
            },
            new Place
            {
                Id = 2,
                Title = "Водоспад Шипіт",
                Description = "Мальовничий водоспад на північних схилах гірського масиву Полонина Боржава.",
                Category = PlaceCategory.Водоспад,
                ImageUrl = "https://example.com/shypit.jpg",
                Rating = 4.8
            },
            new Place
            {
                Id = 3,
                Title = "Гора Пікуй",
                Description = "Найвища вершина Львівської області.",
                Category = PlaceCategory.Гора,
                ImageUrl = "https://example.com/pikuy.jpg",
                Rating = 4.7
            }
        };

        
        [HttpGet]
        public ActionResult<IEnumerable<Place>> GetPlaces()
        {
            return Ok(places);
        }

        [HttpGet("{id}")]
        public ActionResult<Place> GetPlace(int id)
        {
            var place = places.FirstOrDefault(p => p.Id == id);

            if (place == null)
            {
                return NotFound(new { Message = $"Місце з Id = {id} не знайдено." });
            }

            return Ok(place);
        }
    }
}
