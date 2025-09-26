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

        public static List<StudentModel> Students = new List<StudentModel>();

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Students.Add(new StudentModel
            {
                FullName = Student.FullName,
                Section = Student.Section,
                StudentId = Student.StudentId
            });

            TempData["Message"] = $"Student {Student.FullName} added successfully!";

            Student = new StudentModel();

            return Page();
        }

        public static List<StudentModel> GetAllStudents()
        {
            return Students;
        }
    }
}
