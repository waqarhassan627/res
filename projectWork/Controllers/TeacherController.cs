using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projectWork.Models;

namespace projectWork.Controllers
{
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/

        public ActionResult CreateTest()
        {
            if( Session["User"] != null )
            {
                return View("CreateTest");
            }
            else
            {
                return Redirect("~/Users/Login");
            }
        }

        public ActionResult FillTest()
        {
            if (Session["User"] != null)
            {
                return View("FillTest");
            }
            else
            {
                return Redirect("~/Users/Login");
            }
        }

        public ActionResult Home()
        {
            if (Session["User"] != null)
            {
                return Reports();
            }
            else
            {
                return Redirect("~/Users/Login");
            }
        }

        public ActionResult Result()
        {
            return GetResult();
        }

        public ActionResult EnterTest()
        {
            string title = Request["Title"];
            string desc = Request["Description"];
            string sec = Request["Section"];
            string dt = Request["Date"];
            int t_mrks= int.Parse( Request["marks"]);

            TestDTO t_dto = new TestDTO();
            t_dto.Title = title;
            t_dto.Description = desc;
            t_dto.Section = sec;
            t_dto.Date = dt;
            t_dto.TotalMarks = t_mrks;
            UserDTO usr = (UserDTO)Session["User"];
            t_dto.TeacherUname = usr.Username;

            UserRepository repo = new UserRepository();
            int tid = repo.SaveTest(t_dto);

            ViewBag.tid = tid;
            if(tid > 0)
            {
                repo.SaveStudentsQuiz(t_dto);
                return View("FillTest");
            }
            else
            {
                return View("CreateTest", tid);
            }
        }

        public ActionResult EnterQuestion()
        {
            string st = Request["Statement"];
            string optA = Request["A"];
            string optB = Request["B"];
            string optC = Request["C"];
            string optD = Request["D"];
            string correct = Request["CorrectOpt"];
            int testid = int.Parse( Request["tid"]);

            TestQuestionsDTO tq_dto = new TestQuestionsDTO();
            tq_dto.Statement= st;
            tq_dto.OptA = optA;
            tq_dto.OptB = optB;
            tq_dto.OptC = optC;
            tq_dto.OptD = optD;
            tq_dto.CorrectOpt = correct;
            tq_dto.TestID = testid;

            UserRepository repo = new UserRepository();
            int tid = repo.SaveQuestion(tq_dto);
            ViewBag.tid = tid;
            if (tid > 0)
            {
                return View("FillTest");
            }
            else
            {
                return View("CreateTest", tid);
            }
        }

        public ActionResult Reports()
        {
            // First Get TestTitle from 'Test' where TeacherUName = this.TeacherUName in one Ajax hit and display them
            // If teacher click on the test than then Query from Quizes Against Each TestID.
            // We use ajax for this.

            UserDTO dto = (UserDTO) Session["User"];
            string uname = dto.Username;

            UserRepository repo = new UserRepository();
            var li = repo.StudentResult(uname);
            return View("Home", li);
        }

        public ActionResult GetResult()
        {
            int tid = int.Parse(Request["testid"]);
            string title = Request["t_Title"];
            UserRepository repo = new UserRepository();
            var li = repo.GetResult(tid);
            ViewBag.title = title;
            return View("Result", li);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return Redirect("~/Main/Home");
        }

    }
}
