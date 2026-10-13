using Microsoft.AspNetCore.Mvc;
using Karpaty.API.Models;

namespace Karpaty.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
      private static readonly List<Feedback> _feedbacks= new List<Feedback>();

        //public FeedbackController()
        //{
        //    _feedbacks = new List<Feedback>(); // Бурмалда якась
        //}

        [HttpPost]
        public IActionResult SubmitFeedback([FromBody] Feedback feedback)
        {
            if (feedback == null || string.IsNullOrEmpty(feedback.UserName) || string.IsNullOrEmpty(feedback.Email) || string.IsNullOrEmpty(feedback.Message))
            {
                return BadRequest("Invalid feedback data.");
            }
            feedback.Id = _feedbacks.Count + 1;
            feedback.CreatedAt = DateTime.UtcNow; // тут якось перетворював Артьом в інтове значення походу, я DateTime зробив @Назар
            _feedbacks.Add(feedback);

            return Ok("Feedback submitted successfully.");
        }

        [HttpGet]
        public IActionResult GetAllFeedbacks()
        {
            return Ok(_feedbacks);
        }
    }
}