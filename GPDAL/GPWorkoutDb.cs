using GPBOL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPDAL
{
  

    public interface IGPWorkoutDb
    {
        //what are the operation you want to impletment
        //This i my repository Interface
        //Interface says what to do 

        //Get All the GPWorkout
        IEnumerable<GPWorkout> GetAll();

        IEnumerable<GPWorkout> GetAll(bool IsApproved);

        //Get single GPWorkout
        GPWorkout GetById(int Id);
        //Create GPWorkouts why bool is bcoz if create is true and if fail it false
        bool Create(GPWorkout GPWorkout);
        //Update GPWorkouts
        bool Update(GPWorkout GPWorkout);
        //Delete GPWorkouts
        bool Delete(int id);
    }

    public class GPWorkoutDb : IGPWorkoutDb
    {

        GPDbContext GPDbContext;

        public GPWorkoutDb(GPDbContext _GPDbContext)
        {
            GPDbContext = _GPDbContext;
        }


        public bool Create(GPWorkout GPWorkout)
        {
            GPDbContext.Add(GPWorkout);
            GPDbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var GPWorkout = GPDbContext.GPWorkouts.Find(id);

            GPDbContext.Remove<GPWorkout>(GPWorkout);
            GPDbContext.SaveChanges();
            return true;
        }

        public IEnumerable<GPWorkout> GetAll()
        {
            return GPDbContext.GPWorkouts;
        }

        public IEnumerable<GPWorkout> GetAll(bool IsApproved)
        {
            return GPDbContext.GPWorkouts.Where(x => x.IsApproved == IsApproved)
                              .Include(x=>x.Goal)
                              .Include(x=>x.User);
        }

        public GPWorkout GetById(int id)
        {
            var GPWorkout = GPDbContext.GPWorkouts.Find(id);
            return GPWorkout;
        }

        public bool Update(GPWorkout GPWorkout)
        {
            GPDbContext.Update<GPWorkout>(GPWorkout);
            GPDbContext.SaveChanges();
            return true;
        }
    }
}
