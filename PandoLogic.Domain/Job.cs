namespace PandoLogic.Domain
{
    public class Job
    {
        public int Id { get; set; }
        public long TotalViews { get; set; }
        public long CumulativePredicted { get; set; }
        public long ActiveJobs { get; set; }

        public int DateId { get; set; }
        public Day Date { get; set; }
    }
}