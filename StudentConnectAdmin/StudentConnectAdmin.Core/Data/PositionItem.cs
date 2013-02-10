using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentConnectAdmin.Data
{
    public sealed class PositionItem
    {
        public string OptionName { get { return string.Format("interest-{0}", this.Index); } }
        public int Index { get; set; }
        public string Value { get; set; }
    }
}
