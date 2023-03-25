// Copyright © Gestion-Personal - Cristian Monzon cristian_monzon@hotmail.com

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GP.AzureDevOps.Business.Configuration;
using GP.AzureDevOps.Data.Json.WorkItem;
using GP.AzureDevOps.Data.Json.WorkItemIssue;

namespace GP.AzureDevOps.Data
{
    public class BIssue : BaseWorkItem
    {
        public List<BWorkItem> WorkItems { get; set; }

        private JsonWorkItemIssue JsonWorkItemList { get; }

        public int Id
        {
            get
            {
                if (FirstValue.fields == null) return 0;
                return FirstValue.id;
            }
        }

        public Value FirstValue
        {
            get
            {
                if (JsonWorkItemList.value != null && JsonWorkItemList.value.Any())
                {

                    return JsonWorkItemList.value.First();
                }
                else
                {
                    return new Value();
                }
            }
        }

        public string Title
        {
            get
            {
                if (FirstValue.fields == null) return "";
                return FirstValue.fields.SystemTitle;
            }
        }


        public string ShortTitle
        {
            get
            {
                string returnValue = Title;

                string textToRemove = "I want to ";

                int position = returnValue.IndexOf(textToRemove);
                if (position > 0) returnValue = FirstLetterCapital(Title.Remove(0, position + textToRemove.Length).Trim());

                return returnValue;
            }
        }

        public Color ColorActivity
        {
            get
            {
                Color defaultColor = Color.White;
                if (IsTodo) defaultColor = Color.LightGray;
                if (IsDoing) defaultColor = Color.LightBlue;
                if (IsDone) defaultColor = Color.LightGreen;
                return defaultColor;
            }
        }

        public string ColorActivityRgb
        {
            get
            {
                return base.HexConverter(ColorActivity);
            }
        }

        public Color ColorStatus
        {
            get
            {
                Color defaultColor = Color.White;
                if (IsTodo) defaultColor = Color.Gray;
                if (IsDoing) defaultColor = Color.Blue;
                if (IsDone) defaultColor = Color.Green;
                return defaultColor;
            }
        }

        public String ColorStatusRgb
        {
            get
            {
                return base.HexConverter(ColorStatus);
            }
        }

        public string State
        {
            get
            {
                if (FirstValue.fields == null) return "";
                return FirstValue.fields.SystemState;
            }
        }

        public bool IsDoing
        {
            get
            {
                return FirstValue.fields.SystemState == "Doing";
            }
        }

        public bool IsDone
        {
            get
            {
                return FirstValue.fields.SystemState == "Done";
            }
        }

        public bool IsTodo
        {
            get
            {
                return FirstValue.fields.SystemState == "To Do";
            }
        }


        public int Age
        {
            get
            {
                if (FirstValue.fields == null) return 0;

                DateTime createdDate = FirstValue.fields.SystemCreatedDate;
                return DateTime.Now.Subtract(createdDate).Days;
            }
        }

        public double RemainingWork
        {
            get
            {
                if (WorkItems == null || !WorkItems.Any()) return 0;
                return WorkItems.Where(c => !c.IsDone).Sum(c => c.RemainingWork);
            }
        }

        public double Effort
        {
            get
            {
                return FirstValue.fields.MicrosoftVSTSSchedulingEffort;
            }
        }

        public string AssignToImageUrl
        {
            get
            {
                if (FirstValue.fields == null) return "";
                return FirstValue.fields.SystemAssignedTo?.imageUrl;
            }
        }
        public string AssignToDisplayName
        {
            get
            {
                if (FirstValue.fields == null) return "";
                return FirstValue.fields.SystemAssignedTo?.displayName;
            }
        }

        public string LinkHref
        {
            get
            {
                return new AzureConfig().OrganizationUrl + "/_workitems/edit/" + FirstValue.id;
            }
        }

        public BIssue(JsonWorkItemIssue jsonWorkItemList)
        {
            this.JsonWorkItemList = jsonWorkItemList;
            WorkItems = new List<BWorkItem>();

        }

        internal void AddWorkItem(JsonWorkItem objectWorkItem)
        {
            var newWorkItem = new BWorkItem(objectWorkItem);
            WorkItems.Add(newWorkItem);
        }
    }
}