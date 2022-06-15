using GardenersCalendar2.Data;
using GardenersCalendar2.Data.EFClasses;

namespace GardenersCalendar2.Services
{
    public class ToDoService
    {
        private readonly ApplicationDbContext _context;

        public ToDoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void GeneratesToDosFromTemplates(Plant plant, DateTime firstSpringPlantingDate)
        {
            foreach (ToDoTemplate currentTemplate in _context.ToDoTemplates)
            {
                for (int DayNumber = currentTemplate.StartDayNumber; DayNumber < currentTemplate.EndDayNumber; DayNumber += currentTemplate.RecurrenceInterval.Value)
                {
                    ToDo toDo = new ToDo
                    {
                        Name = currentTemplate.Name,
                        Description = currentTemplate.Description,
                        DueDate = firstSpringPlantingDate.AddDays(DayNumber),
                        GardenerUserId = plant.GardenerUserId,
                        IsCompleted = false,
                        PlantId = plant.PlantId
                    };
                    _context.ToDos.Add(toDo);
                }
            }

            _context.SaveChanges();

        }
    }
}
