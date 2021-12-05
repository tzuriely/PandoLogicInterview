using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace PandoLogic.Domain
{
    public class Day
    {
        [Key]
        public DateTime Date { get; set; }
        public long TotalViews { get; set; }
        public long CumulativePredicted { get; set; }
        public long ActiveJobs { get; set; }
    }
}