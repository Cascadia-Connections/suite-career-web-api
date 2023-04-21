using System;
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
                .RuleFor(u => u.State, f => f.PickRandom(states))
                .RuleFor(u => u.Id, f => userId++);
            var users = testUsers.Generate(45); // TODO: B) create a collection of 45 users
                                                //UserDescriptions
            var usersIndex = 0;
            var educationLevels = new[] { "Primary School", "Secondary School", "High School Diploma", "Associate's Degree", "Bachelor's Degree", "Master's Degree", "Doctoral Degree", "Professional Degree" };
            var jobs = new[] { "Accountant", "Actor", "Architect", "Artist", "Athlete", "Attorney", "Author", "Baker", "Banker", "Barber", "Bartender", "Chef", "Clergy", "Coach", "Computer Programmer", "Consultant", "Dancer", "Dentist", "Designer", "Detective", "Doctor", "Electrician", "Engineer", "Entrepreneur", "Farmer", "Fashion Designer", "Firefighter", "Fisherman", "Flight Attendant", "Freelancer", "Gardener", "Graphic Designer", "Hair Stylist", "Hotel Manager", "Human Resources Manager", "Interior Designer", "Journalist", "Judge", "Lawyer", "Librarian", "Lifeguard", "Mechanic", "Medical Assistant", "Musician", "Nurse", "Optometrist", "Paramedic", "Pharmacist", "Photographer", "Physician Assistant", "Pilot", "Plumber", "Police Officer", "Professor", "Psychiatrist", "Psychologist", "Real Estate Agent", "Receptionist", "Salesperson", "Scientist", "Social Media Manager", "Social Worker", "Software Developer", "Teacher", "Technical Writer", "Tour Guide", "Translator", "Travel Agent", "Truck Driver", "Veterinarian", "Video Game Designer", "Web Developer", "Writer", "Yoga Instructor", "YouTuber", "Zookeeper" };


            var testDescriptions = new Faker<UserDescription>()
                .RuleFor(u => u.date, (faker, d) =>
        faker.Date.Between(DateTime.Today.AddYears(-10), DateTime.Today))
                .RuleFor(u => u.UserId, ui => usersIndex++)
                .RuleFor(u => u.EducationLevel, e => e.PickRandom(educationLevels))
                .RuleFor(u => u.UserJob, uj => uj.PickRandom(jobs))
                .RuleFor(u => u.WorkExperience, w => w.PickRandom(jobs));

            var userDescriptions = testDescriptions.Generate(45);
            

        
        dbContext.Users.AddRange(users);
        dbContext.UserDescriptions.AddRange(userDescriptions);

            dbContext.SaveChanges();

        }
    }
}
