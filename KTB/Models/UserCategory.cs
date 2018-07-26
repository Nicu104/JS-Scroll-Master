using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace KTB.Models{
    public class UserCategory : BaseEntity{
        
        [Key]
        public int id{ get; set; }

        public int categoryId{get; set;}
        public Categories Category{get; set;}

        public int userId {get; set;}
        public Users User {get; set;}
    }
}