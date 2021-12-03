using Application.Commons.CQRS.Query;
using Application.Commons.Persistance;
using Application.Users.Queries.DisplayUser.Dto;
using System.Threading.Tasks;

namespace Application.Users.Queries.DisplayUser
{
    public class DisplayUserHandler : IQueryHandler<DisplayUserDto, DisplayUser>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DisplayUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DisplayUserDto> HandleAsync(DisplayUser query)
        {
            return new()
            {
                
            };
        }
    }
}
