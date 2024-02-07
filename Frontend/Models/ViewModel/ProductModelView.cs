namespace Frontend.Models.ViewModel
{
    public class ProductModelView
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
