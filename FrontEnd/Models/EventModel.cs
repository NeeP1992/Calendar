using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer;

namespace FrontEnd.Models
{
    public class EventModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }

        public EventModel()
        {
        }

        public EventModel(Event e)
        {
            id = e.Id;
            title = e.Text;
            start = e.EventStart;
            end = e.EventEnd;
        }

        public static List<EventModelJSON> FromEventList(IEnumerable<Event> events)
        {
            List<EventModelJSON> models = new List<EventModelJSON>();
            foreach (var e in events)
                models.Add((new EventModel(e)).ToJSONWithCleanDateTimes());
            return models;
        }

        public Tuple<bool, List<string>> Validate()
        {
            List<string> errors = new List<string>();

            if (start < DateTime.Now)
                errors.Add("Event cannot start in the past");

            if (start > end)
                errors.Add("Event must end after it starts");

            if (string.IsNullOrWhiteSpace(title))
                errors.Add("Event must have a title");

            return new Tuple<bool, List<string>>(!errors.Any(), errors);
        }

        public EventModelJSON ToJSONWithCleanDateTimes()
        {
            return new EventModelJSON(this);
        }
    }

    public class EventModelJSON
    {
        private const string DATE_FORMAT = "yyyy-MM-ddTHH:mm:ss";

        public EventModelJSON(EventModel eventModel)
        {
            id = eventModel.id;
            start = eventModel.start.ToString(DATE_FORMAT);
            end = eventModel.end.ToString(DATE_FORMAT);
            title = eventModel.title;
        }

        public int id { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string title { get; set; }
    }
}