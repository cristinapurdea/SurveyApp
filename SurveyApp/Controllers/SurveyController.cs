using Microsoft.AspNetCore.Mvc;
using SurveyApp.Business.Interface;
using SurveyApp.Business.Models;

namespace SurveyApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyManager surveyManager;

        public SurveyController(ISurveyManager surveyManager)
        {
            this.surveyManager = surveyManager;
        }

        // GET: api/survey
        [HttpGet]
        public ActionResult<Survey> Get()
        {
            return Ok(surveyManager.LoadSurvey());
        }

        // GET api/survey/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "survey";
        }

        // POST api/survey
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/survey/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/survey/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
