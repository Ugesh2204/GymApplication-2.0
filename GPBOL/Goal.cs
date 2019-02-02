using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GPBOL
{
    [Table("Goal")]
    public class Goal
    {
        [Key]
        public int GoalId { get; set; }
        public string GoalName { get; set; }
        
        //1 goals can have n number of workout
        public IEnumerable<GPWorkout> GPWorkouts { get; set;}
    }
}
