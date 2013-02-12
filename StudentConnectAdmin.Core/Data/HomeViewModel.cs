using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentConnectAdmin.Data
{
    public sealed class StatisticsViewModel
    {
        public StatisticsViewModel()
        {
            List<JobTypePercent> Info = new List<JobTypePercent>();
        }

        public List<JobTypePercent> Info { get; set; }
    }

    public class JobTypePercent
    {
        public string Source { get; set; }
        public float Percentage { get; set; }
    }
}
