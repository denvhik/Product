namespace TestApp.Infrostructures.DataTable
{
    public class DTResult<T>
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public IEnumerable<T> data { get; set; }
    }
}
