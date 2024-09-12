namespace WebTodo.ViewModels.Todo;

public class TodosViewModel
{
    public string id { get; set; } = string.Empty;
    public string title { get; set; } = string.Empty;
    public bool isCompleted { get; set; } = false;
    public string createdOn { get; set; } = string.Empty;
}
