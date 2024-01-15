namespace crud.Models.Entities
{
    public class TeachersSchedule
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int GradeId { get; set; }
        public int SubjectId { get; set; }
        public int ClassroomId { get; set; }
        public DateTime Schedule { get; set; }
    }
   
}
