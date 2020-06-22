using System.Threading.Tasks;

namespace Netcore.Domain
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
    }
}
