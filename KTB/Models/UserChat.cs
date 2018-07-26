using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace KTB.Models{
    public class UserChat : BaseEntity{
        
        public int id{get; set;}

        public int userId{get; set;}
        public Users User{get; set;}

        public int chatId{get; set;}
        public Chats Chat{get; set;}


    }
}
