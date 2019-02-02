using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GPBOL
{
    [Table("GPworkout")]
    public class GPWorkout
    {
        [Key]
        public int WorkId { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int BMI { get; set; }
        public string WorkoutDescription { get; set; }
        public bool IsApproved { get; set; }

        //This workout belong to what goals
        [ForeignKey("Goal")]
        public int GoalId { get; set; }

        //ogject of goal
        public Goal Goal { get; set; }

        //This workout is submitted by a particular user
        [ForeignKey("User")]
        public string Id { get; set; }

        public GPUser User { get; set; }
    }
}
