using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GymProUI.ViewModel
{
    public class CreateWorkoutViewModel
    {

        public int WorkId { get; set; }

        [Required]
        public int Weight { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int BMI { get; set; }

        [Required]
        [Display(Name = "Workouts")]
        public string WorkoutDescription { get; set; }

        [Required]
        public int GoalId{get; set;}
    }
}
