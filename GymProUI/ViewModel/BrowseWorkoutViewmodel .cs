using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymProUI.ViewModel
{
    public class BrowseWorkoutViewmodel
    {

        public int WorkId { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int BMI { get; set; }
        public string WorkoutDescription { get; set; }
        public string GoalName { get; set; }
        public string UserName { get; set; }
    }
}
