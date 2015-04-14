using System;
using System.Linq;

namespace IssueTracking.Common
{
    /// <summary>
    /// Note: Associations between issue are directional, i.e., issue A may be assoicated to 
    /// issue B, while issue B may have no association to issue A.
    /// </summary>
    public partial class ModelContainer : IModelContainer
    {
        public Issue GetIssue(int id)
        {
            var issue = Issues.SingleOrDefault(i => i.Id == id);

            if (issue == default(Issue))
                throw new Exception("Issue id does not correspond to a valid entry");

            return issue;
        }

        public int AddIssue(string description)
        {
            var issue = new Issue
            {
                Description = description,
                State = State.New
            };

            Issues.Add(issue);
            SaveChanges();

            return issue.Id;
        }

        public void SetState(int id, State state)
        {
            if (!Enum.IsDefined(typeof (State), state))
                throw new Exception("State value does not correspond to a valid state");

            var issue = Issues.SingleOrDefault(i => i.Id == id);

            if (issue == default(Issue))
                throw new Exception("Issue id does not correspond to a valid entry");

            issue.State = state;
            SaveChanges();
        }

        public void AddComment(int id, string text)
        {
            var issue = Issues.SingleOrDefault(i => i.Id == id);

            if (issue == default(Issue))
                throw new Exception("Issue id does not correspond to a valid entry");

            issue.Comments.Add(new Comment {Text = text});
            SaveChanges();
        }

        public void AddAssociation(int id, int assocId)
        {
            var parent = Issues.SingleOrDefault(i => i.Id == id);
            var child = Issues.SingleOrDefault(i => i.Id == assocId);

            if (parent == default(Issue) || child == default(Issue))
                throw new Exception("Issue id does not correspond to a valid entry");

            if (parent == child)
                throw new Exception("Attempting to create a circular association");

            if (parent.AssocIssues.Contains(child))
                throw new Exception("Attempting to add an existing association");

            parent.AssocIssues.Add(child);
            SaveChanges();
        }
    }
}