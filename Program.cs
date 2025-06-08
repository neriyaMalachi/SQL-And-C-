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


    }
}
