// Copyright © Gestion-Personal - Cristian Monzon cristian_monzon@hotmail.com

using System;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace GP.AzureDevOps.Data.Json.WorkItemIssue
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/azure/devops/boards/work-items/guidance/basic-field-reference?toc=%2Fazure%2Fdevops%2Fboards%2Ftoc.json&view=azure-devops
    /// </summary>
    public class Attributes
    {
        public bool isLocked { get; set; }
        public string name { get; set; }
    }

    public class Avatar
    {
        public string href { get; set; }
    }

    public class Fields
    {
        [JsonProperty("System.AreaPath")]
        public string SystemAreaPath { get; set; }

        [JsonProperty("System.TeamProject")]
        public string SystemTeamProject { get; set; }

        [JsonProperty("System.IterationPath")]
        public string SystemIterationPath { get; set; }

        [JsonProperty("System.WorkItemType")]
        public string SystemWorkItemType { get; set; }

        [JsonProperty("System.State")]
        public string SystemState { get; set; }

        [JsonProperty("System.Reason")]
        public string SystemReason { get; set; }

        [JsonProperty("System.AssignedTo")]
        public SystemAssignedTo SystemAssignedTo { get; set; }

        [JsonProperty("System.CreatedDate")]
        public DateTime SystemCreatedDate { get; set; }

        [JsonProperty("System.CreatedBy")]
        public SystemCreatedBy SystemCreatedBy { get; set; }

        [JsonProperty("System.ChangedDate")]
        public DateTime SystemChangedDate { get; set; }

        [JsonProperty("System.ChangedBy")]
        public SystemChangedBy SystemChangedBy { get; set; }

        [JsonProperty("System.CommentCount")]
        public int SystemCommentCount { get; set; }

        [JsonProperty("System.Title")]
        public string SystemTitle { get; set; }

        [JsonProperty("System.BoardColumn")]
        public string SystemBoardColumn { get; set; }

        [JsonProperty("System.BoardColumnDone")]
        public bool SystemBoardColumnDone { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.StateChangeDate")]
        public DateTime MicrosoftVSTSCommonStateChangeDate { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.Priority")]
        public int MicrosoftVSTSCommonPriority { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.StackRank")]
        public double MicrosoftVSTSCommonStackRank { get; set; }

        [JsonProperty("Microsoft.VSTS.Scheduling.Effort")]
        public double MicrosoftVSTSSchedulingEffort { get; set; }

        [JsonProperty("WEF_FE7FFFDFABF84308955B3E70C3FD15A3_Kanban.Column")]
        public string WEF_FE7FFFDFABF84308955B3E70C3FD15A3_KanbanColumn { get; set; }

        [JsonProperty("WEF_FE7FFFDFABF84308955B3E70C3FD15A3_Kanban.Column.Done")]
        public bool WEF_FE7FFFDFABF84308955B3E70C3FD15A3_KanbanColumnDone { get; set; }
    }

    public class Links
    {
        public Avatar avatar { get; set; }
    }

    public class Relation
    {
        public string rel { get; set; }
        public string url { get; set; }
        public Attributes attributes { get; set; }
    }

    public class JsonWorkItemIssue
    {
        public int count { get; set; }
        public List<Value> value { get; set; }
    }

    public class SystemAssignedTo
    {
        public string displayName { get; set; }
        public string url { get; set; }
        public Links _links { get; set; }
        public string id { get; set; }
        public string uniqueName { get; set; }
        public string imageUrl { get; set; }
        public string descriptor { get; set; }
    }

    public class SystemChangedBy
    {
        public string displayName { get; set; }
        public string url { get; set; }
        public Links _links { get; set; }
        public string id { get; set; }
        public string uniqueName { get; set; }
        public string imageUrl { get; set; }
        public string descriptor { get; set; }
    }

    public class SystemCreatedBy
    {
        public string displayName { get; set; }
        public string url { get; set; }
        public Links _links { get; set; }
        public string id { get; set; }
        public string uniqueName { get; set; }
        public string imageUrl { get; set; }
        public string descriptor { get; set; }
    }

    public class Value
    {
        public int id { get; set; }
        public int rev { get; set; }
        public Fields fields { get; set; }
        public List<Relation> relations { get; set; }
        public string url { get; set; }
    }
}