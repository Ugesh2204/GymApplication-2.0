using GPBOL;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPDAL
{
    public interface IGoalDb
    {
        //what are the operation you want to impletment
        //This i my repository Interface
        //Interface says what to do 

        //Get All the goal
        IEnumerable<Goal> GetAll();

        //Get single Goal
        Goal GetById(int Id);
        //Create goals why bool is bcoz if create is true and if fail it false
        bool Create(Goal goal);
        //Update goals
        bool Update(Goal goal);
        //Delete goals
        bool Delete(int id);


    }

    public class GoalDb : IGoalDb
    {

        GPDbContext GPDbContext;

        public GoalDb(GPDbContext _GPDbContext)
        {
            GPDbContext = _GPDbContext;
        }


        public bool Create(Goal goal)
        {
            GPDbContext.Add(goal);
            GPDbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var goal = GPDbContext.Goals.Find(id);

            GPDbContext.Remove<Goal>(goal);
            GPDbContext.SaveChanges();
            return true;
        }

        public IEnumerable<Goal> GetAll()
        {
            return GPDbContext.Goals;
        }

        public Goal GetById(int id)
        {
            var goal = GPDbContext.Goals.Find(id);
            return goal;
        }

        public bool Update(Goal goal)
        {
            GPDbContext.Update<Goal>(goal);
            GPDbContext.SaveChanges();
            return true;
        }
    }
}
