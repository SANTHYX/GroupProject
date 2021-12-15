using Core.Types;

namespace Application.Commons.Mappers
{
    public interface IMapper
    {
        TResult Map<TResult,QSource>(QSource source) where QSource : Entity;
    }
}
