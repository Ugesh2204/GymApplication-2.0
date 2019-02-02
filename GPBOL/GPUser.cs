using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPBOL
{
    [Table("User")]
    public class GPUser:IdentityUser
    {
        
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Image { get; set; }
        public string Gender { get; set; }
        public string About { get; set; }
       

        //1 user can sumbit n number of url
        public IEnumerable<GPWorkout> GPWorkouts { get; set; }
    }
}
