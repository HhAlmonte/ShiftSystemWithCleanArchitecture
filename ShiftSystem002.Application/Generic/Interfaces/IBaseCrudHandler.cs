using ShiftSystem002.Application.Generic.Dtos;
using ShiftSystem002.Domain.Base;

namespace ShiftSystem002.Application.Generic.Interfaces
{
    public interface IBaseCrudHandler<TDto, TEntity> where TDto : BaseDto where TEntity : BaseEntity
    {
        Task<IQueryable<TEntity>> Query();
        Task<List<TDto>> Get(int top = 50);
        Task<TDto> GetById(int id);
        Task<TDto> Create(TDto dto);
        Task<TDto> Update(TDto dto);
        Task<TDto> Update(int id, TDto dto);
        Task<bool> Delete(int id);
    }
}
