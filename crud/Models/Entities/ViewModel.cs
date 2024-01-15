namespace crud.Models.Entities
{
    public class ViewModel
    {
        public IEnumerable<Students> students { get; set; }
        public IEnumerable<Classrooms> classrooms { get; set; }
        public IEnumerable<Grades>  grades { get; set; }

       
    }
}
