using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GPBLL;
using GymProUI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GymProUI.Controllers
{
    public class BrowseWorkoutController : Controller
    {
        IGPWorkoutBs GPWorkoutBs;
        public BrowseWorkoutController(IGPWorkoutBs _GPWorkoutBs)
        {
            GPWorkoutBs = _GPWorkoutBs;
        }


        public IActionResult Index()
        {
            List<BrowseWorkoutViewmodel> browseWorkouts = new List<BrowseWorkoutViewmodel>();
            var workouts = GPWorkoutBs.GetAll(true);
            foreach(var item in workouts)
            {
                BrowseWorkoutViewmodel model = new BrowseWorkoutViewmodel()
                {
                    WorkId = item.WorkId,
                    Weight = item.Weight,
                    Height =item.Height,
                    BMI = item.BMI,
                    WorkoutDescription = System.Net.WebUtility.HtmlDecode(item.WorkoutDescription),
                   // WorkoutDescription = item.WorkoutDescription,

                    GoalName = item.Goal.GoalName,
                    UserName = item.User.UserName
                };
                browseWorkouts.Add(model);
            }
            return View(browseWorkouts);
        }
    }
}