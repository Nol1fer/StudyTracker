using System.ComponentModel.DataAnnotations;

namespace StudyTracker.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Название обязательно")]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Имя преподавателя обязательно")]
        public string ProfessorName { get; set; }

        public Course()
        {
            Name = string.Empty;
            ProfessorName = string.Empty;
        }

        public Course(int id, string name, string? description, string professorName)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.ProfessorName = professorName;
        }
    }
}
