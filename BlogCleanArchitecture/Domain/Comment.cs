namespace BlogCleanArchitecture.Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public string  Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int PostId { get; set; }
        public Post post { get; set; }

    }
}