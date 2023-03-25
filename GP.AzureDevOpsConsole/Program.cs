using System;
using GP.AzureDevOps.Business;

namespace GP.AzureDevOpsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Message("Start batch");

            try
            {
                var projectBusiness = new ProjectBusiness();
                var projects = projectBusiness.GetProjects();
                var result = projects.Result;

                foreach (var project in result)
                {
                    Message($"> {project.Name}");

                    project.SetIterations();

                    foreach (var iterations in project.Iterations)
                    {
                        Message($"  > {iterations.FullName} ");

                        iterations.SetIssueChield(project.Name);

                        foreach (var issue in iterations.Issues)
                        {
                            Message($"   > {issue.Title} ");

                            foreach (var workitem in issue.WorkItems)
                            {
                                Message($"  > {workitem.Title} ");
                            }
                        }
                        Message(string.Empty);
                    }
                    Message(string.Empty);
                }
            }
            catch (Exception ex)
            {
                Message(ex.Message);
            }
            finally
            {
                Message("End Batch");
                Console.Read();
            }
        }

        static void Message(string message)
        {
            Console.WriteLine(message);
        }
    }
}
