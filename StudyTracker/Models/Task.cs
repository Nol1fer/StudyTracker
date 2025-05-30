using System.ComponentModel.DataAnnotations;

namespace StudyTracker.Models
{
    public class Task
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Название обязательно")]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Укажите дедлайн")]
        public DateTime Deadline { get; set; }
        [Required]
        public string Status { get; set; } // "Не начато", "В процессе", "Завершено"
        public int CourseId { get; set; } // Связь с курсом

        public Task()
        {
            Title = string.Empty;
            Status = "Не начато";
        }
    }
}
