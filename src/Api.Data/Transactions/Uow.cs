using System.Threading.Tasks;
using Api.Data.Interfaces;
using Api.Data.Repositories;

namespace Api.Data.Transactions
{
    public class Uow : IUow
    {
        public IUserRepository Users { get; }

        public ICepRepository Ceps { get; }

        public ICityRepository Cities { get; }

        public IStateRepository States { get; }


        private readonly ApplicationDbContext _context;

        public Uow(ApplicationDbContext context)
        {
            _context = context;

            Users = new UserRepository(_context);
            Ceps = new CepRepository(_context);
            Cities = new CityRepository(_context);
            States = new StateRepository(_context);
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async void Dispose()
        {
            await Disposing(true);
        }

        protected virtual async Task Disposing(bool active)
        {
            if(active)
            {
                await _context.DisposeAsync();
            }
        }
    }
}