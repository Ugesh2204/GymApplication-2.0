using GPBOL;
using GPDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPBLL
{
    public interface IGPWorkoutBs
    {
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


    public class GPWorkoutBs : IGPWorkoutBs
    {
        IGPWorkoutDb GPWorkoutDb;

        public GPWorkoutBs(IGPWorkoutDb _GPWorkoutDb)
        {
            GPWorkoutDb = _GPWorkoutDb;
        }

        public bool Create(GPWorkout GPWorkout)
        {
            return GPWorkoutDb.Create(GPWorkout);
        }

        public bool Delete(int id)
        {
            return GPWorkoutDb.Delete(id);
        }

        public IEnumerable<GPWorkout> GetAll()
        {
            var GPWorkouts = GPWorkoutDb.GetAll();
            return GPWorkouts;
        }

        public IEnumerable<GPWorkout> GetAll(bool IsApproved)
        {

            var GPWorkouts = GPWorkoutDb.GetAll(IsApproved);
            return GPWorkouts;
        }

        public GPWorkout GetById(int id)
        {
            var GPWorkout = GPWorkoutDb.GetById(id);
            return GPWorkout;
        }

        public bool Update(GPWorkout GPWorkout)
        {
            return GPWorkoutDb.Update(GPWorkout);
        }
    }
}
