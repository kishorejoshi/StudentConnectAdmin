using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentConnectAdmin.Data
{
    public sealed class HomeViewModel
    {
        public HomeViewModel()
        {
          List<ContactInfo>  Info = new List<ContactInfo>();
        }

        public List<ContactInfo> Info { get; set; }
    }

}
