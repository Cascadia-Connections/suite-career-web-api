﻿using System;
using System.Linq;
using Bogus;
using System.Threading.Tasks;
using SuiteCareers.Models;
using SuiteCareers.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;

namespace SuiteCareers.DbSetup
{
    internal class SeedData
    {
        internal static void Initialize(SuiteCareersDbContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            //dbContext.Database.EnsureCreated(); // No longer forcing DB creation on app start; following Migrations instead
            if (dbContext.Users.Any()) return;
            if (dbContext.UserDescriptions.Any()) return;
            if (dbContext.Interviews.Any()) return;
            if (dbContext.Questions.Any()) return;
            if (dbContext.Responses.Any()) return;
            if (dbContext.Sessions.Any()) return;

            var firstNames = new[] { "Adam", "Alex", "Avery", "Bella", "Benjamin", "Brandon", "Caleb", "Caroline", "Charlotte", "Chloe", "Connor", "Daniel", "David", "Ella", "Emily", "Emma", "Ethan", "Gabriel", "Grace", "Hannah", "Isaac", "Isabella", "Jacob", "James", "John", "Joseph", "Joshua", "Liam", "Lily", "Lucas", "Luke", "Mason", "Matthew", "Michael", "Natalie", "Nathan", "Noah", "Olivia", "Owen", "Peter", "Rachel", "Ryan", "Samuel", "Sarah", "Sophia", "Thomas", "William", "Zoe" };
            var lastNames = new[] { "Adams", "Baker", "Bell", "Brown", "Campbell", "Carter", "Clark", "Collins", "Cooper", "Davis", "Edwards", "Evans", "Foster", "Garcia", "Gonzalez", "Gray", "Green", "Hall", "Harris", "Hernandez", "Hill", "Jackson", "Johnson", "Jones", "Kelly", "King", "Lee", "Lewis", "Martinez", "Miller", "Mitchell", "Moore", "Morgan", "Murphy", "Nelson", "Parker", "Perez", "Phillips", "Reed", "Roberts", "Rodriguez", "Scott", "Smith", "Taylor", "Thomas", "Thompson", "Turner", "Walker", "White", "Williams", "Wilson" };
            var emails = new[] { "adam.adams@example.com", "alex.baker@example.com", "avery.bell@example.com", "bella.brown@example.com", "benjamin.campbell@example.com", "brandon.carter@example.com", "caleb.clark@example.com", "caroline.collins@example.com", "charlotte.cooper@example.com", "chloe.davis@example.com", "connor.edwards@example.com", "daniel.evans@example.com", "david.foster@example.com", "ella.garcia@example.com", "emily.gonzalez@example.com", "emma.gray@example.com", "ethan.green@example.com", "gabriel.hall@example.com", "grace.harris@example.com", "hannah.hernandez@example.com", "isaac.hill@example.com", "isabella.jackson@example.com", "jacob.johnson@example.com", "james.jones@example.com", "john.kelly@example.com", "joseph.king@example.com", "jerry.lee@example.com", "joseph.lewis@example.com", "joseph.martinez@example.com", "joseph.miller@example.com", "joseph.mitchell@example.com", "joseph.moore@example.com", "joseph.morgan@example.com", "joseph.murphy@example.com", "joseph.nelson@example.com", "joseph.parker@example.com", "joseph.perez@example.com", "joseph.phillips@example.com", "joseph.reed@example.com", "joseph.roberts@example.com", "joseph.rodriguez@example.com", "joseph.scott@example.com", "joseph.smith@example.com", "joseph.taylor@example.com", "joseph.thomas@example.com", "joseph.thompson@example.com", "joseph.turner@example.com", "joseph.walker@example.com", "joseph.white@example.com", "joseph.williams@example.com", "joseph.wilson@example.com" };
            var cities = new[] { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego", "Dallas", "San Jose", "Austin", "Jacksonville", "Fort Worth", "Columbus", "San Francisco", "Charlotte", "Indianapolis", "Seattle", "Denver", "Washington", "Boston", "Nashville", "El Paso", "Detroit", "Memphis", "Portland", "Oklahoma City", "Las Vegas", "Louisville", "Baltimore", "Milwaukee", "Albuquerque", "Tucson", "Fresno", "Mesa", "Sacramento", "Atlanta", "Kansas City", "Colorado Springs", "Miami", "Raleigh", "Omaha", "Long Beach", "Virginia Beach", "Oakland", "Minneapolis", "Tulsa", "Wichita", "New Orleans", "Arlington", "Tampa", "Aurora", "Santa Ana", "St. Louis", "Pittsburgh", "Corpus Christi", "Riverside", "Cincinnati", "Lexington", "Anchorage", "Stockton", "Toledo", "Saint Paul", "Newark", "Greensboro", "Buffalo", "Plano", "Lincoln", "Henderson", "Fort Wayne", "Jersey City", "St. Petersburg", "Chula Vista", "Norfolk", "Orlando", "Chandler", "Laredo", "Madison", "Winston-Salem", "Lubbock", "Baton Rouge", "Durham", "Garland", "Glendale", "Reno", "Hialeah", "Chesapeake", "Scottsdale", "North Las Vegas", "Irving", "Fremont", "Irvine", "Birmingham", "Rochester", "San Bernardino", "Spokane", "Gilbert", "Arlington CDP", "Montgomery", "Boise", "Richmond", "Des Moines", "Modesto", "Fayetteville", "Shreveport", "Akron", "Tacoma", "Aurora city", "Oxnard", "Fontana" };
            var states = new[] { "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming" };


            //  TODO: A) Import NuGet Package "Bogus" fake data generator, then
            //  TODO: (do after each) Use "dotnet ef database drop", and run the application and inspect your data
            Randomizer.Seed = new Random(Guid.NewGuid().GetHashCode());
            var userIndex = 0;
            var emailIndex = 0;
            var userId = 0;
            //Writers
            var testUsers = new Faker<User>()
                .RuleFor(u => u.FirstName, f => firstNames[userIndex++])
                .RuleFor(u => u.LastName, f => f.PickRandom(lastNames))
                .RuleFor(u => u.Email, f => emails[emailIndex++])
                .RuleFor(u => u.City, f => f.PickRandom(cities))
                .RuleFor(u => u.State, f => f.PickRandom(states));
            var users = testUsers.Generate(45); // TODO: B) create a collection of 45 users
                                                //UserDescriptions
            var usersIndex = 0;
            var educationLevels = new[] { "Primary School", "Secondary School", "High School Diploma", "Associate's Degree", "Bachelor's Degree", "Master's Degree", "Doctoral Degree", "Professional Degree" };
            var jobs = new[] { "Accountant", "Actor", "Architect", "Artist", "Athlete", "Attorney", "Author", "Baker", "Banker", "Barber", "Bartender", "Chef", "Clergy", "Coach", "Computer Programmer", "Consultant", "Dancer", "Dentist", "Designer", "Detective", "Doctor", "Electrician", "Engineer", "Entrepreneur", "Farmer", "Fashion Designer", "Firefighter", "Fisherman", "Flight Attendant", "Freelancer", "Gardener", "Graphic Designer", "Hair Stylist", "Hotel Manager", "Human Resources Manager", "Interior Designer", "Journalist", "Judge", "Lawyer", "Librarian", "Lifeguard", "Mechanic", "Medical Assistant", "Musician", "Nurse", "Optometrist", "Paramedic", "Pharmacist", "Photographer", "Physician Assistant", "Pilot", "Plumber", "Police Officer", "Professor", "Psychiatrist", "Psychologist", "Real Estate Agent", "Receptionist", "Salesperson", "Scientist", "Social Media Manager", "Social Worker", "Software Developer", "Teacher", "Technical Writer", "Tour Guide", "Translator", "Travel Agent", "Truck Driver", "Veterinarian", "Video Game Designer", "Web Developer", "Writer", "Yoga Instructor", "YouTuber", "Zookeeper" };


            var testDescriptions = new Faker<UserDescription>()
                .RuleFor(u => u.Date, (faker, d) =>
        faker.Date.Between(DateTime.Today.AddYears(-10), DateTime.Today))
                .RuleFor(u => u.UserId, ui => usersIndex++)
                .RuleFor(u => u.EducationLevel, e => e.PickRandom(educationLevels))
                .RuleFor(u => u.UserJob, uj => uj.PickRandom(jobs))
                .RuleFor(u => u.WorkExperience, w => w.PickRandom(jobs));

            var userDescriptions = testDescriptions.Generate(45);

            var interviews = new Faker<Interview>()
                .Generate(50);

            var questions = new[] { "Tell me about yourself", "What are your strengths?", "What are your weaknesses?", "Why do you want to work for our company?", "Why did you leave your previous job?", "What is your greatest professional achievement?", "What are your long-term career goals?", "What motivates you?", "How do you handle stress and pressure?", "What are your salary expectations?", "What makes you a good fit for this position?", "What do you know about our company?", "Why should we hire you?", "What is your management style?", "What are your communication skills like?", "How do you handle conflicts with coworkers or superiors?", "What are your most important values?", "What do you consider to be your biggest professional failure?", "What kind of work environment do you thrive in?", "How do you handle a situation where you are not meeting your goals?", "What do you think sets you apart from other candidates?", "How do you stay up-to-date with industry trends and developments?", "What do you think will be the biggest challenge you will face in this position?", "What do you think you can contribute to our team?", "What are your thoughts on work-life balance?", "What do you think is the most important quality for success in this role?", "What kind of feedback do you appreciate the most?", "What is your experience with working in a team?", "How do you prioritize your work?", "What do you think is your biggest area for improvement?", "What kind of management style do you respond best to?", "What is your experience with remote work?", "How do you handle ambiguity or uncertainty?", "What are your thoughts on professional development?", "What are your thoughts on failure?", "How do you deal with difficult customers or clients?", "What kind of work do you find most fulfilling?", "How do you balance competing priorities?", "What are your thoughts on company culture?", "What do you think is the most important skill for success in this role?", "What are your thoughts on innovation?", "How do you handle tight deadlines?", "What is your experience with project management?", "How do you handle a situation where you disagree with your supervisor's decision?", "What do you think is the biggest challenge facing this industry?", "What is your experience with public speaking or presentations?", "How do you handle a situation where a coworker is not pulling their weight?", "What is your experience with data analysis?", "How do you stay organized?", "What are your thoughts on mentoring or coaching?", "What do you think is the most important quality for leadership?", "How do you handle a situation where you are asked to do something you disagree with?", "What is your experience with customer service?", "What are your thoughts on diversity and inclusion?", "How do you handle a situation where you don't know the answer to a question?", "What do you think are the most important qualities for a successful team?", "How do you handle constructive criticism?", "What is your experience with social media?", "What are your thoughts on time management?", "How do you handle a situation where you have made a mistake?", "What is your experience with content creation?", "What do you think sets our company apart from competitors?", "What are your thoughts on ethics in the workplace?", "How do you handle a situation where you have to work with someone you don't get along with?", "What is your experience with public relations?", "What are your thoughts on risk-taking?", "How do you handle a situation where you are asked to work on a project outside of your expertise?", "What is your experience with event planning?", "What attracted you to this company and position?", "What are your biggest strengths and weaknesses?", "How do you handle stress and pressure?", "Describe a time when you had to deal with a difficult co-worker or boss.", "What motivates you in a work environment?", "How do you prioritize your workload?", "What is your experience with project management?", "What do you know about our company?", "What is your experience with customer service?", "How do you handle conflicts with coworkers?", "What is your experience with problem-solving?", "Tell me about a time when you failed at something.", "How do you keep up with industry trends?", "What is your experience with public speaking?", "What is your experience with teamwork?", "What is your experience with mentoring or training others?", "What is your experience with budgeting and financial management?", "Tell me about a time when you had to work under pressure to meet a deadline.", "What is your experience with negotiation?", "What is your experience with data analysis?", "What is your experience with marketing and advertising?", "Tell me about a time when you had to make a difficult decision.", "What is your experience with technical writing?", "What is your experience with project planning?", "What is your experience with software development?", "What is your experience with business development?", "What is your experience with social media management?", "What is your experience with event planning?", "What is your experience with graphic design?", "What is your experience with database management?", "What is your experience with website development?", "What is your experience with video production?", "What is your experience with content creation?", "What is your experience with search engine optimization?", "What is your experience with email marketing?", "What is your experience with fundraising?", "What is your experience with grant writing?", "What is your experience with public relations?", "What is your experience with market research?", "What is your experience with data entry?", "What is your experience with quality control?", "What is your experience with supply chain management?", "What is your experience with logistics?", "What is your experience with international business?", "What is your experience with contract negotiation?", "What is your experience with regulatory compliance?", "What is your experience with risk management?", "What is your experience with insurance?" };
            var questionsIndex = 0;
            var testQuestions = new Faker<Question>()
                .RuleFor(q => q.QuestionContent, f => questions[questionsIndex++])
                .RuleFor(q => q.Interview, f => f.PickRandom(interviews));
            var allQuestions = testQuestions.Generate(100);

            var responses = new[] { "I am a quick learner", "I have excellent communication skills", "I am highly organized", "I work well in a team environment", "I am passionate about my work", "I am highly motivated", "I am adaptable to change", "I have strong problem-solving skills", "I am detail-oriented", "I am self-motivated", "I have a positive attitude", "I am results-driven", "I am able to multitask", "I am a good listener", "I am always willing to learn", "I am proactive", "I have a strong work ethic", "I am a team player", "I am able to work independently", "I am customer-focused", "I have good time-management skills", "I am able to prioritize tasks effectively", "I am creative", "I am able to think outside the box", "I have good analytical skills", "I am able to work well under pressure", "I am a good problem-solver", "I have good attention to detail", "I am enthusiastic about my work", "I have good interpersonal skills", "I am dependable", "I have a can-do attitude", "I am able to meet deadlines", "I am good at managing my workload", "I have good decision-making skills", "I am able to handle criticism constructively", "I am flexible", "I have good conflict resolution skills", "I have good negotiation skills", "I have a strong sense of responsibility", "I am willing to take on new challenges", "I have good follow-up skills", "I am good at building relationships", "I am able to adapt to different situations", "I have good leadership skills", "I am able to inspire and motivate others", "I am goal-oriented", "I am able to provide excellent customer service", "I have good presentation skills", "I believe my biggest strength is my ability to take initiative and think creatively.", "I have experience in managing projects from start to finish, ensuring they are completed on time and within budget.", "I am a strong communicator and have experience working with people from diverse backgrounds.", "In my previous role, I was responsible for analyzing data and making strategic recommendations based on my findings.", "I am a self-starter and am able to work independently with minimal supervision.", "I have experience in customer service and understand the importance of providing excellent service to clients.", "I am skilled in using various software and tools, including Microsoft Office and project management software.", "I have a track record of meeting and exceeding sales targets.", "I am able to adapt to changing circumstances and thrive in fast-paced environments.", "I have a strong work ethic and am dedicated to achieving my goals.", "I am detail-oriented and have experience in quality control and quality assurance.", "I have experience in leading teams and have a proven track record of achieving results through effective leadership.", "I am able to prioritize tasks and manage my time effectively.", "I have experience in conflict resolution and have successfully resolved disputes between team members.", "I am passionate about my work and am constantly looking for ways to improve my skills and knowledge.", "I am able to work well under pressure and have experience in managing tight deadlines.", "I am a problem-solver and am able to find creative solutions to complex challenges.", "I have experience in conducting market research and analyzing trends to identify new opportunities.", "I am comfortable working in a team environment and have experience in collaborating with colleagues to achieve shared goals.", "I am able to multitask and manage multiple projects simultaneously.", "I am able to take feedback constructively and use it to improve my performance.", "I have experience in presenting to large groups of people and am comfortable speaking in public.", "I am able to work effectively with people from diverse backgrounds and cultures.", "I am able to analyze complex data sets and draw actionable insights from my analysis.", "I have experience in managing budgets and ensuring that projects are completed within financial constraints.", "I am able to build strong relationships with clients and am dedicated to providing exceptional service to them.", "I am able to work well in fast-paced environments and am comfortable dealing with ambiguity and uncertainty.", "I have experience in project planning and am able to create detailed plans that include timelines, milestones, and deliverables.", "I am able to learn quickly and am always eager to take on new challenges.", "I have experience in developing and implementing marketing campaigns across a variety of channels.", "I am able to work effectively with cross-functional teams and am able to bridge communication gaps between departments.", "I am able to identify opportunities for process improvements and am committed to implementing them.", "I have experience in conducting user research and using that research to inform product design decisions.", "I am able to manage multiple stakeholders and balance competing priorities to achieve shared objectives.", "I have experience in conducting competitive analysis and using that analysis to inform strategic decisions.", "I am able to build strong relationships with suppliers and negotiate favorable terms and conditions.", "I am able to identify and mitigate risks associated with projects, ensuring that they are completed safely and successfully.", "I am able to work effectively with remote teams and am comfortable using technology to collaborate with colleagues in different locations.", "I have experience in managing teams of all sizes and have a proven track record of building high-performing teams.", "I am able to think strategically and develop long-term plans that align with business objectives.", "I am able to identify opportunities for growth and expansion and am committed to pursuing them.", "I am a quick learner", "I have excellent communication skills", "I am highly organized", "I work well in a team environment", "I am passionate about my work", "I am highly motivated", "I am adaptable to change", "I have strong problem-solving skills", "I am detail-oriented", "I am self-motivated", "I have a positive attitude", "I am results-driven", "I am able to multitask", "I am a good listener", "I am always willing to learn", "I am proactive", "I have a strong work ethic", "I am a team player", "I am able to work independently", "I am customer-focused", "I have good time-management skills", "I am able to prioritize tasks effectively", "I am creative", "I am able to think outside the box", "I have good analytical skills", "I am able to work well under pressure", "I am a good problem-solver", "I have good attention to detail", "I am enthusiastic about my work", "I have good interpersonal skills", "I am dependable", "I have a can-do attitude", "I am able to meet deadlines", "I am good at managing my workload", "I have good decision-making skills", "I am able to handle criticism constructively", "I am flexible", "I have good conflict resolution skills", "I have good negotiation skills", "I have a strong sense of responsibility", "I am willing to take on new challenges", "I have good follow-up skills", "I am good at building relationships", "I am able to adapt to different situations", "I have good leadership skills", "I am able to inspire and motivate others", "I am goal-oriented", "I am able to provide excellent customer service", "I have good presentation skills", "I believe my biggest strength is my ability to take initiative and think creatively.", "I have experience in managing projects from start to finish, ensuring they are completed on time and within budget.", "I am a strong communicator and have experience working with people from diverse backgrounds.", "In my previous role, I was responsible for analyzing data and making strategic recommendations based on my findings.", "I am a self-starter and am able to work independently with minimal supervision.", "I have experience in customer service and understand the importance of providing excellent service to clients.", "I am skilled in using various software and tools, including Microsoft Office and project management software.", "I have a track record of meeting and exceeding sales targets.", "I am able to adapt to changing circumstances and thrive in fast-paced environments.", "I have a strong work ethic and am dedicated to achieving my goals.", "I am detail-oriented and have experience in quality control and quality assurance.", "I have experience in leading teams and have a proven track record of achieving results through effective leadership.", "I am able to prioritize tasks and manage my time effectively.", "I have experience in conflict resolution and have successfully resolved disputes between team members.", "I am passionate about my work and am constantly looking for ways to improve my skills and knowledge.", "I am able to work well under pressure and have experience in managing tight deadlines.", "I am a problem-solver and am able to find creative solutions to complex challenges.", "I have experience in conducting market research and analyzing trends to identify new opportunities.", "I am comfortable working in a team environment and have experience in collaborating with colleagues to achieve shared goals.", "I am able to multitask and manage multiple projects simultaneously.", "I am able to take feedback constructively and use it to improve my performance.", "I have experience in presenting to large groups of people and am comfortable speaking in public.", "I am able to work effectively with people from diverse backgrounds and cultures.", "I am able to analyze complex data sets and draw actionable insights from my analysis.", "I have experience in managing budgets and ensuring that projects are completed within financial constraints.", "I am able to build strong relationships with clients and am dedicated to providing exceptional service to them.", "I am able to work well in fast-paced environments and am comfortable dealing with ambiguity and uncertainty.", "I have experience in project planning and am able to create detailed plans that include timelines, milestones, and deliverables.", "I am able to learn quickly and am always eager to take on new challenges.", "I have experience in developing and implementing marketing campaigns across a variety of channels.", "I am able to work effectively with cross-functional teams and am able to bridge communication gaps between departments.", "I am able to identify opportunities for process improvements and am committed to implementing them.", "I have experience in conducting user research and using that research to inform product design decisions.", "I am able to manage multiple stakeholders and balance competing priorities to achieve shared objectives.", "I have experience in conducting competitive analysis and using that analysis to inform strategic decisions.", "I am able to build strong relationships with suppliers and negotiate favorable terms and conditions.", "I am able to identify and mitigate risks associated with projects, ensuring that they are completed safely and successfully.", "I am able to work effectively with remote teams and am comfortable using technology to collaborate with colleagues in different locations.", "I have experience in managing teams of all sizes and have a proven track record of building high-performing teams.", "I am able to think strategically and develop long-term plans that align with business objectives.", "I am able to identify opportunities for growth and expansion and am committed to pursuing them.", "I am a quick learner", "I have excellent communication skills", "I am highly organized", "I work well in a team environment", "I am passionate about my work", "I am highly motivated", "I am adaptable to change", "I have strong problem-solving skills", "I am detail-oriented", "I am self-motivated", "I have a positive attitude", "I am results-driven", "I am able to multitask", "I am a good listener", "I am always willing to learn", "I am proactive", "I have a strong work ethic", "I am a team player", "I am able to work independently", "I am customer-focused", "I have good time-management skills", "I am able to prioritize tasks effectively", "I am creative", "I am able to think outside the box", "I have good analytical skills", "I am able to work well under pressure", "I am a good problem-solver", "I have good attention to detail", "I am enthusiastic about my work", "I have good interpersonal skills", "I am dependable", "I have a can-do attitude", "I am able to meet deadlines", "I am good at managing my workload", "I have good decision-making skills", "I am able to handle criticism constructively", "I am flexible", "I have good conflict resolution skills", "I have good negotiation skills", "I have a strong sense of responsibility", "I am willing to take on new challenges", "I have good follow-up skills", "I am good at building relationships", "I am able to adapt to different situations", "I have good leadership skills", "I am able to inspire and motivate others", "I am goal-oriented", "I am able to provide excellent customer service", "I have good presentation skills", "I believe my biggest strength is my ability to take initiative and think creatively.", "I have experience in managing projects from start to finish, ensuring they are completed on time and within budget.", "I am a strong communicator and have experience working with people from diverse backgrounds.", "In my previous role, I was responsible for analyzing data and making strategic recommendations based on my findings.", "I am a self-starter and am able to work independently with minimal supervision.", "I have experience in customer service and understand the importance of providing excellent service to clients.", "I am skilled in using various software and tools, including Microsoft Office and project management software.", "I have a track record of meeting and exceeding sales targets.", "I am able to adapt to changing circumstances and thrive in fast-paced environments.", "I have a strong work ethic and am dedicated to achieving my goals.", "I am detail-oriented and have experience in quality control and quality assurance.", "I have experience in leading teams and have a proven track record of achieving results through effective leadership.", "I am able to prioritize tasks and manage my time effectively.", "I have experience in conflict resolution and have successfully resolved disputes between team members.", "I am passionate about my work and am constantly looking for ways to improve my skills and knowledge.", "I am able to work well under pressure and have experience in managing tight deadlines.", "I am a problem-solver and am able to find creative solutions to complex challenges.", "I have experience in conducting market research and analyzing trends to identify new opportunities.", "I am comfortable working in a team environment and have experience in collaborating with colleagues to achieve shared goals.", "I am able to multitask and manage multiple projects simultaneously.", "I am able to take feedback constructively and use it to improve my performance.", "I have experience in presenting to large groups of people and am comfortable speaking in public.", "I am able to work effectively with people from diverse backgrounds and cultures.", "I am able to analyze complex data sets and draw actionable insights from my analysis.", "I have experience in managing budgets and ensuring that projects are completed within financial constraints.", "I am able to build strong relationships with clients and am dedicated to providing exceptional service to them.", "I am able to work well in fast-paced environments and am comfortable dealing with ambiguity and uncertainty.", "I have experience in project planning and am able to create detailed plans that include timelines, milestones, and deliverables.", "I am able to learn quickly and am always eager to take on new challenges.", "I have experience in developing and implementing marketing campaigns across a variety of channels.", "I am able to work effectively with cross-functional teams and am able to bridge communication gaps between departments.", "I am able to identify opportunities for process improvements and am committed to implementing them.", "I have experience in conducting user research and using that research to inform product design decisions.", "I am able to manage multiple stakeholders and balance competing priorities to achieve shared objectives.", "I have experience in conducting competitive analysis and using that analysis to inform strategic decisions.", "I am able to build strong relationships with suppliers and negotiate favorable terms and conditions.", "I am able to identify and mitigate risks associated with projects, ensuring that they are completed safely and successfully.", "I am able to work effectively with remote teams and am comfortable using technology to collaborate with colleagues in different locations.", "I have experience in managing teams of all sizes and have a proven track record of building high-performing teams.", "I am able to think strategically and develop long-term plans that align with business objectives.", "I am able to identify opportunities for growth and expansion and am committed to pursuing them." };
            var responsesIndex = 0;
            var testResponses = new Faker<Response>()
                .RuleFor(r => r.UserResponse, f => responses[responsesIndex++])
                .RuleFor(r => r.QuestionId, f => f.Random.Int(1, 100));
            var allResponses = testResponses.Generate(200);

            var testSessions = new Faker<Session>()
                .RuleFor(s => s.InterviewId, f => f.PickRandom(interviews).InterviewId)
                .RuleFor(s => s.UserId, f => f.PickRandom(users).UserId)
                .RuleFor(s => s.Date, (faker, d) =>
        faker.Date.Between(DateTime.Today.AddYears(-10), DateTime.Today));
            var sessions = testSessions.Generate(100);

            dbContext.Users.AddRange(users);
            dbContext.UserDescriptions.AddRange(userDescriptions);
            dbContext.Interviews.AddRange(interviews);
            dbContext.Questions.AddRange(allQuestions);
            dbContext.Responses.AddRange(allResponses);
            dbContext.Sessions.AddRange(sessions);


            dbContext.SaveChanges();

        }
    }
}
