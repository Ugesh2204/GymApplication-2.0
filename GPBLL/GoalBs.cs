using GPBOL;
using GPDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPBLL
{
    public interface IGoalBs
    {
       
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


    public class GoalBs : IGoalBs
    {

        IGoalDb GoalDb;

        public GoalBs(IGoalDb _GoalDb)
        {
            GoalDb = _GoalDb;
        }


        public bool Create(Goal goal)
        {
            return GoalDb.Create(goal);
        }

        public bool Delete(int id)
        {
            return GoalDb.Delete(id);
        }

        public IEnumerable<Goal> GetAll()
        {
            var goals = GoalDb.GetAll();
            return goals;
        }

        public Goal GetById(int id)
        {
            var goal = GoalDb.GetById(id);
            return goal;
        }

        public bool Update(Goal goal)
        {
            return GoalDb.Update(goal);
        }
    }
}
