namespace LibraryApp;

public delegate void BooksOperation(int clientId, string bookId, string inOut);

public delegate void ShowBooks();
public class Librarian
{
    public readonly int libraryId = 1125; 
    public Dictionary<string, Dictionary<int, Dictionary<string ,Book>>> bookStructure = new ();
    public Dictionary<int, LibraryClient> listOfClients = new Dictionary<int, LibraryClient>();

    public Librarian()
    {
        var dictionaryIn = new Dictionary<int, Dictionary<string ,Book>>();
        var dictionaryBooksIn = new Dictionary<string, Book>();
        dictionaryBooksIn.Add("12312312", new Book
        {
            Isbn = "12312312",
            Author = "Tolstoy L.N.",
            Title = "War and peace",
            LibraryId = this.libraryId
        });
        dictionaryBooksIn.Add("123231322", new Book
        {
            Isbn = "123231322",
            Author = "Pushkin A.S.",
            Title = "Daughter of captain",
            LibraryId = this.libraryId
        });
        dictionaryBooksIn.Add("123123125454", new Book
        {
            Isbn = "123123125454",
            Author = "Gogol N.V.",
            Title = "Dead souls",
            LibraryId = this.libraryId
        });
        dictionaryBooksIn.Add("1231231223423", new Book
        {
            Isbn = "1231231223423",
            Author = "Dostoevskiy F.M.",
            Title = "Fuckin stupid",
            LibraryId = this.libraryId
        });
        dictionaryIn.Add(this.libraryId, dictionaryBooksIn);
        var dictionaryOut = new Dictionary<int, Dictionary<string ,Book>>();
        bookStructure.Add("in", dictionaryIn);
        bookStructure.Add("out", dictionaryOut);
    }

    public void showBooksBalance()
    {
        foreach (KeyValuePair<string, Dictionary<int, Dictionary<string ,Book>>> itemInOut in this.bookStructure)
        {
            if (itemInOut.Key == "in")
            {
                Console.WriteLine("Книги в библиотеке:");
            }
            else
            {
                Console.WriteLine("Книги на руках:");
            }

            foreach (KeyValuePair<int, Dictionary<string ,Book>> itemClients in itemInOut.Value)
            {
                if (itemClients.Key != libraryId)
                {
                    Console.WriteLine("Информация о клиенте:");
                    Console.WriteLine(listOfClients[itemClients.Key]);
                }

                foreach (var book in itemClients.Value)
                {
                    Console.WriteLine(book.Value);
                }
                Console.WriteLine("-------------");
            }
        }
    }

    public void addClient(int id, string name, string lastname)
    {
        this.listOfClients.Add(id, new LibraryClient()
        {
            Id = id,
            Name = name,
            LastName = lastname
        });
        Console.WriteLine($"Добавлен новый клиент {this.listOfClients[id]}");
    }

    public void operationWithBooks(int clientId, string bookId, string inOut)
    {
        if (inOut == "in")
        {
            Book book = new Book();
            foreach (var item in bookStructure["out"])
            {
                if (item.Key == clientId)
                {
                    book = item.Value[bookId];
                    break;
                }
            }
            bookStructure["in"].GetValueOrDefault(libraryId)?.Add(bookId, book);
            bookStructure["out"].GetValueOrDefault(clientId)?.Remove(bookId);
        }
        if (inOut == "out")
        {
            Book book = bookStructure["in"].GetValueOrDefault(libraryId).GetValueOrDefault(bookId);
            if (!bookStructure["out"].ContainsKey(clientId))
            {
                bookStructure["out"].Add(clientId, new Dictionary<string, Book>());
            }
            bookStructure["out"].GetValueOrDefault(clientId)?.Add(bookId, book);
            bookStructure["in"].GetValueOrDefault(libraryId)?.Remove(bookId);
        }
    }
}