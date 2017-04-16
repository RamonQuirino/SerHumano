namespace SerHumano.Repository
{
    public abstract class AbstractRepository
    {
        protected SerHumanoContext Context { get;}

        protected AbstractRepository(SerHumanoContext context)
        {
            Context = context;
        }
    }
}
