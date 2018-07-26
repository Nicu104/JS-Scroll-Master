using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace KTB.Models{
    public class UserAnswer : BaseEntity{
        
        public int id {get; set;}

        public string answer {get; set;}

        public DateTime created_at {get; set;}

        public DateTime updated_at{get; set;}

        public int userId{get; set;}
        public Users User{get; set;}

        public int questionId {get; set;}
        public Questions Question {get; set;}

        public UserAnswer(){
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }

    }
}
