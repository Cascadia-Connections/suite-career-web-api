using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuiteCareers.Models
{
    
        public class User
        {
            public long Id { get; set; }
            [DataType(DataType.EmailAddress)]
            public string? Email { get; set; }
            
            public string? FirstName { get; set; }
            
            public string? LastName { get; set; }
            
            public string? City { get; set; }
            
            public string? State { get; set; }
        }
}
     

        

 

           