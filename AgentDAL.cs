using MySql.Data.MySqlClient;
using Models;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class AgentDAL
    {
        private string connectionString = "" +
            "server=localhost;" +   
            "user=root;" +    
            "database=eagleeyedb;" +
            "port=3306;"  
            ;    

        // פונקציה להוספת סוכן חדש לטבלה במסד הנתונים
        public void AddAgent(Agent agent)
        {
            // יצירת חיבור חדש למסד הנתונים עם מחרוזת ההתחברות
            MySqlConnection conn = new MySqlConnection(connectionString);

            // פתיחת החיבור בפועל
            conn.Open();

            // הגדרת שאילתה מסוג INSERT עם פרמטרים (כדי להגן מפני SQL Injection)
            string query = @"INSERT INTO agents (codeName, realName, location, status, missionsCompleted)
                  VALUES (@codeName, @realName, @location, @status, @missionsCompleted)";

            // יצירת פקודת SQL עם השאילתה והחיבור
            MySqlCommand cmd = new MySqlCommand(query, conn);

            // הגדרת הפרמטרים בשאילתה – מקבלים את הערכים מתוך האובייקט agent
            cmd.Parameters.AddWithValue("@codeName", agent.CodeName);
            cmd.Parameters.AddWithValue("@realName", agent.RealName);
            cmd.Parameters.AddWithValue("@location", agent.Location);
            cmd.Parameters.AddWithValue("@status", agent.Status);
            cmd.Parameters.AddWithValue("@missionsCompleted", agent.MissionsCompleted);

            // ביצוע השאילתה במסד הנתונים (INSERT) לא מחזירה תוצאה אלה INT של מספר השורות שנוצרו
            cmd.ExecuteNonQuery();
        }


        public List<Agent> GetAllAgents()
        {
            List<Agent> agents = new List<Agent>();

            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT * FROM agents";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())   
            {
                Agent agent = new Agent
                {
                    Id = reader.GetInt32("id"),
                    CodeName = reader.GetString("codeName"),
                    RealName = reader.GetString("realName"),
                    Location = reader.GetString("location"),
                    Status = reader.GetString("status"),
                    MissionsCompleted = reader.GetInt32("missionsCompleted")
                };

                agents.Add(agent);
            }

            reader.Close(); // סגירת הקורא 
            conn.Close();   // סגירת החיבור 

            return agents;
        }


        public void UpdateAgentLocation(int agentId, string newLocation)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = "UPDATE agents SET location = @location WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@location", newLocation);
            cmd.Parameters.AddWithValue("@id", agentId);
            cmd.ExecuteNonQuery();
        }

        public void DeleteAgent(int agentId)
        {
           MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = "DELETE FROM agents WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", agentId);
            cmd.ExecuteNonQuery();
        }






    }
}
