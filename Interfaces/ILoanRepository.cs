using Biblioteca.Entities;

namespace Biblioteca.Interfaces;

public interface ILoanRepository
{
    void Create(Loan loan);
    Loan? GetById(string id);
    Loan? GetByUserId(string userId);
    Loan? GetByPortfolioId(string portfolioId);
    Loan? GetByBookId(string bookId);
    void UpdateStatus(string id, string status);
}
