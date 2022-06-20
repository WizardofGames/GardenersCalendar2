using GardenersCalendar2.Data.EFClasses;
using System.Text.Json;

namespace GardenersCalendar2.Services
{
    public class FullCalendarService
    {
        public string ConvertListOfToDosToJson(List<ToDo> toDos)
        {
            List<CalendarEvent> calendarEvents = ToDoToACalendarEvent(toDos);
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            string jsonStringResult = JsonSerializer.Serialize(calendarEvents, options);
            return jsonStringResult;
        }
        
        public List<CalendarEvent> ToDoToACalendarEvent(List<ToDo> toDos)
        {            
            List<CalendarEvent> calendarEvents = new List<CalendarEvent>();

            foreach (ToDo toDo in toDos)
            {
                CalendarEvent calendarEvent = new CalendarEvent(toDo);
                calendarEvents.Add(calendarEvent);
            }
            return calendarEvents;
        }
        public class CalendarEvent
        {
            public CalendarEvent(ToDo toDo)
            {
                this.Id = toDo.ToDoId.ToString();
                this.Title = toDo.Name;
                this.Start = toDo.DueDate;
                this.AllDay = true;
                this.Url = $"/Plants/Details?id={toDo.PlantId}";

            }
            public string Id { get; set; }
            public string Title { get; set; }
            public DateTime Start { get; set; }
            public bool AllDay { get; set; }
            public string Url { get; set; }
        }

        internal string ConvertListOfToDosToJson(object toDos)
        {
            throw new NotImplementedException();
        }
    }
}
