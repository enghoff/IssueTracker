using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using IssueTracking.ServiceModel;
using IssueTracking.Common;

namespace IssueTracking.ServiceInterface
{
    public class ServicesProvider : Service
    {
        private readonly IEntityProvider _entityProvider = new EntityProvider();

        public object Any(GetIssue request)
        {
            var issue = _entityProvider.GetIssue(request.Id);

            return new GetIssueResponse()
            {
                Description = issue.Description,
                State = (int) (issue.State),
                Comments = issue.Comments.Select(c => c.Text).ToArray(),
                Associations = issue.AssocIssues.Select(a => a.Id).ToArray()
            };
        }

        public object Any(AddIssue request)
        {
            var response = _entityProvider.AddIssue(request.Description);

            return new AddIssueResponse { Id = response };
        }

        public void Any(SetState request)
        {
            _entityProvider.SetState(request.Id, request.State);
        }

        public void Any(AddComment request)
        {
            _entityProvider.AddComment(request.Id, request.Comment);
        }

        public void Any(AddAssociation request)
        {
            _entityProvider.AddAssociation(request.Id, request.Association);
        }
    }
}