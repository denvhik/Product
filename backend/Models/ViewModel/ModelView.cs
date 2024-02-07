namespace backend.Models.ViewModel
{
    public class ModelView
    {
        public IEnumerable<Group> groups { get; set; }
        public string ProductName{ get; set; }
        public string GroupName { get; set; }
        public IEnumerable<Category> categories { get; set; }    
    }
}
