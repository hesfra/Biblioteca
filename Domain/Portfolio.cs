namespace Biblioteca.Entities;

public class Portfolio
{
    public string Id { get; private set; }

    public Book Book { get; private set; }

    public PortfolioCondition Condition { get; private set; }

    public PortfolioCover Cover { get; private set; }

    public Portfolio(
        string id,
        Book book,
        PortfolioCondition condition,
        PortfolioCover cover
    )
    {
        Id = id;
        Book = book;
        Condition = condition;
        Cover = cover;
    }

    public enum PortfolioCondition
    {
        Perfect = 1,
        Good = 2,
        Bad = 3,
        Useless = 4,
        Disabled = 5
    }

    public enum PortfolioCover
    {
        Paper = 1,
        Hardcover = 2
    }
}
