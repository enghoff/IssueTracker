using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using IssueTracking.Common;

namespace IssueTracking.ServiceModel
{
    [Route("/issue")]
    [Route("/issue/get/{Id}")]
    public class GetIssue : IReturn<GetIssueResponse>
    {
        public int Id { get; set; }        
    }

    public class GetIssueResponse
    {
        public string Description { get; set; }
        public int State { get; set; }
        public string[] Comments { get; set; }
        public int[] Associations { get; set; }
    }

    [Route("/issue")]
    [Route("/issue/add/{Description}")]
    public class AddIssue : IReturn<AddIssueResponse>
    {
        public string Description { get; set; }
    }

    public class AddIssueResponse
    {
        public int Id { get; set; }
    }

    [Route("/state")]
    [Route("/state/set/{Id}/{State}")]
    public class SetState : IReturnVoid
    {
        public int Id { get; set; }
        public State State { get; set; }
    }

    [Route("/comment")]
    [Route("/comment/add/{Id}/{Comment}")]
    public class AddComment : IReturnVoid
    {
        public int Id { get; set; }
        public string Comment { get; set; }
    }

    [Route("/association")]
    [Route("/association/add/{Id}/{Association}")]
    public class AddAssociation : IReturnVoid
    {
        public int Id { get; set; }
        public int Association { get; set; }
    }
}