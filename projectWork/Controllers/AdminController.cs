using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projectWork.Models;

namespace projectWork.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Dashboard()
        {
            if (Session["User"] != null)
            {
                MyDBService ser = new MyDBService();
                ViewBag.UsersCount = ser.GetUserCount();
                ViewBag.UniversityStudentsCount = ser.GetUniversityStudentsCount();
                ViewBag.OutsiderStudentsCount = ser.GetOutsiderStudentsCount();
                ViewBag.TeachersCount = ser.GetTeachersCount();
                ViewBag.DisabledCOunt = ser.GetDisabledCount();
                ViewBag.QueriesCount = ser.GetQueriesCount();
                ViewBag.UnattendedQueriesCount = ser.GetUnattendedQueriesCount();
                return View();
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

        [HttpPost]
        public JsonResult SaveUser(UserDTO user)
        {
            user.isActive = true;

            UserRepository repo = new UserRepository();
            int cid = repo.SaveUser(user);

            Object obj = new
            {
                CustomerID = cid,
                success = true,
                message = "Successfully Saved"
            };

            return Json(obj);

        }

        public ActionResult Edit()
        {
            if (Session["User"] != null)
            {
                int id = Int32.Parse(Request["id"]);

                UserRepository repo = new UserRepository();
                UserDTO dto = repo.GetUserById(id);

                return View(dto);
            }
            else
            {
                return Redirect("~/Users/Login");
            }
        }

        public ActionResult ShowAll()
        {
            if (Session["User"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("~/Users/Login");
            }
        }

        public ActionResult ShowAllQueries()
        {
            if (Session["User"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("~/Users/Login");
            }
        }

        public ActionResult ShowUnattendedQueries()
        {
            if (Session["User"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("~/Users/Login");
            }
        }

        public ActionResult ShowUniversityStudents()
        {
            if (Session["User"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("~/Users/Login");
            }
        }

        public ActionResult ShowOutsiderStudents()
        {
            if (Session["User"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("~/Users/Login");
            }
        }

        public ActionResult ShowDisabled()
        {
            if (Session["User"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("~/Users/Login");
            }
        }

        public ActionResult ShowTeachers()
        {
            if (Session["User"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("~/Users/Login");
            }
        }

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            UserRepository repo = new UserRepository();
            var data = repo.GetAllUsers();

            Object obj = new
            {
                Result = data,
                success = true,
            };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAllQueries()
        {
            UserRepository repo = new UserRepository();
            var data = repo.GetAllQueries();

            Object obj = new
            {
                Result = data,
                success = true,
            };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetUnattendedQueries()
        {
            UserRepository repo = new UserRepository();
            var data = repo.GetUnattendedQueries();

            Object obj = new
            {
                Result = data,
                success = true,
            };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetUniversityStudents()
        {
            UserRepository repo = new UserRepository();
            var data = repo.GetUniversityStudents();

            Object obj = new
            {
                Result = data,
                success = true,
            };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDisabled()
        {
            UserRepository repo = new UserRepository();
            var data = repo.GetDisabled();

            Object obj = new
            {
                Result = data,
                success = true,
            };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetOutsiderStudents()
        {
            UserRepository repo = new UserRepository();
            var data = repo.GetOutsiderStudents();

            Object obj = new
            {
                Result = data,
                success = true,
            };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetTeachers()
        {
            UserRepository repo = new UserRepository();
            var data = repo.GetTeachers();

            Object obj = new
            {
                Result = data,
                success = true,
            };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ToggleStatus(UserDTO dto)
        {
            int id = dto.UserID;

            MyDBService ser = new MyDBService();
            ser.ToogleStatus(ser.GetUserById(id));

            Object obj = new
            {
                success = true
            };

            return Json(obj);
        }

        [HttpPost]
        public JsonResult EditUser(UserDTO dto)
        {
            UserRepository repo = new UserRepository();
            int cid = repo.EditUser(dto);

            Object obj = new
            {
                CustomerID = cid,
                success = true,
                message = "Successfully Edited"
            };

            return Json(obj);

        }
    }
}
