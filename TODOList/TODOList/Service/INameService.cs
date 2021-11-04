using System.Threading.Tasks;
using TODOList.Model;

namespace TODOList.Service
{
    public interface INameService
    {
       Task<Name> getName(); 
    }
}
