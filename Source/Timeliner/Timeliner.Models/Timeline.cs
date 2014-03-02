using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timeliner.Models
{
    public class Timeline
    {
        public Timeline()
        {
            Goals = new List<Goal>();
        }

        public IList<Goal> Goals { get; set; }

        public void Generate()
        {
            foreach (var goal in Goals)
            {
                goal.EndDate = CalculateCompletionDate(goal);
            }
        }

        private DateTime CalculateCompletionDate(Goal goal)
        {
            if (!string.IsNullOrEmpty(goal.Predecessor))
            {
                var pre = Goals.FirstOrDefault(o => o.Name == goal.Predecessor);

                if (pre == null)
                    throw new NullReferenceException("Predecessor does not exist in goal list.");

                pre.EndDate = CalculateCompletionDate(pre);
                goal.StartDate = pre.EndDate.Value.AddDays(1);

                return goal.StartDate.Value.Add(goal.Duration);
            }

            if (goal.StartDate.HasValue)
                return goal.StartDate.Value.Add(goal.Duration);

            throw new NullReferenceException("Either a goal start date or a predescessor was not specified.");
        }
    }
}
