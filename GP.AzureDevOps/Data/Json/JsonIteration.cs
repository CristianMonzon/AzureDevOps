// Copyright © Gestion-Personal - Cristian Monzon cristian_monzon@hotmail.com

using System;
using System.Collections.Generic;

namespace GP.AzureDevOps.Data.Json.Iteration
{
    public class Attributes
    {
        public DateTime startDate { get; set; }
        public DateTime finishDate { get; set; }
        public string timeFrame { get; set; }
    }

    public class JsonIteration
    {
        public int count { get; set; }
        public List<Value> value { get; set; }
    }

    public class Value
    {
        public string id { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public Attributes attributes { get; set; }
        public string url { get; set; }
    }


}
