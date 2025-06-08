using DAL;
using Models;
using System;

class Program
{
    static void Main()
    {
        var dal = new AgentDAL();

        // Add sample agent
        dal.AddAgent(new Agent
        {
            CodeName = "Shadow",
            RealName = "Liam Smith",
            Location = "Berlin",
            Status = "Active",
            MissionsCompleted = 2
        });

        // Show all agents
        //Console.WriteLine("All agents:");
        //foreach (Agent agent in dal.GetAllAgents())
        //{
        //    Console.WriteLine($"{agent.Id}: {agent.CodeName} ({agent.Status}) in {agent.Location} – Missions: {agent.MissionsCompleted}");
        //}

        //// Update location
        //dal.UpdateAgentLocation(1, "London");

        //// Add missions
        //dal.AddMissionCount(1, 2);

        //// Search
        //Console.WriteLine("\nSearch for 'Sh':");
        //foreach (var agent in dal.SearchAgentsByCode("Sh"))
        //{
        //    Console.WriteLine($"{agent.CodeName} - {agent.Location}");
        //}

        //// Count by status
        //Console.WriteLine("\nAgent counts by status:");
        //foreach (var pair in dal.CountAgentsByStatus())
        //{
        //    Console.WriteLine($"{pair.Key}: {pair.Value}");
        //}

        // Delete agent
        // dal.DeleteAgent(1); // Uncomment to test
    }
}
