using CaWorkshop.Domain.Entities;

namespace CaWorkshop.Application.Common.Services.Data;

public static class TodoListRepositoryExtensions
{
    public static async Task<List<TodoList>> GetListByTitleAsync(this IRepository<TodoList> repository, string title, CancellationToken cancellationToken = default)
    {
        return await repository.ListAsync(tl => tl.Title == title, cancellationToken);
    }
}
