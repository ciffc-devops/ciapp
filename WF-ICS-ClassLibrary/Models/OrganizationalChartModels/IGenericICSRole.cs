using System;

namespace WF_ICS_ClassLibrary.Models.OrganizationalChartModels
{
    public interface IGenericICSRole
    {
        Guid GenericRoleID { get; set; }
        string MnemonicAbrv { get; set; }
        Guid ReportsToGenericRoleID { get; set; }
        string RoleDescription { get; set; }
        string RoleNameWithPlaceholder { get; set; }
        Guid SectionID { get; set; }
        bool OnInitialOrgChart { get; set; }
        bool RequiresOperationalGroup { get; set; }
        int ManualSortOrder { get; set; }
        string PDFFieldName { get; set; }
    }
}