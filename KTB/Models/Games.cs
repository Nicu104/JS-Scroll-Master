using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace KTB.Models{
    public class Games : BaseEntity{
        
        [Key]
        public int id{ get; set; }

        public string status{get; set;}

        public string dificulty {get; set;}

        public int userId {get; set;}
        public Users User{get; set;}

        public List<GameCategory> GameCategory{get; set;}

        public List<Questions> Questions {get; set;}


        public Games(){
            GameCategory = new List<GameCategory>();
            Questions = new List<Questions>();
        }

    }
}