using CaWorkshop.Application.Common.Interfaces;
using CaWorkshop.Application.Common.Models;
using CaWorkshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaWorkshop.Application.TodoLists.Queries.GetTodoLists;

public class GetTodoLists : IRequest<TodosVm>
{
    //public string TitleFilter { get; set; }
}

public class GetTodoListsQueryHandler : IRequestHandler<GetTodoLists, TodosVm>
{
    private readonly IApplicationDbContext _context;

    public GetTodoListsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TodosVm> Handle(GetTodoLists request, CancellationToken cancellationToken)
    {
        return new TodosVm
        {
            PriorityLevels = Enum.GetValues(typeof(PriorityLevel))
                .Cast<PriorityLevel>()
                .Select(p => new LookupDto
                {
                    Value = (int)p,
                    Name = p.ToString()
                })
                .ToList(),

            Lists = await _context.TodoLists
                .Select(TodoListDto.Projection)
                .ToListAsync(cancellationToken)
        };
    }
}
