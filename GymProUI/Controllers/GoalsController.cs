using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GPBLL;
using GPBOL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymProUI.Controllers
{
    public class GoalsController : Controller
    {
        //dependency Inject
        IGoalBs goalBs;

        public GoalsController(IGoalBs _goalBs)
        {
            goalBs = _goalBs;
        }

        public IActionResult Index()
        {
            var goals = goalBs.GetAll();
            return View(goals);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Goal goal)
        {
            try
            {
                goalBs.Create(goal);
                TempData["Msg"] = "Created Successfully";
                return RedirectToAction("Insert");
            }
            catch (Exception el)
            {
                TempData["Msg"] = "Delete Failed : " + el.Message;
                return RedirectToAction("Insert");
            }
        }


        [HttpGet]
        public IActionResult Edit(int GoalId)
        {
            var goals = goalBs.GetById(GoalId);
            return View(goals);
        }


        [HttpPost]
        public IActionResult Edit(Goal goal)
        {
            if (ModelState.IsValid)
            {
                goalBs.Update(goal);
                return RedirectToAction("Index");
            }

            return View();
        }


        [HttpGet]
        public IActionResult Delete(int GoalId)
        {
            goalBs.Delete(GoalId);

            return RedirectToAction("Index");

        }

        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeleteGoal(int GoalId, Goal goal)
        //{
        //    goalBs.Delete(GoalId);
        //    return RedirectToAction("Index");
            
        //}

    }
}








