namespace Konyvtar.WEBAPI
{
    public interface IBookRepository
    {

        void Upsert (Book book);

        void Delete(int id);
        IEnumerable <Book> GetAll();

        Book Get(int id);
    }
}
