using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projectWork.Models;

namespace projectWork.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /Main/

        public ActionResult Home()
        {
            return View("Home");
        }

        public ActionResult SubmitQuery()
        {
            QueriesDTO dto = new QueriesDTO();
            dto.FullName = Request["name"];
            dto.Email = Request["email"];
            dto.msg = Request["message"];

            UserRepository repo = new UserRepository();
            repo.SaveQuery(dto);

            return View("Home");
        }

    }
}
