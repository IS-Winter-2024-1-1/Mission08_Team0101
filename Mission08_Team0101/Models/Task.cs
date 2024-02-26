using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;

namespace Mission08_Team0101.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Task name is required")]
        public string TaskName { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Quadrant is required.")]
        public string Quadrant { get; set; }

        
        [ForeignKey("CategoryId")]
        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }
        public Category Category{ get; set; }

        [Required(ErrorMessage = "Please mark if the task has been completed or not.")]
        public bool IsCompleted { get; set; }

    }
}
