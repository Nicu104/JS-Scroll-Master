using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace KTB.Models{
    public class Categories : BaseEntity{
        
        [Key]
        public int id{ get; set; }

        public string name {get; set;}

        public int value {get; set;}

        public List<GameCategory> GameCategory {get; set;}

        public List<UserCategory> UserCategory {get; set;}


        public Categories(){
            GameCategory = new List<GameCategory>();
            UserCategory = new List<UserCategory>();
        }
    }
}