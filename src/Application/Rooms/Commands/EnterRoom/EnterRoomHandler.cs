using Application.Commons.CQRS.Command;
using Application.Commons.Persistance;
using Core.Domain;
using System.Threading.Tasks;

namespace Application.Rooms.Commands.EnterRoom
{
    public class EnterRoomHandler : ICommandHandler<EnterRoom>
    {
        private readonly IUnitOfWork _unit;

        public EnterRoomHandler(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task HandleAsync(EnterRoom command)
        {
            var viewer = await _unit.Viewer.GetByUserId(command.UserId);
            SetActivity(viewer);
            _unit.Viewer.Update(viewer);
            await _unit.CommitAsync();
        }

        private void SetActivity(Viewer viewer)
        {
            if (viewer.isOnline) return;
            viewer.isOnline = true;
        }
    }
}
