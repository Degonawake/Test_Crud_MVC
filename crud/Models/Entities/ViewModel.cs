namespace crud.Models.Entities
{
    public class ViewModel
    {
        public Students students { get; set; }
        public TeacherSchedule teacherSchedules { get; set; }
        public IEnumerable<Classrooms> classrooms { get; set; }
        public IEnumerable<Grades>  grades { get; set; }

        public IEnumerable<Teachers> teachers { get; set; }

        public IEnumerable<Subjects> subjects { get; set; }

        


    }
}
