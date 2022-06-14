using GardenersCalendar2.Data.GardenerUserNS;
using System.ComponentModel.DataAnnotations;

namespace GardenersCalendar2.Data.EFClasses
{
    public class Plant : IValidatableObject
    {
        public int PlantId { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public List<ToDo>? ToDo { get; set; }

        public int? NurseryId { get; set; }
        public Nursery? Nursery { get; set; }
        public int? GardenId { get; set; }
        public Garden? Garden { get; set; }
        

        //public string Test = Microsoft.AspNetCore.Identity.AspNetUserManager.IdentityUser.Name.Value;
        //setting to something user specific above; foreach plant in the database, find me all the plants that belong to currentuser
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            if (GardenId == null && NurseryId == null)
            {
                ValidationResult validationResultVariable = new ValidationResult("Please add your plant to a nursery or garden.");
                results.Add(validationResultVariable);
            }
            else if (GardenId != null && NurseryId != null)
            {
                ValidationResult validationResultVariable = new ValidationResult("Please remove your plant from a nursery or garden.");
                results.Add(validationResultVariable);
            }
            return results;
        }
    }
}
