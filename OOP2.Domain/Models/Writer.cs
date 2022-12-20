namespace OOP2.Domain.Models
{
    public class Writer
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? SecondName { get; set; } = string.Empty;
        public string? Patronymic { get; set; } = string.Empty;


        public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<Book> Books { get; set; } = new List<Book>();

        public int BookCount { get { return Books.Count; } }






        /* public void AddGenre(Genre genre)
        {
           Genres.Add(genre);
        }
        public void AddBook(Book book)
        {
            Books.Add(book);
        }*/
    }
}