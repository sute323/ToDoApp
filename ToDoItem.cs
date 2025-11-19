
namespace TodoList
{
    //todoリストの項目
    public class ToDoItem
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }

        public ToDoItem(string Title)
        {
            this.Title = Title;
            this.IsDone = false;
        }
    }
}