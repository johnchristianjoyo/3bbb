using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AttendanceSystem2.Pages
{
    public class AttendanceRecord
    {
        public string StudentId { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Section { get; set; } = "";
        public DateTime Date { get; set; }
        public string Status { get; set; } = ""; // "Present" or "Absent"
    }

    public class AttendancesModel : PageModel
    {
        [BindProperty]
        public List<StudentModel> Students { get; set; } = new List<StudentModel>();

        [BindProperty]
        public List<AttendanceRecord> AttendanceRecords { get; set; } = new List<AttendanceRecord>();

        // Static storage for attendance records (later we'll use MongoDB)
        public static List<AttendanceRecord> AllAttendanceRecords = new List<AttendanceRecord>();

        public void OnGet()
        {
            // Get students from the Index page
            Students = IndexModel.GetAllStudents();

            // Initialize attendance records for each student
            AttendanceRecords = Students.Select(s => new AttendanceRecord
            {
                StudentId = s.StudentId,
                FullName = s.FullName,
                Date = DateTime.Now.Date,
                Status = "" // Empty by default
            }).ToList();
        }

        public IActionResult OnPost()
        {
            // Get the current students again
            Students = IndexModel.GetAllStudents();

            var attendanceCount = 0;
            var presentCount = 0;
            var absentCount = 0;

            // Process attendance records
            for (int i = 0; i < AttendanceRecords.Count && i < Students.Count; i++)
            {
                if (!string.IsNullOrEmpty(AttendanceRecords[i].Status))
                {
                    // Set additional properties
                    AttendanceRecords[i].StudentId = Students[i].StudentId;
                    AttendanceRecords[i].FullName = Students[i].FullName;
                    AttendanceRecords[i].Section = Students[i].Section;
                    AttendanceRecords[i].Date = DateTime.Now.Date;

                    // Add to our storage
                    AllAttendanceRecords.Add(AttendanceRecords[i]);

                    attendanceCount++;
                    if (AttendanceRecords[i].Status == "Present")
                        presentCount++;
                    else if (AttendanceRecords[i].Status == "Absent")
                        absentCount++;
                }
            }

            TempData["AttendanceMessage"] = $"Attendance saved! {attendanceCount} records processed. Present: {presentCount}, Absent: {absentCount}";

            // Redirect to avoid resubmission
            return RedirectToPage();
        }
    }
}
