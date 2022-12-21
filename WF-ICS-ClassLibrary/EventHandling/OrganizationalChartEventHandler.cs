using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
    public delegate void OrganizationalChartEventHandler(OrganizationChartEventArgs e);

    public class OrganizationChartEventArgs
    {
        public OrganizationChart item { get; set; }

        public OrganizationChartEventArgs(OrganizationChart _item) { item = _item; }
    }

    public delegate void ICSRoleEventHandler(ICSRoleEventArgs e);

    public class ICSRoleEventArgs
    {
        public ICSRole item { get; set; }

        public ICSRoleEventArgs(ICSRole _item) { item = _item; }
    }
}
