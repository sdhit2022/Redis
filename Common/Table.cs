namespace Redis.Common
{
    public class Table
    {
        public string DBName { get; set; }
        public double Insert { get; set; }
        public double Update { get; set; }
        public double Select { get; set; }
        public double Delete { get; set; }
        public List<DBusage> Usage { get; set; }

    }


}
