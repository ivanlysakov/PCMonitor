using DataAccess.Contexts;


namespace DataAccess.Repository
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;
        public BaseRepository(AppDbContext context) 
        {
        
            _context = context;

        }
    }
}
