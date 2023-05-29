using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuiteCareers.Models;
using SuiteCareers.Data;
using System.Text.Json;
using System.Buffers;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet("users")]
        public IActionResult GetUsers()
        {

            return Ok(_db.Users);
        }

        [HttpGet("interviews")]
        public IActionResult GetInterviews()
        {
            return Ok(_db.Interviews);
        }

        [HttpGet("questions")]
        public IActionResult GetQuestions()
        {
            return Ok(_db.Questions);
        }
        [HttpGet("responses")]
        public IActionResult GetResponses()
        {
            return Ok(_db.Responses);
        }
        [HttpGet("sessions")]
        public IActionResult GetSessions()
        {
            return Ok(_db.Sessions);
        }

        [HttpPost("user")]
        public IActionResult Post([FromBody] User user)
        {
            //Tests for an invalid ModelState -> return BadRequest(); 
            if (!ModelState.IsValid) { return BadRequest(); }
            //Makes changes to DbContext, save to Database -> return Accepted(user);
            _db.Add(user);
            _db.SaveChanges();
            return Accepted(user);

        }

        [HttpPost("interview")]
        public IActionResult Post([FromBody] Interview interview)
        {
            //Tests for an invalid ModelState -> return BadRequest(); 
            if (!ModelState.IsValid) { return BadRequest(); }
            //Makes changes to DbContext, save to Database -> return Accepted(interview);
            _db.Add(interview);
            _db.SaveChanges();
            return Accepted(interview);

        }

        [HttpPost("question")]
        public IActionResult Post([FromBody] Question question)
        {
            //Tests for an invalid ModelState -> return BadRequest(); 
            if (!ModelState.IsValid) { return BadRequest(); }
            //Makes changes to DbContext, save to Database -> return Accepted(question);
            _db.Add(question);
            _db.SaveChanges();
            return Accepted(question);

        }

        [HttpPost("session")]
        public IActionResult Post([FromBody] Session session)
        {
            //Tests for an invalid ModelState -> return BadRequest(); 
            if (!ModelState.IsValid) { return BadRequest(); }
            //Makes changes to DbContext, save to Database -> return Accepted(session);
            _db.Add(session);
            _db.SaveChanges();
            return Accepted(session);

        }

        [HttpPost("response")]
        public IActionResult Post([FromBody] Response response)
        {
            //Tests for an invalid ModelState -> return BadRequest(); 
            if (!ModelState.IsValid) { return BadRequest(); }
            //Makes changes to DbContext, save to Database -> return Accepted(response);
            _db.Add(response);
            _db.SaveChanges();
            return Accepted(response);

        }

       


        /**
         * DELETE: Removes a particular writer with the given {id}
         * uses a DELETE verb with the URL pattern "api/writers/45"
         */
        [HttpDelete("user/{id}")]
        public ActionResult DeleteUser(long id)
        {
            //Searchs for record using Any(); if missing -> return NotFound();
            if (!_db.Users.Any(u => u.UserId == id)) { return NotFound(); }
            //Removes the writer with the given id
            _db.Remove(new User { UserId = id });
            _db.SaveChanges();
            return Accepted();
        }

        [HttpDelete("interview/{id}")]
        public ActionResult DeleteInterview(long id)
        {
            //Searchs for record using Any(); if missing -> return NotFound();
            if (!_db.Interviews.Any(i => i.InterviewId == id)) { return NotFound(); }
            //Removes the writer with the given id
            _db.Remove(new Interview { InterviewId = id });
            _db.SaveChanges();
            return Accepted();
        }

        [HttpDelete("question/{id}")]
        public ActionResult DeleteQuestion(long id)
        {
            //Searchs for record using Any(); if missing -> return NotFound();
            if (!_db.Questions.Any(q => q.QuestionId == id)) { return NotFound(); }
            //Removes the writer with the given id
            _db.Remove(new Question { QuestionId = id });
            _db.SaveChanges();
            return Accepted();
        }

        [HttpDelete("session/{id}")]
        public ActionResult DeleteSession(long id)
        {
            //Searchs for record using Any(); if missing -> return NotFound();
            if (!_db.Sessions.Any(s => s.SessionId == id)) { return NotFound(); }
            //Removes the writer with the given id
            _db.Remove(new Session { SessionId = id });
            _db.SaveChanges();
            return Accepted();
        }

        [HttpDelete("response/{id}")]
        public ActionResult DeleteResponse(long id)
        {
            //Searchs for record using Any(); if missing -> return NotFound();
            if (!_db.Responses.Any(r => r.ResponseId == id)) { return NotFound(); }
            //Removes the writer with the given id
            _db.Remove(new Response { ResponseId = id });
            _db.SaveChanges();
            return Accepted();
        }



        //[HttpPut("user/{id}")]
        //public ActionResult PutUser(long id, [FromBody] User user)
        //{
        //    // Tests for missing record (bad ID value)
        //    if (!_db.Users.Any(u => u.UserId == id))
        //    {
        //        return NotFound();
        //    }

        //    // Retrieve the user from the database
        //    User tempUser = _db.Users.Single(u => u.UserId == id);

        //    // Update the user properties with the values from the request body, if present
        //    if (user.FirstName != null)
        //    {
        //        tempUser.FirstName = user.FirstName;
        //    }
        //    if (user.LastName != null)
        //    {
        //        tempUser.LastName = user.LastName;
        //    }
        //    if (user.Email != null)
        //    {
        //        tempUser.Email = user.Email;
        //    }
        //    if (user.City != null)
        //    {
        //        tempUser.City = user.City;
        //    }
        //    if (user.State != null)
        //    {
        //        tempUser.State = user.State;
        //    }

        //    _db.Update(tempUser);
        //    // Save the changes to the database
        //    _db.SaveChanges();

        //    // Return the updated user
        //    return Accepted(tempUser);
        //}

        //[HttpPut("interview/{id}")]
        //public ActionResult PutInterview(long id, [FromBody] Interview interview)
        //{
        //    //Test for invalid Model
        //    if (!ModelState.IsValid) { return BadRequest(); }

        //    //Tests for missing record (bad ID value)
        //    if (!_db.Interviews.Any(u => u.InterviewId == id)) { return NotFound(); }
        //    //Makes changes to DbContext, save to Database -> return Accepted(writer);
        //    interview.InterviewId = id;
        //    _db.Update(interview);
        //    _db.SaveChanges();
        //    return Accepted(interview);
        //}

        //[HttpPut("question/{id}")]
        //public ActionResult PutQuestion(long id, [FromBody] Question question)
        //{
        //    //Test for invalid Model
        //    if (!ModelState.IsValid) { return BadRequest(); }

        //    //Tests for missing record (bad ID value)
        //    if (!_db.Questions.Any(u => u.QuestionId == id)) { return NotFound(); }
        //    //Makes changes to DbContext, save to Database -> return Accepted(writer);
        //    question.QuestionId = id;
        //    _db.Update(question);
        //    _db.SaveChanges();
        //    return Accepted(question);
        //}

        //[HttpPut("response/{id}")]
        //public ActionResult PutResponse(long id, [FromBody] Response response)
        //{
        //    //Test for invalid Model
        //    if (!ModelState.IsValid) { return BadRequest(); }

        //    //Tests for missing record (bad ID value)
        //    if (!_db.Responses.Any(u => u.ResponseId == id)) { return NotFound(); }
        //    //Makes changes to DbContext, save to Database -> return Accepted(writer);
        //    response.ResponseId = id;
        //    _db.Update(response);
        //    _db.SaveChanges();
        //    return Accepted(response);
        //}
        //[HttpPut("session/{id}")]
        //public ActionResult PutSession(long id, [FromBody] Session session)
        //{
        //    //Test for invalid Model
        //    if (!ModelState.IsValid) { return BadRequest(); }

        //    //Tests for missing record (bad ID value)
        //    if (!_db.Sessions.Any(u => u.SessionId == id)) { return NotFound(); }
        //    //Makes changes to DbContext, save to Database -> return Accepted(writer);
        //    session.SessionId = id;
        //    _db.Update(session);
        //    _db.SaveChanges();
        //    return Accepted(session);
        //}



        [HttpPut("user/{id}")]
        public IActionResult PutUser(long id, [FromBody] JsonElement updateJson)
        {
            // Get the entity type for the model name
            var entityType = _db.Model.FindEntityType($"SuiteCareers.Models.User");

            // If the entity type doesn't exist, return NotFound
            if (entityType == null)
            {
                return NotFound();
            }

            // Get the entity instance with the specified ID
            var entity = _db.Find(entityType.ClrType, id);

            // If the entity instance doesn't exist, return NotFound
            if (entity == null)
            {
                return NotFound();
            }

            // Parse the JSON update object into a dictionary
            var updateDict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(updateJson.GetRawText());
            

            User User = (User)entity;
            // Iterate through the properties of the entity type
            foreach (var prop in entityType.GetProperties())
            {
                string propName = char.ToUpper(prop.Name[0]) + prop.Name.Substring(1);
                
                // If the property name is in the update dictionary, update the entity property
                if (updateDict.TryGetValue(propName, out JsonElement propValue))
                {

                    var jsonString = propValue.GetRawText();
                    var convertedValue = JsonSerializer.Deserialize(jsonString, prop.ClrType);

                    User.GetType().GetProperty(propName)?.SetValue(User, convertedValue);

                }
            }

            // Save the changes to the database
            _db.Update(User);
            _db.SaveChanges();

            // Return the updated entity
            return Accepted(entity);
        }

    }
}
