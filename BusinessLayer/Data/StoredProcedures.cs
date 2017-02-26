using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer.Data
{
    public static class StoredProcedures
    {
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["Calendar"].ConnectionString);
        }

        public static int EventUpsert(Event e)
        {
            SqlCommand cmd = new SqlCommand("sp_Event_Upsert", GetConnection());
            object val;

            cmd.Parameters.AddWithValue("Id", e.Id);
            cmd.Parameters.AddWithValue("Text", e.Text);
            cmd.Parameters.AddWithValue("EventStart", e.EventStart);
            cmd.Parameters.AddWithValue("EventEnd", e.EventEnd);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection.Open();
            val = cmd.ExecuteScalar();
            cmd.Connection.Close();
            cmd.Connection.Dispose();
            cmd.Dispose();

            return Convert.ToInt32(val);
        }

        public static DataTable EventFetch(int id)
        {
            SqlCommand cmd = new SqlCommand("Select * From Event where id = @id", GetConnection());
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            cmd.Parameters.AddWithValue("Id", id);
            cmd.Connection.Open();
            adpt.Fill(dt);
            cmd.Connection.Close();
            cmd.Connection.Dispose();
            adpt.Dispose();

            return dt;
        }

        public static DataTable EventList(bool outstandingOnly)
        {
            string sqlQuery = outstandingOnly ? "SELECT * FROM [Event] WHERE EventStart >= GETDATE() ORDER BY EventStart" : "SELECT * FROM [Event] ORDER BY EventStart";
            SqlCommand cmd = new SqlCommand(sqlQuery, GetConnection());
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            cmd.Connection.Open();
            adpt.Fill(dt);
            cmd.Connection.Close();
            cmd.Connection.Dispose();
            adpt.Dispose();

            return dt;
        }
    }
}