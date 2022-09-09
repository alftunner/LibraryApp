namespace LibraryApp;

public class Book
{
    public string Isbn { get; set; }
    public string Author { get; set; }
    public string Title { get; set; }
    public int LibraryId { get; set; }
    
    public override string ToString()
    {
        return $"ID книги: {Isbn}\nАвтор: {Author}\nНазвание: {Title}";
    }
}