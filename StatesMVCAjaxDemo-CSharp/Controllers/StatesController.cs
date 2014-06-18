using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

using StatesMVCAjaxDemo_CSharp.Models;

namespace StatesMVCAjaxDemo_CSharp.Controllers
{
    public class StatesController : Controller
    {
        private IRepository stateRepository;

        public StatesController()
	    {
            stateRepository = new Repository();
	    }

        public StatesController(ref IRepository repository)
	    {
            stateRepository = repository;
	    }

        //
        // GET: /States/

        public ActionResult Index()
        {
            List<StateNameEntryModel> model;
            model = stateRepository.GetAllStateNames();

            return View(model);
        }

        public PartialViewResult GetStateDetails(string id)
        {
            StateDetailModel model;
            model = stateRepository.GetStateDetails(id);

            return PartialView("StateDetails", model.stateDetails);
        }

        // an action returning json result must be invoked by via POST
        [HttpPost]
        public JsonResult GetCounties(string id)
        {
            return Json(stateRepository.GetCounties(id));
        }
    }

}
