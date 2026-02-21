using Biblioteca.Entities;

namespace Biblioteca.Interfaces;

public interface IBookInterface
{
    void Create(Book book);

    Book? GetById(string id);

    List<Book> GetBook(string query, string param);

    void Inactivate(string id);

}


