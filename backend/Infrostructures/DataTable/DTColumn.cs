namespace TestApp.Infrostructures.DataTable
{
    public class DTColumn
    {
        /// <summary>
        /// Column's data source
        /// </summary>
        public string? mData { get; set; }
        public string? Data { get; set; }
        public string? Value { get; set; }

        /// <summary>
        /// Column's name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Flag to indicate if this column is orderable (true) or not (false)
        /// </summary>
        public bool? Orderable { get; set; }

        /// <summary>
        /// Flag to indicate if this column is searchable (true) or not (false)
        /// </summary>
        public bool? Searchable { get; set; }

        /// <summary>
        /// Search to apply to this specific column.
        /// </summary>
        public DTSearch? Search { get; set; }
    }
}
