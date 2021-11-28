using Application.Commons.CQRS.Command;
using System;
using System.Threading.Tasks;

namespace Application.Comments.Commands.AddComment
{
    public class AddCommentHandler : ICommandHandler<AddComment>
    {
        public async Task HandleAsync(AddComment command)
        {
            throw new NotImplementedException();
        }
    }
}
