using Biblioteca.Entities;

namespace Biblioteca.Interfaces;

public interface IPortfolioRepository
{
    void Create(Portfolio Portfolio);

    Portfolio? GetById(string id);
    List<Portfolio> GetByBookId(string bookId);
    void UpdateCondition(string condition);
    void Delete(string id);

}
