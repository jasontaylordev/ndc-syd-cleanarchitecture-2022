using CaWorkshop.Application.Common.Interfaces;
using CaWorkshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaWorkshop.Application.TodoLists.Queries.GetTodoLists;

public class GetTodoLists : IRequest<List<TodoList>>
{
    //public string TitleFilter { get; set; }
}

public class GetTodoListsQueryHandler : IRequestHandler<GetTodoLists, List<TodoList>>
{
    private readonly IApplicationDbContext _context;

    public GetTodoListsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TodoList>> Handle(GetTodoLists request, CancellationToken cancellationToken)
    {
        return await _context.TodoLists
            //.Where(tl => tl.Title.Contains(request.TitleFilter))
            .Select(l => new TodoList
            {
                Id = l.Id,
                Title = l.Title,
                Items = l.Items.Select(i => new TodoItem
                {
                    Id = i.Id,
                    ListId = i.ListId,
                    Title = i.Title,
                    Done = i.Done,
                    Priority = i.Priority,
                    Note = i.Note
                }).ToList()
            }).ToListAsync(cancellationToken);
    }
}
