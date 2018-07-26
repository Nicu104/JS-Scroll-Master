using System.Collections.Generic;
using System;
namespace KTB.Models{
    public class TriviaData{

        public class Result{
            public string category { get; set; }
            public string type { get; set; }
            public string difficulty { get; set; }
            public string question { get; set; }
            public string correct_answer { get; set; }
            public List<string> incorrect_answers { get; set; }
        }

        public class RootObject{
            public int response_code { get; set; }
            public List<Result> results { get; set; }
    

        }
    }
}