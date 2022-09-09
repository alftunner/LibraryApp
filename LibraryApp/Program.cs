using LibraryApp;

Librarian library = new Librarian();
library.showBooksBalance();

LibraryClient client = new LibraryClient
{
    Id = 1,
    Name = "Petr",
    LastName = "Petrov"
};

library.addClient(client.Id, client.Name, client.LastName);
client.eventBookOperation += library.operationWithBooks;
client.eventShowBooks += library.showBooksBalance;

client.showMeBooks();

client.getPutBook(1, "12312312", "out");

client.showMeBooks();
