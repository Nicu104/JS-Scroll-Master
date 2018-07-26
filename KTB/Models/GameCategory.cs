using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace KTB.Models{
    public class GameCategory : BaseEntity{
        
        [Key]
        public int id{ get; set; }

        public int categoryId {get; set;}
        public Categories Category{get; set;}

        public int gameId{get; set;}
        public Games Game{get; set;}


    }
}