using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Data;

namespace BusinessLayer
{
    public class Event
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }

        public Event(string text, DateTime eventStart, DateTime eventEnd)
        {
            Text = text;
            EventStart = eventStart;
            EventEnd = eventEnd;
        }

        private Event(DataRow r)
        {
            if (r != null)
            {
                Id = Convert.ToInt32(r["Id"]);
                Text = r["Text"].ToString();
                EventStart = Convert.ToDateTime(r["EventStart"]);
                EventEnd = Convert.ToDateTime(r["EventEnd"]);
            }
        }

        public void Save()
        {
            Id = StoredProcedures.EventUpsert(this);
        }

        public static Event Fetch(int id)
        {
            DataTable dt = StoredProcedures.EventFetch(id);
            return dt?.Rows.Count > 0 ? new Event(dt.Rows[0]) : null;
        }

        public static List<Event> FetchEvents(DateTime start, DateTime end)
        {
            List<Event> events = new List<Event>();

            foreach (DataRow r in StoredProcedures.EventList(start, end).Rows)
                events.Add(new Event(r));

            return events;
        }

        public static void Delete(int id)
        {
            StoredProcedures.EventDelete(id);
        }
    }
}