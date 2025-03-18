namespace RelationshipEF.Model
{
    public class AuthorEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public Guid CourseId { get; set; }
        public CourseEntity? Course {  get; set; }
    }
}
