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

        public void GeneratesToDosFromTemplates(Plant plant, DateTime firstSpringPlantingDate, DateTime lastFallHarvestDate, List<int> toDoTemplateIds)
        {
            foreach (ToDoTemplate currentTemplate in _context.ToDoTemplates)
            {
                if (toDoTemplateIds.Contains(currentTemplate.ToDoTemplateId))
                {
                    for (DateTime startDate = firstSpringPlantingDate.AddDays(currentTemplate.StartDayNumber); startDate <= lastFallHarvestDate; startDate = startDate.AddDays(currentTemplate.RecurrenceInterval.Value))
                    {
                        ToDo toDo = new ToDo
                        {
                            Name = currentTemplate.Name,
                            Description = currentTemplate.Description,
                            DueDate = startDate,
                            GardenerUserId = plant.GardenerUserId,
                            PlantId = plant.PlantId
                        };
                        _context.ToDos.Add(toDo);
                    }

                }

            }


            _context.SaveChanges();

        }
        public void GeneratesRecurringToDosFromUserInput(string UserId, ToDoViewModel toDoViewModel)
        {
            if(toDoViewModel.RecurrenceInterval == null || toDoViewModel.RecurrenceInterval <= 0)
            {
                CreatesAToDoFromAToDoViewModel(UserId, toDoViewModel, toDoViewModel.StartDate);
            }
            else
            {
                for (DateTime transientVariableForDate = toDoViewModel.StartDate;
                transientVariableForDate <= toDoViewModel.EndDate;
                transientVariableForDate = transientVariableForDate.AddDays(toDoViewModel.RecurrenceInterval.Value))
                {
                    CreatesAToDoFromAToDoViewModel(UserId, toDoViewModel, transientVariableForDate);
                }
            }
            



            _context.SaveChanges();

        }

        private void CreatesAToDoFromAToDoViewModel(string UserId, ToDoViewModel toDoViewModel, DateTime dueDate)
        {
            ToDo toDo = new ToDo
            {
                Name = toDoViewModel.Name,
                Description = toDoViewModel.Description,
                DueDate = dueDate,
                GardenerUserId = UserId,
                PlantId = toDoViewModel.PlantId
            };
            _context.ToDos.Add(toDo);
        }
    }
}
