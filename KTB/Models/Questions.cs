using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace KTB.Models{
    public class Questions : BaseEntity{
        public int id {get; set;}

        public string question {get; set;}

        public int gameId {get; set;}
        public Games Game {get; set;}

        public List<Answers> Answers{get; set;}

        public List<UserAnswer> UserAnswer {get; set;}

        public Questions(){
            Answers = new List<Answers>();
            UserAnswer = new List<UserAnswer>();
        }        
    }
}
