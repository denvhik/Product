namespace Frontend.Models.ViewModel
{
    public class ModelView
    {
        public IEnumerable<Group> Groups { get; set; }
        public string ProductName { get; set; }
        public string GroupName { get; set; }
        public IEnumerable<Category> Сategories { get; set; }
    }
}
