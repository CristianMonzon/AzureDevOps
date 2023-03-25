// Copyright © Gestion-Personal - Cristian Monzon cristian_monzon@hotmail.com

using System.Collections.Generic;
using GP.AzureDevOps.Business;
using GP.AzureDevOps.Data.Json.Project;

namespace GP.AzureDevOps.Data
{
    public class BProject
    {

        public IList<BIteration> Iterations;

        public string Id
        {
            get
            {
                return JsonProjectValue.id;
            }
        }

        public string Name
        {
            get
            {
                return JsonProjectValue.name;
            }
        }

        private Value jsonProjectValue;
        private Value JsonProjectValue
        {
            get
            {
                if (jsonProjectValue == null) new Value();
                return jsonProjectValue;
            }
        }

        public BProject(Value value)
        {
            jsonProjectValue = value;
            Iterations = new List<BIteration>();
        }

        public void SetIterations()
        {
            var iterationBusiness = new IterationBusiness();
            var iterations = iterationBusiness.GetIterations(Name);
            Iterations = iterations.Result;            
        }
    }
}