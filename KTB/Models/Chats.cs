using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace KTB.Models{
    public class Chats : BaseEntity{
        
        public int id{get; set;}

        public  string text {get; set;}

        public DateTime created_at{get; set;}

        public DateTime updated_at{get; set;}

        public int userId {get; set;}
        public Users User {get; set;}

        public List<UserChat> UserChat{get; set;}


        public Chats(){
            UserChat = new List<UserChat>();
        }
    }
}
