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

namespace KTB.Controllers{
    public class HomeController : Controller{

        private KTBContext _context;
        public HomeController(KTBContext context){
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            int? userID = HttpContext.Session.GetInt32("LogedUserID");
            if(userID != null){
                return RedirectToAction("Home");
            }

            return View();
        }

        [HttpGet]
        [Route("home")]
        public IActionResult Home(){
            int? userID = HttpContext.Session.GetInt32("LogedUserID");
            if(userID != null){
                Users dbUser = _context.users.SingleOrDefault(u => u.id == userID);           
                if(dbUser != null){
                    
                    return View();
                    // return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
            // return View();
        }


        // *********************** Log In Method **************************
        [HttpPost]
        public IActionResult LoginMethod(string email, string password){

            Users dbUser = _context.users.SingleOrDefault(u => u.email == email);           
            if(dbUser != null){
                var Hasher = new PasswordHasher<Users>();
                // Pass the user object, the hashed password, and the PasswordToCheck
                if(0 != Hasher.VerifyHashedPassword(dbUser, dbUser.password, password))
                {
                    //Handle success
                    HttpContext.Session.SetInt32("LogedUserID", dbUser.id);
                    return RedirectToAction("Home");
                }
                else{
                    ViewBag.error = "Please check the password or email";
                    return View("Index");
                }
            }
            else{
                ViewBag.error = "Please check the password or email";
                return View("Index");
            }
        }

        // ************************** Register Method ********************
       [HttpPost]
        public IActionResult Create(Users userRegister, string password){


            Users userLog = _context.users.SingleOrDefault(user => user.email == userRegister.email);
            if(userLog != null){
                return RedirectToAction("Index");
            }
            else if(ModelState.IsValid && userRegister.password == password){
              
                PasswordHasher<Users> hasher = new PasswordHasher<Users>();
                userRegister.password = hasher.HashPassword(userRegister, userRegister.password);
                userRegister.created_at = DateTime.Now;
                userRegister.points = 0;
                _context.Add(userRegister);
                _context.SaveChanges();
                
                userLog = _context.users.SingleOrDefault(user => user.email == userRegister.email);

                HttpContext.Session.SetInt32("LogedUserID", userLog.id);
                return RedirectToAction("Home");
            }
            else{
                return RedirectToAction("Index");
            }
        }

        // ********************* Log out Method *********************
         public IActionResult LogOut(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(){
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
