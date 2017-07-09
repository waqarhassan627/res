using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projectWork.Models;

namespace projectWork.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Users/
        public ActionResult SignUp()
        {
            return View("SignUp");
        }

        public ActionResult UniStudentHome()
        {
            if (Session["User"] != null)
            {
                return GetAllTest();
            }
            else
            {
                return Redirect("~/Users/Login");
            }
        }

        public ActionResult Quiz()
        {
            if (Session["User"] != null)
            {
                return GetTest();
            }
            else
            {
                return Redirect("~/Users/Login");
            }
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        public ActionResult MyResults()
        {
            if (Session["User"] != null)
            {
                return AllResult();
            }
            else
            {
                return Redirect("~/Users/Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return Redirect("~/Main/Home");
        }

        public ActionResult Questionaire()
        {
            UserDTO dto = new UserDTO();
            dto.Username = Request["Username"];
            dto.FullName = Request["Fullname"];
            dto.Password = Request["Password"];
            dto.UserType = 2; //For Outsider Student
            dto.Email = Request["Email"];
            dto.Address = Request["Address"];
            dto.ContactNo = Request["ContactNo"];
            dto.isActive = false;

            UserRepository repo = new UserRepository();
            int id = repo.SaveUser(dto);
            ViewData["id"] = id; 

            return View("QuestionaireHome");
        }

        public ActionResult verifyLogin()
        {
            UserDTO dto = new UserDTO();
            string uname = Request["Username"];
            string passwd = Request["Password"];

            UserRepository repo = new UserRepository();
            dto = repo.verifyLogin(uname);
            if( dto == null )
            {
                ViewBag.msg = "Wrong UserName";
                return View("Login");
            }
            else if (dto.Password == passwd)
            {
                ViewData["id"] = dto.UserID;
                if (dto.UserType == 3 && dto.isActive == true)
                {
                    Session["User"] = dto;
                    return Redirect("~/Teacher/Home");
                }
                if (dto.UserType == 1 && dto.isActive == true)
                {
                    Session["User"] = dto;
                    return Redirect("~/Users/UniStudentHome");
                }
                if (dto.UserType == 2 && dto.isActive == true)
                {
                    Session["User"] = dto;
                    return Redirect("~/OutsiderStudent/Home");
                }
                if (dto.UserType == 0 && dto.isActive == true)
                {
                    Session["User"] = dto;
                    return Redirect("~/Admin/Dashboard");
                }
            }
            ViewBag.msg = "Wrong UserName / Password / disabled by the Admin So Contact them.";
            return View("Login");
        }

        public ActionResult GetAllTest()
        {
            UserDTO dto = (UserDTO) Session["User"];
            int id = dto.UserID;
            UserRepository repo = new UserRepository();
            var li = repo.AllTest(id);

            List<TestDTO> test_list = new List<TestDTO>();
            foreach( var l in li )
            {
                DateTime dt = DateTime.ParseExact(l.Date, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                if( dt > DateTime.Now)
                {
                    test_list.Add(l);
                }
            }
            //var list = repo.GetTest("OS-Quiz1");
            
            return View("UniStudentHome", test_list);
        }

        public ActionResult GetTest()
        {
            string id = Request["testid"];
            int tid = 0;
            if (id != null)
            {
                tid = int.Parse(Request["testid"]);
            }
            else
            {
                return View("UniStudentHome");
            }
            UserRepository repo = new UserRepository();
            var li = repo.GetTest(tid);
            // Get Title from the View and then query all questions from the DB
            return View("Quiz", li);
        }

        [HttpPost]
        public ActionResult Result()
        {
            // 12-05-16 Start From Here.
            int id = int.Parse(Request["tid"]);
            UserRepository repo = new UserRepository();
            var li = repo.GetTest(id);
            int i = 0;
            List<string> ans = new List<string>();

            foreach( var dto in li)
            {
                ans.Add(Request[dto.StID.ToString()]);
            }

            i = 0;
            int correctAns = 0;

            while( i < li.Count())
            {
                if( ans[i] == li[i].CorrectOpt)
                {
                    correctAns++;
                }
                i++;
            }

            UserDTO usr = (UserDTO)Session["User"];
            int uid = usr.UserID;
            using( var ctx = new MyDBContext())
            {
                var obj = ctx.Quizes.Where(q => q.TestID == id & q.UserID == uid).FirstOrDefault();

                obj.isTaken = true;
                int oneQuestion = obj.TotalMarks / li.Count();
                obj.MarksObtained = correctAns * oneQuestion;
                obj.ConductDate = DateTime.Now.ToString();

                ctx.SaveChanges();
            }
            return View("MyResults");
        }

        public ActionResult AllResult()
        {
            UserDTO dto = (UserDTO)Session["User"];
            int uid = dto.UserID;
            UserRepository repo = new UserRepository();
            var li = repo.AllResults(uid);
            return View("MyResults", li);
        }
    }
}
