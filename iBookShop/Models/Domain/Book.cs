namespace iBookShop.Models.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Isbn { get; set; }

        public int TotalPages { get; set; }

        public int AuthorId { get; set; }

        public string PublisherId { get; set; }

        public string GenreId { get; set; }


    }
}
