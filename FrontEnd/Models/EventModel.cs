using System;
using System.Collections.Generic;
using BusinessLayer;

namespace FrontEnd.Models
{
    public class EventModel
    {
        private const string DATE_FORMAT = "yyyy-MM-ddTHH:mm:ss";
        public int id { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }

        public EventModel(Event e)
        {
            id = e.Id;
            title = e.Text;
            start = e.EventStart.ToString(DATE_FORMAT);
            end = e.EventEnd.ToString(DATE_FORMAT);
        }

        public static List<EventModel> FromEventList(IEnumerable<Event> events)
        {
            List<EventModel> models = new List<EventModel>();
            foreach (var e in events)
                models.Add(new EventModel(e));
            return models;
        }
    }
}