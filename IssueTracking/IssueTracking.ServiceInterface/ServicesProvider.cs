using System.Linq;
using IssueTracking.Common;
using IssueTracking.ServiceModel;
using ServiceStack;

namespace IssueTracking.ServiceInterface
{
    public class ServicesProvider : Service
    {
        private readonly IModelContainer _model;

        public ServicesProvider(IModelContainer model)
        {
            _model = model;
        }

        public object Any(GetIssue request)
        {
            var issue = _model.GetIssue(request.Id);

            return new GetIssueResponse
            {
                Description = issue.Description,
                State = (int) (issue.State),
                Comments = issue.Comments.Select(c => c.Text).ToArray(),
                Associations = issue.AssocIssues.Select(a => a.Id).ToArray()
            };
        }

        public object Any(AddIssue request)
        {
            var response = _model.AddIssue(request.Description);

            return new AddIssueResponse {Id = response};
        }

        public void Any(SetState request)
        {
            _model.SetState(request.Id, request.State);
        }

        public void Any(AddComment request)
        {
            _model.AddComment(request.Id, request.Comment);
        }

        public void Any(AddAssociation request)
        {
            _model.AddAssociation(request.Id, request.Association);
        }
    }
}