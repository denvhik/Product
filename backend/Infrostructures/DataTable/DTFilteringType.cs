using System.ComponentModel;

namespace TestApp.Infrostructures.DataTable
{
    public enum DTFilteringType
    {
        [Description("eq")]
        eq, // "equal"
        [Description("ne")]
        ne, // "not equal"
        [Description("lt")]
        lt, // "less"
        [Description("le")]
        le, // "less or equal"
        [Description("gt")]
        gt, // "greater"
        [Description("ge")]
        ge, // "greater or equal"
        [Description("bw")]
        bw, // "begins with"
        [Description("bn")]
        bn, // "does not begin with"
        [Description("ew")]
        ew, // "ends with"
        [Description("en")]
        en, // "does not end with"
        [Description("cn")]
        cn, // "contains"
        [Description("nc")]
        nc  // "does not contain"
    }
}
