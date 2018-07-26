
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace KTB.Models{

    public abstract class BaseEntity{}
    
    public class Users : BaseEntity{
        
        [Key]
        public int id{ get; set; }

        [Required(ErrorMessage="You must enter your first name")]
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter only alphabetsof First Name")]
        [MinLength(4)]
        public string first_name { get; set; }

        [Required(ErrorMessage="You must enter your last name")]
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter only alphabetsof First Name")]
        [MinLength(4)]
        public string last_name { get; set; }

        [Required(ErrorMessage="Enter your age")]
        [Range(1, 120)]
        public int age { get; set; }

        [Required(ErrorMessage="You must enter your email")]
        [EmailAddress]
        public string email { get; set; }

        public int points { get; set; }

        [Required(ErrorMessage="You must enter password")]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[$@$!%*#?&])[A-Za-z\\d$@$!%*#?&]{8,}$", ErrorMessage = "Passwords must contain at least 1 letter, 1 number and 1 special character (e.g. !@#$%^&*)")]
        public string password { get; set; }

        public DateTime created_at { get; set; } 
        public DateTime updated_at { get; set; } 

        public List<UserCategory> UserCategory { get; set; }
        public List<Games> Games { get; set; }
        public List<UserAnswer> UserAnswer{get; set;}
        public List<UserChat> UserChat{get; set;}
        public List<Chats> Chats {get; set;}

        public Users (){
            UserCategory = new List<UserCategory>();
            Games = new List<Games>();
            UserAnswer = new List<UserAnswer>();
            UserChat = new List<UserChat>();
            Chats = new List<Chats>();

            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }
    }
}