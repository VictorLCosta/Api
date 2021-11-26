using System;
using System.Threading.Tasks;
using Api.Data.Interfaces;

namespace Api.Data.Transactions
{
    public interface IUow : IDisposable
    {
        IUserRepository Users { get; }

        Task Commit();
    }
}