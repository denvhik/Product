using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace TestApp.Infrostructures.DataTable
{
    public class DataTableSearchModel
    {
        public DTFilteringType DTFilteringType { get; set; }
        public DTParameterModel? DTParameterModel { get; set; }
    }
}
