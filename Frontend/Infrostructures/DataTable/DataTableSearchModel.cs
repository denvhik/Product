using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TestApp.Infrostructures.DataTable
{
    [ValidateNever]
    public class DataTableSearchModel
    {
        public DTFilteringType DTFilteringType { get; set; }
        public DTParameterModel DTParameterModel { get; set; }
    }
}
