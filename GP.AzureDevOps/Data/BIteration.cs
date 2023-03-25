// Copyright © Gestion-Personal - Cristian Monzon cristian_monzon@hotmail.com

using System.Collections.Generic;
using System.Threading.Tasks;
using GP.AzureDevOps.Business;
using GP.AzureDevOps.Data.Json.Iteration;

namespace GP.AzureDevOps.Data
{
    public class BIteration
    {
        public IList<BIssue> Issues { get; set; }

        public bool IsCurrent
        {
            get
            {
                return (JsonIterationValue.attributes.finishDate < System.DateTime.Now &&
                        JsonIterationValue.attributes.startDate > System.DateTime.Now);
            }
        }

        public string Id
        {
            get
            {
                return (JsonIterationValue.id);
            }
        }

        public string Name
        {
            get
            {
                return (JsonIterationValue.name);
            }
        }

        public string FullName
        {
            get
            {
                return ($"{Name} * {StartDate} {FinishDate}");
            }
        }

        public string StartDate
        {
            get
            {
                return (JsonIterationValue.attributes.startDate.ToShortDateString());
            }
        }

        public string FinishDate
        {
            get
            {
                return (JsonIterationValue.attributes.finishDate.ToShortDateString());
            }
        }

        private Value jsonIterationValue;
        private Value JsonIterationValue
        {
            get
            {
                if (jsonIterationValue == null)
                {
                    jsonIterationValue = new Value();
                    jsonIterationValue.attributes = new Attributes();
                }
                return jsonIterationValue;
            }
        }

        public BIteration(Value value)
        {
            jsonIterationValue = value;
            Issues = new List<BIssue>();
        }

        public void SetIssueChield(string projectName)
        {
            WorkItemBusiness workItemBusiness = new WorkItemBusiness(projectName, Name);
            Task<IList<BIssue>> task = workItemBusiness.GetIssueWithWorkItem();
            Issues = task.Result;
        }
    }
}