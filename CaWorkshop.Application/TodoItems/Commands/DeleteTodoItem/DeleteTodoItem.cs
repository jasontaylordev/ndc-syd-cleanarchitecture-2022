using CaWorkshop.Application.Common.Interfaces;

namespace CaWorkshop.Application.TodoItems.Commands.DeleteTodoItem;

public record DeleteTodoItemCommand (int Id) : IRequest;

public class DeleteTodoItemCommandHandler
    : AsyncRequestHandler<DeleteTodoItemCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTodoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    protected override async Task Handle(DeleteTodoItemCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.TodoItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.TodoItems.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
