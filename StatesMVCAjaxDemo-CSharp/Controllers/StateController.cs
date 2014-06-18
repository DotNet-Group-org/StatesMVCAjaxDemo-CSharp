using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using StatesMVCAjaxDemo_CSharp.Models;

namespace StatesMVCAjaxDemo_CSharp.Controllers
{
    public class StateController : Controller
    {
        private IRepository stateRepository;

        public StateController()
	    {
            stateRepository = new Repository();
	    }

        public StateController(ref IRepository repository)
	    {
            stateRepository = repository;
	    }

        //
        // GET: /State/

        public ActionResult Index()
        {
            return RedirectToAction("Index", "States");
        }

        //
        // GET: /State/Details/5

        public ActionResult Details(string id)
        {
            StateDetailModel model;
            model = stateRepository.GetStateDetails(id);

            return View(model);
        }

        //
        // GET: /State/Create

        public ActionResult Create()
        {
            List<StateNameEntryModel> model;
            State entry = new State();

            // can't pass the StateDetailModel object to the view as it then causes
            // the Create action to not properly propulate the State object.
            //
            // so instead, passing the stateDetails as the model, and the stateNames via the ViewBag
            model = stateRepository.GetAllStateNames();
            ViewBag.stateNames = model;
            return View(entry);
        } 

        //
        // POST: /State/Create

        [HttpPost]
        public ActionResult Create(State entry)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    stateRepository.SaveStateDetails(entry);

                    return RedirectToAction("Details", "State", new { id = entry.stateAbbr });
                }
                else
                {
                    List<StateNameEntryModel> model = null;
                    model = stateRepository.GetAllStateNames(entry.stateAbbr);

                    ViewBag.stateNames = model;
                    return View(entry);
                }
            }
            catch
            {
                return RedirectToAction("Details", "State", new { id = entry.stateAbbr });
            }

        }
        
        //
        // GET: /State/Edit/5
 
        public ActionResult Edit(string id)
        {
            StateDetailModel model;
            model = stateRepository.GetStateDetails(id, false);

            // can't pass the StateDetailModel object to the view as it then causes
            // the Edit action to not properly propulate the State object.
            //
            // so instead, passing the stateDetails as the model, and the stateNames via the ViewBag

            ViewBag.stateNames = model.stateNames;
            return View(model.stateDetails);
        }

        //
        // POST: /State/Edit/5

        [HttpPost]
        public ActionResult Edit(State entry)
        {
            try {
                if (ModelState.IsValid) {
                    stateRepository.SaveStateDetails(entry);

                    return RedirectToAction("Details", "State", new {id = entry.stateAbbr});
                } else {
                    List<StateNameEntryModel> model;
                    model = stateRepository.GetAllStateNames(entry.stateAbbr);

                    ViewBag.stateNames = model;
                    return View(entry);
                }
            } catch {
                return RedirectToAction("Details", "State", new {id = entry.stateAbbr});
            }
        }

        //
        // GET: /State/Delete/5
 
        public ActionResult Delete(string id)
        {
            stateRepository.DeleteState(id);
            return RedirectToAction("Index", "States");
        }

        //
        // POST: /State/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
