namespace LibraryApp;

public class LibraryClient
{
    public event BooksOperation eventBookOperation;
    public event ShowBooks eventShowBooks;
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }

    public void getPutBook(int clientId, string bookId, string inOut)
    {
        eventBookOperation(clientId, bookId, inOut);
    }
    
    public void showMeBooks()
    {
        eventShowBooks();
    }

    public override string ToString()
    {
        return $"ID клиента: {Id}\nИмя клиента: {Name}\nФамилия клиента: {LastName}";
    }
}