using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projectWork.Models;

namespace projectWork.Controllers
{
    public class OutsiderStudentController : Controller
    {
        //
        // GET: /OutsiderStudent/

        public ActionResult Home()
        {
            return getAllCertificate();
        }

        public ActionResult CertificationTest()
        {
            string cname = Request["c_name"];
            return GetCertificateTest(cname);
        }

        public ActionResult CourseRegister()
        {
            return View("CourseRegister");
        }

        public ActionResult MyResult()
        {
            return GetAllResult();
        }

        public ActionResult getAllCertificate()
        {
            UserDTO usr = (UserDTO)Session["User"];
            int id = usr.UserID;
	        UserRepository repo = new UserRepository();
	        var list = repo.getAllCertificate(id);

            return View("Home", list);
        }

        public ActionResult GetCertificateTest( string cname )
        {
	        UserRepository repo = new UserRepository();
            var msoffice = new List<MsOfficeDTO>();
            var ccna = new List<CCNAdto>();
            var dba = new List<DBAdto>();
            var dotnet = new List<DotNetDTO>();
            var photoshop = new List<PhotoShopDTO>();
            var php = new List<PHPdto>();

            Random random = new Random();
            int[] array = new int[30];
            int number;

            for (int i = 0; i < 30; i++)
            {
                number = random.Next(0, 49);
                if (!array.Contains(number)) //If it's not contains, add number to array;
                    array[i] = number;
                else //If it contains, restart random process
                    i--;
            }

            if( cname == "MSOffice")
            {
                var arr = repo.MSOfficeTest();

                for (int i = 0; i < 30; i++)
                {
                    //Error
                    if (array[i] < arr.Count())
                    {
                        msoffice.Add(arr[array[i]]);
                    }
                }
                ViewBag.Coursename = "MSOffice";
                ViewBag.Test = msoffice;
                return View("CertificationTest");
            }
            if (cname == "CCNA")
            {
                var arr = repo.CCNATest();

                for (int i = 0; i < 30; i++)
                {
                    if (array[i] < arr.Count())
                    {
                        ccna.Add(arr[array[i]]);
                    }
                }

                ViewBag.Coursename = "CCNA";
                ViewBag.Test = ccna;
                return View("CertificationTest");
            }
            if (cname == "DBA")
            {
                var arr = repo.DBATest();

                for (int i = 0; i < 30; i++)
                {
                    if (array[i] < arr.Count())
                    {
                        dba.Add(arr[array[i]]);
                    }
                }
                ViewBag.Coursename = "DBA";
                ViewBag.Test = dba;
                return View("CertificationTest");
            }
            if (cname == "DotNet")
            {
                var arr = repo.DotNetTest();

                for (int i = 0; i < 30; i++)
                {
                    if (array[i] < arr.Count())
                    {
                        dotnet.Add(arr[array[i]]);
                    }
                }
                ViewBag.Coursename = "DotNet";
                ViewBag.Test = dotnet;
                return View("CertificationTest");
            }
            if (cname == "Photoshop")
            {
                var arr = repo.PhotoShopTest();

                for (int i = 0; i < 30; i++)
                {
                    if (array[i] < arr.Count())
                    {
                        photoshop.Add(arr[array[i]]);
                    }
                }
                ViewBag.Coursename = "PhotoShop";
                ViewBag.Test = photoshop;
                return View("CertificationTest");
            }
            if (cname == "PHP")
            {
                var arr = repo.PhpTest();
                
                for (int i = 0; i < 30; i++)
                {
                    if (array[i] < arr.Count())
                    {
                        php.Add(arr[array[i]]);
                    }
                }

                ViewBag.Coursename = "PHP";
                ViewBag.Test = php;
                return View("CertificationTest");
            }

            ViewBag.ErrMsg = "Error while Loading Test. Try Again!!!!";
            return View("Home");
        }

        public ActionResult SaveCourse()
        {
            UserDTO dto = (UserDTO)Session["User"];
            int id = dto.UserID;
            string course = Request["CourseName"];
            int fee = 0;
            if (course == "CCNA")
            {
                fee = 2000;
            }
            if (course == "DotNet")
            {
                fee = 1000;
            }
            if (course == "DBA")
            {
                fee = 2500;
            }
            if (course == "PHP")
            {
                fee = 1000;
            }
            if (course == "MSOffice")
            {
                fee = 2000;
            }
            if (course == "PhotoShop")
            {
                fee = 1500;
            }

            CoursesDTO c_dto = new CoursesDTO();
            c_dto.UserID = id;
            c_dto.isTaken = false;
            c_dto.ObtainedMarks = 0;
            c_dto.CourseFee = fee;
            c_dto.CourseName = course;
            c_dto.grade = "";

            UserRepository repo = new UserRepository();
            repo.SaveCourse(c_dto);

            return getAllCertificate();
        }

        public ActionResult GetAllResult()
        {
            UserDTO usr = (UserDTO)Session["User"];
            int id = usr.UserID;
            UserRepository repo = new UserRepository();
            var list = repo.GetCourseResult(id);

            return View("MyResult", list);
        }

        public ActionResult SubmitTest()
        {
            string cname = Request["cname"];
            UserDTO usr = (UserDTO)Session["User"];
            int id = usr.UserID;

            UserRepository repo = new UserRepository();
            var msoffice = new List<MsOfficeDTO>();
            var ccna = new List<CCNAdto>();
            var dba = new List<DBAdto>();
            var dotnet = new List<DotNetDTO>();
            var photoshop = new List<PhotoShopDTO>();
            var php = new List<PHPdto>();
            List<string> ans = new List<string>();
            List<string> ques = new List<string>();
            int correctAns = 0;

            if (cname == "MSOffice")
            {
                var arr = repo.MSOfficeTest();
                foreach (var dto in arr)
                {
                    ans.Add(Request[dto.Statement.ToString()]);
                    ques.Add(Request[dto.StID.ToString()]);
                }
                int i = 0;
                int j = 0;
                while (i < ques.Count() && j < arr.Count() )
                {
                    if ( ques[i] == arr[j].Statement && ans[i] == arr[j].CorrectOpt)
                    {
                        correctAns++;
                        i++;
                        j = 0;
                    }
                    j++;
                }
            }
            if (cname == "CCNA")
            {
                var arr = repo.CCNATest();
                foreach (var dto in arr)
                {
                    ans.Add(Request[dto.Statement.ToString()]);
                    ques.Add(Request[dto.StID.ToString()]);
                }
                int i = 0; 
                int j = 0;
                
                while (i < ques.Count())
                {
                    if (ques[i] == arr[i].Statement && ans[i] == arr[i].CorrectOpt)
                    {
                        correctAns++;
                        i++;
                    }
                    j++;
                }
            }
            if (cname == "DBA")
            {
                var arr = repo.DBATest();
                foreach (var dto in arr)
                {
                    ans.Add(Request[dto.Statement.ToString()]);
                    ques.Add(Request[dto.StID.ToString()]);
                }
                int i = 0;
                int j = 0;
                
                while (i < ques.Count())
                {
                    if (ques[i] == arr[i].Statement && ans[i] == arr[i].CorrectOpt)
                    {
                        correctAns++;
                        i++;
                    }
                    j++;
                }
            }
            if (cname == "DotNet")
            {
                var arr = repo.DotNetTest();
                foreach (var dto in arr)
                {
                    ans.Add(Request[dto.Statement.ToString()]);
                    ques.Add(Request[dto.StID.ToString()]);
                }
                int i = 0;
                int j = 0;
                
                while (i < ques.Count())
                {
                    if (ques[i] == arr[i].Statement && ans[i] == arr[i].CorrectOpt)
                    {
                        correctAns++;
                        i++;
                    }
                    j++;
                }
            }
            if (cname == "Photoshop")
            {
                var arr = repo.PhotoShopTest();
                foreach (var dto in arr)
                {
                    ans.Add(Request[dto.Statement.ToString()]);
                    ques.Add(Request[dto.StID.ToString()]);
                }
                int i = 0;
                int j = 0;

                while (i < ques.Count())
                {
                    if (ques[i] == arr[i].Statement && ans[i] == arr[i].CorrectOpt)
                    {
                        correctAns++;
                        i++;
                    }
                    j++;
                }
            }
            if (cname == "PHP")
            {
                var arr = repo.PhpTest();
                foreach (var dto in arr)
                {
                    ans.Add(Request[dto.Statement.ToString()]);
                    ques.Add(Request[dto.StID.ToString()]);
                }
                int i = 0;
                int j = 0;

                while (i < ques.Count())
                {
                    if (ques[i] == arr[i].Statement && ans[i] == arr[i].CorrectOpt)
                    {
                        correctAns++;
                        i++;
                    }
                    j++;
                }
            }

            CoursesDTO newdto = new CoursesDTO();
            newdto.isTaken = true;
            newdto.ObtainedMarks = correctAns * 1;
            string grade = "";
            if( correctAns > 25 )
            {
                grade = "A";
            }
            else if (correctAns < 25 && correctAns > 20)
            {
                grade = "B";
            }
            else if (correctAns < 20 && correctAns > 15)
            {
                grade = "C";
            }
            else if (correctAns < 15 && correctAns > 10)
            {
                grade = "D";
            }
            else 
            {
                grade = "F";
            }
            newdto.grade = grade;
            newdto.CourseName = cname;
            newdto.UserID = id;
            repo.SaveResult(newdto);

            return View("Home");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return Redirect("~/Main/Home");
        }

    }
}
