using CaWorkshop.Application.Common.Models;

namespace CaWorkshop.Application.TodoLists.Queries.GetTodoLists;

public class TodosVm
{
    public List<LookupDto> PriorityLevels { get; set; } = new();

    public List<TodoListDto> Lists { get; set; } = new();
}