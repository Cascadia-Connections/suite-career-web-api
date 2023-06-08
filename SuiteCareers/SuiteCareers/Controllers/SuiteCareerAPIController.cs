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
using System.Reflection;
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
        [HttpGet("users/{id}")]
        public IActionResult GetUser(long id)
        {
            return Ok(_db.Users.Single(u => u.UserId == id));
        }

        [HttpGet("interviews")]
        public IActionResult GetInterviews()
        {
            return Ok(_db.Interviews);
        }

        [HttpGet("interviews/{id}")]
        public IActionResult GetInterview(long id)
        {
            return Ok(_db.Interviews.Single(i => i.InterviewId == id));
        }

        [HttpGet("questions")]
        public IActionResult GetQuestions()
        {
            return Ok(_db.Questions);
        }

        [HttpGet("questions/{id}")]
        public IActionResult GetQuestion(long id)
        {
            return Ok(_db.Questions.Single(q => q.QuestionId == id));
        }

        [HttpGet("questions/interview/{id}")]
        public IActionResult GetQuestionsFromInterview(long id)
        {
            return Ok(_db.Questions.Where(q => q.InterviewId == id));
        }

        [HttpGet("responses")]
        public IActionResult GetResponses()
        {
            return Ok(_db.Responses);
        }

        [HttpGet("responses/{id}")]
        public IActionResult GetResponse(long id)
        {
            return Ok(_db.Responses.Single(r => r.ResponseId == id));
        }

        [HttpGet("responses/question/{id}")]
        public IActionResult GetResponsesForQuestion(long id)
        {
            return Ok(_db.Responses.Where(r => r.QuestionId == id));
        }

        [HttpGet("sessions")]
        public IActionResult GetSessions()
        {
            return Ok(_db.Sessions);
        }

        [HttpGet("sessions/{id}")]
        public IActionResult GetSession(long id)
        {
            return Ok(_db.Sessions.Single(s => s.SessionId == id));
        }

        [HttpGet("sessions/user/{id}")]
        public IActionResult GetSessionsOfUser(long id)
        {
            return Ok(_db.Sessions.Where(s => s.UserId == id));
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


        [HttpPut("user/{userId}")]
        public IActionResult UpdateUser(long userId, [FromBody] User updatedUser)
        {
            // Check if the provided user ID matches the updatedUser.UserId
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
                if (userId != updatedUser.UserId)
            {
                return BadRequest("User ID mismatch");
            }

            // TODO: Implement your logic to update the user in the database
            var existingUser = _db.Users.FirstOrDefault(u => u.UserId == userId);
            if (existingUser == null)
            {
                return NotFound();
            }

            var properties = typeof(User).GetProperties();

            foreach (var property in properties)
            {
                var updatedValue = property.GetValue(updatedUser);

                // Check if the updatedValue is not null or empty
                if (updatedValue != null && !string.IsNullOrEmpty(updatedValue.ToString()))
                {
                    property.SetValue(existingUser, updatedValue);
                }
            }

            // TODO: Save changes to the database
            _db.Update(existingUser);
            _db.SaveChanges();

            // Return a success response
            return Accepted(existingUser);
        }

        [HttpPut("session/{sessionId}")]
        public IActionResult UpdateSession(long sessionId, [FromBody] Session updatedSession)
        {
            // Check if the provided user ID matches the updatedUser.UserId
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (sessionId != updatedSession.SessionId)
            {
                return BadRequest("Session ID mismatch");
            }

            // TODO: Implement your logic to update the user in the database
            var existingSession = _db.Sessions.FirstOrDefault(s => s.SessionId == sessionId);
            if (existingSession == null)
            {
                return NotFound();
            }

            var properties = typeof(Session).GetProperties();

            foreach (var property in properties)
            {
                var updatedValue = property.GetValue(updatedSession);

                // Check if the updatedValue is not null or empty
                if ( updatedValue != null && !string.IsNullOrEmpty(updatedValue.ToString()))
                {
                    if (property.PropertyType != typeof(long) || (property.PropertyType == typeof(long) && (long)updatedValue != 0))
                    {
                        property.SetValue(existingSession, updatedValue);
                    }
                 
                }
            }

            // TODO: Save changes to the database
            _db.Update(existingSession);
            _db.SaveChanges();

            // Return a success response
            return Accepted(existingSession);
        }

        [HttpPut("question/{questionId}")]
        public IActionResult UpdateQuestion(int questionId, [FromBody] Question updatedQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            // Check if the provided question ID matches the updatedQuestion.QuestionId
            if (questionId != updatedQuestion.QuestionId)
            {
                return BadRequest("Question ID mismatch");
            }

            // TODO: Implement your logic to update the question in the database
            var existingQuestion = _db.Questions.FirstOrDefault(q => q.QuestionId == questionId);
            if (existingQuestion == null)
            {
                return NotFound();
            }

            var properties = typeof(Question).GetProperties();

            foreach (var property in properties)
            {
                var updatedValue = property.GetValue(updatedQuestion);

                // Check if the updatedValue is not null or empty
                if (updatedValue != null && !string.IsNullOrEmpty(updatedValue.ToString()))
                {
                    // Check if the updatedValue is not a long with value 0
                    if (property.PropertyType != typeof(long) || (property.PropertyType == typeof(long) && (long)updatedValue != 0))
                    {
                        property.SetValue(existingQuestion, updatedValue);
                    }
                }
            }

            // TODO: Save changes to the database
            _db.Update(existingQuestion);
            _db.SaveChanges();

            // Return a success response
            return Accepted(existingQuestion);
        }

        [HttpPut("response/{responseId}")]
        public IActionResult UpdateResponse(int responseId, [FromBody] Response updatedResponse)
        {
            // Check if the provided response ID matches the updatedResponse.ResponseId
            if (responseId != updatedResponse.ResponseId)
            {
                return BadRequest("Response ID mismatch");
            }

            // TODO: Implement your logic to update the response in the database
            var existingResponse = _db.Responses.FirstOrDefault(r => r.ResponseId == responseId);
            if (existingResponse == null)
            {
                return NotFound();
            }

            var properties = typeof(Response).GetProperties();

            foreach (var property in properties)
            {
                var updatedValue = property.GetValue(updatedResponse);

                // Check if the updatedValue is not null or empty
                if (updatedValue != null && !string.IsNullOrEmpty(updatedValue.ToString()))
                {
                    // Check if the updatedValue is not a long with value 0
                    if (property.PropertyType != typeof(long) || (property.PropertyType == typeof(long) && (long)updatedValue != 0))
                    {
                        property.SetValue(existingResponse, updatedValue);
                    }
                }
            }

            // TODO: Save changes to the database
            _db.Update(existingResponse);
            _db.SaveChanges();

            // Return a success response
            return Accepted(existingResponse);
        }

        [HttpPut("interview/{interviewId}")]
        public IActionResult UpdateInterview(int interviewId, [FromBody] Interview updatedInterview)
        {
            // Check if the provided interview ID matches the updatedInterview.InterviewId
            if (interviewId != updatedInterview.InterviewId)
            {
                return BadRequest("Interview ID mismatch");
            }

            // TODO: Implement your logic to update the interview in the database
            var existingInterview = _db.Interviews.FirstOrDefault(i => i.InterviewId == interviewId);
            if (existingInterview == null)
            {
                return NotFound();
            }

            var properties = typeof(Interview).GetProperties();

            foreach (var property in properties)
            {
                var updatedValue = property.GetValue(updatedInterview);

                // Check if the updatedValue is not null or empty
                if (updatedValue != null && !string.IsNullOrEmpty(updatedValue.ToString()))
                {
                    // Check if the updatedValue is not a long with value 0
                    if (property.PropertyType != typeof(long) || (property.PropertyType == typeof(long) && (long)updatedValue != 0))
                    {
                        property.SetValue(existingInterview, updatedValue);
                    }
                }
            }

            // TODO: Save changes to the database
            _db.Update(existingInterview);
            _db.SaveChanges();

            // Return a success response
            return Accepted(existingInterview);
        }

    }
}
