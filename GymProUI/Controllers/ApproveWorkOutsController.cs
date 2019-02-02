using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GPBLL;
using GymProUI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymProUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ApproveWorkOutsController : Controller
    {
        IGPWorkoutBs GPWorkoutBs;
        public ApproveWorkOutsController(IGPWorkoutBs _GPWorkoutBs)
        {
            GPWorkoutBs = _GPWorkoutBs;
        }
       
        public IActionResult Index()
        {
            List<ApproveWorkoutsViewModel> approveWorkouts = new List<ApproveWorkoutsViewModel>();
            var workouts = GPWorkoutBs.GetAll(false);

            foreach (var item in workouts)
            {
                ApproveWorkoutsViewModel model = new ApproveWorkoutsViewModel()
                {
                    WorkId = item.WorkId,
                    Weight = item.Weight,
                    Height = item.Height,
                    BMI = item.BMI,
                    WorkoutDescription = System.Net.WebUtility.HtmlDecode(item.WorkoutDescription),
                    // WorkoutDescription = item.WorkoutDescription,

                    GoalName = item.Goal.GoalName,
                    UserName = item.User.UserName,

                    IsApproved = item.IsApproved

                };
                approveWorkouts.Add(model);
            }

            return View(approveWorkouts);
        }

        [HttpPost]
        public IActionResult Approve(int WorkId)
        {
            var GpWorkout = GPWorkoutBs.GetById(WorkId);
            GpWorkout.IsApproved = true;
            GPWorkoutBs.Update(GpWorkout);
            return RedirectToAction("Index");
        }
    }
}