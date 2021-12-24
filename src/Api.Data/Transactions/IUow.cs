using System;
using System.Threading.Tasks;
using Api.Data.Interfaces;

namespace Api.Data.Transactions
{
    public interface IUow : IDisposable
    {
        IUserRepository Users { get; }

        ICepRepository Ceps { get; }
        ICityRepository Cities { get; }
        IStateRepository States { get; }

        Task Commit();
    }
}