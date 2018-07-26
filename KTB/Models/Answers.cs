using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace KTB.Models{
    public class Answers : BaseEntity{
        
        public int id{get; set;}

        public string answer {get; set;}

        public int correct_answer {get; set;}

        public int questionId {get; set;}
        public Questions Question{get; set;}

    }
}
