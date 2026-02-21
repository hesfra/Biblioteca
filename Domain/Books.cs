namespace Biblioteca.Entities;

public class Book
{
    public string Isbn { get; private set; }
    public string Title { get; private set; }
    public int ReleaseYear { get; private set; }
    public string Summary { get; private set; }
    public string Author { get; private set; }
    public int PageLen { get; private set; }
    public string Publisher { get; private set; }

    public Book(
        string isbn,
        string title,
        int releaseYear,
        string summary,
        string author,
        int pageLen,
        string publisher
    )
    {
        Isbn = isbn;
        Title = title;
        ReleaseYear = releaseYear;
        Summary = summary;
        Author = author;
        PageLen = pageLen;
        Publisher = publisher;
    }
    public enum Genre
    {
        adventure = 1,
        romance = 2,
        fantasy = 3,
        sci_fi = 4,
        history = 5,
        horror = 6,
        distopian = 7,
        biograph = 8,
        self_help = 9,
        memory = 10,
        true_crime = 11,
        poetry = 12,
        graphic_novel = 13
    }
}
