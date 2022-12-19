namespace OOP2.Domain
{
    public class Writer
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } = String.Empty;
        public string? SecondName { get; set; } = String.Empty;
        public string? Patronymic { get; set; } = String.Empty;


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