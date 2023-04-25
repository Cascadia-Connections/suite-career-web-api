using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuiteCareers.Models;
using SuiteCareers.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SuiteCareers.Controllers
{
    [Route("api/suitecareerapi")]
    public class SuiteCareerAPIController : Controller
    {
        private SuiteCareersDbContext _db;
        public SuiteCareerAPIController(SuiteCareersDbContext db) { _db = db; }

        /**
         * CREATE: Adds new info to collections
         * uses a POST verb with the URL pattern "api/model"
         */
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            //Tests for an invalid ModelState -> return BadRequest(); 
            if (!ModelState.IsValid) { return BadRequest(); }
            //Makes changes to DbContext, save to Database -> return Accepted(user);
            _db.Add(user);
            _db.SaveChanges();
            return Accepted(user);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Interview interview)
        {
            //Tests for an invalid ModelState -> return BadRequest(); 
            if (!ModelState.IsValid) { return BadRequest(); }
            //Makes changes to DbContext, save to Database -> return Accepted(interview);
            _db.Add(interview);
            _db.SaveChanges();
            return Accepted(interview);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Question question)
        {
            //Tests for an invalid ModelState -> return BadRequest(); 
            if (!ModelState.IsValid) { return BadRequest(); }
            //Makes changes to DbContext, save to Database -> return Accepted(question);
            _db.Add(question);
            _db.SaveChanges();
            return Accepted(question);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Session session)
        {
            //Tests for an invalid ModelState -> return BadRequest(); 
            if (!ModelState.IsValid) { return BadRequest(); }
            //Makes changes to DbContext, save to Database -> return Accepted(session);
            _db.Add(session);
            _db.SaveChanges();
            return Accepted(session);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Response response)
        {
            //Tests for an invalid ModelState -> return BadRequest(); 
            if (!ModelState.IsValid) { return BadRequest(); }
            //Makes changes to DbContext, save to Database -> return Accepted(response);
            _db.Add(response);
            _db.SaveChanges();
            return Accepted(response);

        }

        [HttpPost]
        public IActionResult Post([FromBody] UserDescription userDescription)
        {
            //Tests for an invalid ModelState -> return BadRequest(); 
            if (!ModelState.IsValid) { return BadRequest(); }
            //Makes changes to DbContext, save to Database -> return Accepted(userDescription);
            _db.Add(userDescription);
            _db.SaveChanges();
            return Accepted(userDescription);

        }


        /**
         * DELETE: Removes a particular writer with the given {id}
         * uses a DELETE verb with the URL pattern "api/writers/45"
         */
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(long id)
        {
            //Searchs for record using Any(); if missing -> return NotFound();
            if (!_db.Users.Any(u => u.Id == id)) { return NotFound(); }
            //Removes the writer with the given id
            _db.Remove(new User { Id = id });
            _db.SaveChanges();
            return Accepted();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteInterview(long id)
        {
            //Searchs for record using Any(); if missing -> return NotFound();
            if (!_db.Interviews.Any(i => i.InterviewId == id)) { return NotFound(); }
            //Removes the writer with the given id
            _db.Remove(new Interview { InterviewId = id });
            _db.SaveChanges();
            return Accepted();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteQuestion(long id)
        {
            //Searchs for record using Any(); if missing -> return NotFound();
            if (!_db.Questions.Any(q => q.QuestionId == id)) { return NotFound(); }
            //Removes the writer with the given id
            _db.Remove(new Question { QuestionId = id });
            _db.SaveChanges();
            return Accepted();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSession(long id)
        {
            //Searchs for record using Any(); if missing -> return NotFound();
            if (!_db.Sessions.Any(s => s.SessionId == id)) { return NotFound(); }
            //Removes the writer with the given id
            _db.Remove(new Session { SessionId = id });
            _db.SaveChanges();
            return Accepted();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteResponse(long id)
        {
            //Searchs for record using Any(); if missing -> return NotFound();
            if (!_db.Responses.Any(r => r.ResponseId == id)) { return NotFound(); }
            //Removes the writer with the given id
            _db.Remove(new Response { ResponseId = id });
            _db.SaveChanges();
            return Accepted();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUserDescription(long id)
        {
            //Searchs for record using Any(); if missing -> return NotFound();
            if (!_db.UserDescriptions.Any(u => u.DescriptionId == id)) { return NotFound(); }
            //Removes the writer with the given id
            _db.Remove(new UserDescription { DescriptionId = id });
            _db.SaveChanges();
            return Accepted();
        }
    }
}
