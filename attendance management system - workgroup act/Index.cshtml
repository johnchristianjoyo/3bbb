using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AttendanceSystem2.Pages
{
    public class StudentModel
    {
        [Required(ErrorMessage = "Full name is required")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = "";

        [Required(ErrorMessage = "Section is required")]
        public string Section { get; set; } = "";

        [Required(ErrorMessage = "Student ID is required")]
        [Display(Name = "Student ID")]
        public string StudentId { get; set; } = "";
    }

    public class IndexModel : PageModel
    {
        [BindProperty]
        public StudentModel Student { get; set; } = new StudentModel();

        // This will hold our students temporarily (later we'll use MongoDB)
        public static List<StudentModel> Students = new List<StudentModel>();

        public void OnGet()
        {
            // This runs when page loads
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // For now, we'll store in memory (later MongoDB)
            Students.Add(new StudentModel
            {
                FullName = Student.FullName,
                Section = Student.Section,
                StudentId = Student.StudentId
            });

            TempData["Message"] = $"Student {Student.FullName} added successfully!";

            // Clear the form
            Student = new StudentModel();

            return Page();
        }

        // Method to get all students (we'll use this later for the attendance page)
        public static List<StudentModel> GetAllStudents()
        {
            return Students;
        }
    }
}
