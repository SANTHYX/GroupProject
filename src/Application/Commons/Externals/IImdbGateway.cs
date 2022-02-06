using System.Threading.Tasks;

namespace Application.Commons.Externals
{
    public interface IImdbGateway
    {
        Task GetMovieData();
    }
}
