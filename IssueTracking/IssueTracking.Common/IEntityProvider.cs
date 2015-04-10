using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracking.Common
{
    public interface IEntityProvider
    {
        Issue GetIssue(int id);
        int AddIssue(string description);
        void SetState(int id, State state);
        void AddComment(int id, string text);
        void AddAssociation(int id, int assocId);
    }
}
