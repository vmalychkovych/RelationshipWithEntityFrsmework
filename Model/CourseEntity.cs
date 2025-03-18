namespace RelationshipEF.Model
{
    public class CourseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price;
        public Guid AuthorId { get; set; }
        public AuthorEntity Author { get; set; }
        public List<LessonEntity> Lessons { get; set; } = [];
        public List<StudentEntity> Students { get; set; } = [];
    }
}
