namespace CoreProject.Models
{
    public class Student
    {
        public long StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentAddress { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastServerAction { get; set; }
        public DateTime ActionTime { get; set; }
    }
}
