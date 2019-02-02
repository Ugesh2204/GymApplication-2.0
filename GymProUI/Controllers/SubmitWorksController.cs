using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GPBLL;
using GPBOL;
using GymProUI.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymProUI.Controllers
{
    public class SubmitWorksController : Controller
    {
        UserManager<GPUser> userManager;
        IGPWorkoutBs GPWorkoutBs;
        IGoalBs GoalBs;

        public SubmitWorksController(UserManager<GPUser> _userManager,  IGPWorkoutBs _GPWorkoutBs, IGoalBs _GoalBs)
        {
            userManager = _userManager;
            GPWorkoutBs = _GPWorkoutBs;
            GoalBs = _GoalBs;
        }


        public IActionResult Index()
        {
           
            return View();
        }

        [HttpGet]
        public IActionResult CreateWorkout()
        {
            ViewBag.Goals = GoalBs.GetAll();
            return View();
        }

       

        [HttpPost]
        public async Task<IActionResult> CreateWorkout(CreateWorkoutViewModel model)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);


            if (ModelState.IsValid)
            {
                GPWorkout gpworkout = new GPWorkout()
                {
                    Weight = model.Weight,
                    Height = model.Height,
                    BMI = model.BMI,
                    WorkoutDescription = model.WorkoutDescription,
                    GoalId = model.GoalId,
                    IsApproved = false,
                    Id = user.Id
                };
                GPWorkoutBs.Create(gpworkout);
                return RedirectToAction("CreateWorkout");

            }

            ViewBag.Goals = GoalBs.GetAll();
            return View();
        }

    }
}