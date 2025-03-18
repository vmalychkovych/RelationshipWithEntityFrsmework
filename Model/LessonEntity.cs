namespace RelationshipEF.Model
{
    public class LessonEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LessonText { get; set; }
        public Guid CourseId { get; set; }
        public CourseEntity? Course { get; set; }
    }
}
