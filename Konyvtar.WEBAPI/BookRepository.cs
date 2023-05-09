namespace Konyvtar.WEBAPI
{
    public class BookRepository : IBookRepository
    {

        private readonly Dictionary<int, Book> _people = new();
        public void Delete(int id)
        {
            _people.Remove(id);
        }

        public Book Get(int id)
        {
           return _people.TryGetValue(id, out var book) ? book : null;
        }

        public IEnumerable<Book> GetAll()
        {
            return _people.Values;
        }

        public void Upsert(Book book)
        {
            _people[book.Id] = book;
        }
    }
}
