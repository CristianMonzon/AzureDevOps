// Copyright © Gestion-Personal - Cristian Monzon cristian_monzon@hotmail.com

using GP.AzureDevOps.Data.Json.WorkItem;
using System;
using System.Drawing;

namespace GP.AzureDevOps.Data
{
    public class BWorkItem : BaseWorkItem
    {

        private JsonWorkItem JsonWorkItem { get; }

        public int Id
        {
            get
            {
                if (JsonWorkItem.fields == null) return 0;
                return JsonWorkItem.id;
            }
        }

        public string Title
        {
            get
            {
                return JsonWorkItem.fields.SystemTitle;
            }
        }

        public string ShortTitle
        {
            get
            {
                string returnValue = Title;
                try
                {
                    string textToRemove = "I want to ";

                    int position = returnValue.IndexOf(textToRemove);
                    if (position > 0) returnValue = FirstLetterCapital(Title.Remove(0, position + textToRemove.Length).Trim());


                    string startTag = "[";
                    string endTag = "]";
                    if (returnValue.Contains(startTag))
                    {
                        int startIndex = returnValue.IndexOf(startTag) + startTag.Length;
                        int endIndex = returnValue.IndexOf(endTag) - startIndex + 2;
                        returnValue = FirstLetterCapital(returnValue.Remove(startIndex - 1, endIndex).Trim());
                    }

                    if (returnValue.Length > TitleMaxLength) returnValue = FirstLetterCapital(returnValue.Substring(0, TitleMaxLength - 2)) + "...";
                }
                catch (Exception e)
                {
                    returnValue = Title;
                }

                return returnValue;
            }
        }


        public string Activity
        {
            get
            {
                return JsonWorkItem.fields.MicrosoftVSTSCommonActivity;
            }
        }

        public string ColorActivity
        {
            get
            {
                Color defaultColor = Color.White;
                switch (Activity)
                {
                    case "Deployment":
                        defaultColor = Color.DeepSkyBlue;
                        break;
                    case "Design":
                        defaultColor = Color.LightGray;
                        break;
                    case "Development":
                        defaultColor = Color.LightBlue;
                        break;
                    case "Documentation":
                        defaultColor = Color.Yellow;
                        break;
                    case "Requirements":
                        defaultColor = Color.LightGreen;
                        break;
                    case "Testing":
                        defaultColor = Color.LightPink;
                        break;
                }
                return HexConverter(defaultColor);
            }
        }

        public bool IsDoing
        {
            get
            {
                return JsonWorkItem.fields.SystemState == "Doing";
            }
        }

        public bool IsDone
        {
            get
            {
                return JsonWorkItem.fields.SystemState == "Done";
            }
        }

        public bool IsTodo
        {
            get
            {
                return JsonWorkItem.fields.SystemState == "To Do";
            }
        }

        public bool IsTask
        {
            get
            {
                return JsonWorkItem.fields.SystemWorkItemType == "Task";
            }
        }

        public bool IsIssue
        {
            get
            {
                return JsonWorkItem.fields.SystemWorkItemType == "Issue";
            }
        }

        public bool IsEpic
        {
            get
            {
                return JsonWorkItem.fields.SystemWorkItemType == "Epic";
            }
        }

        public int Age
        {
            get
            {
                DateTime createdDate = JsonWorkItem.fields.SystemCreatedDate;
                return DateTime.Now.Subtract(createdDate).Days;
            }

        }

        public Double RemainingWork
        {
            get
            {
                return JsonWorkItem.fields.MicrosoftVSTSSchedulingRemainingWork;
            }
        }

        public string AssignToImageUrl
        {
            get
            {
                return JsonWorkItem.fields.SystemAssignedTo?.imageUrl;
            }
        }

        public string AssignToDisplayName
        {
            get
            {
                return JsonWorkItem.fields.SystemAssignedTo?.displayName;
            }
        }

        public string LinkHref
        {
            get
            {
                return JsonWorkItem._links.html.href;
            }
        }

        public BWorkItem(JsonWorkItem jsonWorkItem)
        {
            this.JsonWorkItem = jsonWorkItem;
        }

    }
}
