using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KTB.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;


using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;


namespace KTB.Controllers{

    public class GameController : Controller{


        private static KTBContext _context;
        public static string URL = "https://opentdb.com/api.php?";
        public GameController(KTBContext context){
            _context = context;
        }
        public static TriviaData.RootObject data=null;

        public static Users dbUser = null;
        public static string dif = "";
        public static Games game = null;

        public async  Task<ActionResult> GenerateGame(string category="", string difficulty="easy", string type="", int amount=10){
            int? userID = HttpContext.Session.GetInt32("LogedUserID");
            if(userID != null){
            dbUser = _context.users.SingleOrDefault(u => u.id == 1);           
                if(dbUser != null){

                    Games game = new Games(){
                        status = "Open",
                        dificulty = dif,
                        User = dbUser
                    };
                    _context.Add(game);
                    _context.SaveChanges();

                    string question_URL = URL + "amount=" + amount;
                    if(category != ""){
                        question_URL += "&category=" + category;
                    }
                    
                    question_URL += "&difficulty=" + difficulty;
                    dif = difficulty;
                    
                    if(type != ""){
                        question_URL += "&type=" + type;
                    }

                    SaveData(await  GetRequest(question_URL));

                    return View("PlayGround");
                }
            }
            return RedirectToAction("Index");
        }


            
        async static Task<TriviaData.RootObject> GetRequest(string url){
            using(HttpClient client = new HttpClient()){
                using (HttpResponseMessage response = await client.GetAsync(url)){
                    using(HttpContent content = response.Content){
                        string mycontent = await content.ReadAsStringAsync();
                        TriviaData.RootObject data = Newtonsoft.Json.JsonConvert.DeserializeObject<TriviaData.RootObject>(mycontent);
                        return data;
                    }
                }
            }
        }


        public static void SaveData(TriviaData.RootObject data){
            foreach(var d in data.results){
                Questions q = new Questions(){
                    question = d.question,
                    Game = game,
                }; 
                
                _context.Add(q);
                
                Answers answer = new Answers(){
                    answer = d.correct_answer,
                    correct_answer = 1,
                    Question = q
                };
                
                _context.Add(answer);
                q.Answers.Add(answer);
                _context.SaveChanges();
               
                foreach(var i_a in d.incorrect_answers){
                    Answers i_answer = new Answers(){
                        answer = i_a,
                        correct_answer = 0,
                        Question = q
                    };
                    _context.Add(i_answer);
                    q.Answers.Add(i_answer);
                }
            }
            _context.SaveChanges();
        }
    }
}