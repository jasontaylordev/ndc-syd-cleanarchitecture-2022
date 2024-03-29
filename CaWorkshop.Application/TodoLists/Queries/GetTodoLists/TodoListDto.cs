﻿using CaWorkshop.Application.Common.Mappings;
using CaWorkshop.Domain.Entities;

namespace CaWorkshop.Application.TodoLists.Queries.GetTodoLists;

public class TodoListDto : IMapFrom<TodoList>
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Colour { get; set; } = string.Empty;

    public IList<TodoItemDto> Items { get; set; }
        = new List<TodoItemDto>();
}
