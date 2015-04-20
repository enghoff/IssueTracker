using System.Data.Entity;

namespace IssueTracking.Common
{
    public interface IModelContainer
    {
        //DbSet<Issue> Issues { get; set; }
        //DbSet<Comment> Comments { get; set; }
        Issue GetIssue(int id);
        int AddIssue(string description);
        void SetState(int id, State state);
        void AddComment(int id, string text);
        void AddAssociation(int id, int assocId);
    }
}