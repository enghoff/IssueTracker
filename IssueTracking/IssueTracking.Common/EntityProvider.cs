using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracking.Common
{
    public class EntityProvider : IEntityProvider
    {
        private readonly ModelContainer _context = new ModelContainer();

        /*
         * Note: Associations between issue are directional, i.e., issue A may be assoicated to 
         * issue B, while issue B may have no association to issue A.
         */

        public Issue GetIssue(int id)
        {
            var issue = _context.Issues.SingleOrDefault(i => i.Id == id);

            if (issue == default(Issue))
                throw new Exception("Issue id does not correspond to a valid entry");

            return issue;
        }
        
        public int AddIssue(string description)
        {
            var issue = new Issue()
            {
                Description = description,
                State = State.New,
            };

            _context.Issues.Add(issue);
            _context.SaveChanges();

            return issue.Id;
        }

        public void SetState(int id, State state)
        {
            if (!Enum.IsDefined(typeof(State), state))
                throw new Exception("State value does not correspond to a valid state");
            
            var issue = _context.Issues.SingleOrDefault(i => i.Id == id);

            if (issue == default(Issue))
                throw new Exception("Issue id does not correspond to a valid entry");

            issue.State = state;
            _context.SaveChanges();
        }

        public void AddComment(int id, string text)
        {
            var issue = _context.Issues.SingleOrDefault(i => i.Id == id);

            if (issue == default(Issue))
                throw new Exception("Issue id does not correspond to a valid entry");

            issue.Comments.Add(new Comment() { Text = text });
            _context.SaveChanges();
        }

        public void AddAssociation(int id, int assocId)
        {
            var parent = _context.Issues.SingleOrDefault(i => i.Id == id);
            var child = _context.Issues.SingleOrDefault(i => i.Id == assocId);

            if (parent == default(Issue) || child == default(Issue))
                throw new Exception("Issue id does not correspond to a valid entry");

            if (parent == child)
                throw new Exception("Attempting to create a circular association");

            if (parent.AssocIssues.Contains(child))
                throw new Exception("Attempting to add an existing association");

            parent.AssocIssues.Add(child);
            _context.SaveChanges();
        }
    }
}
