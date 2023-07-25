namespace DataBase_Test.Common
{
    public class Result
    {
        public double Time { get; set; }
        public long Memory { get; set; }
        //public TimeSpan Cpu { get; set; }
    }

    public class DBusage
    {
        public string DBoperation { get; set; }
        public double Time { get; set; }
        public long Memory { get; set; }
        //public TimeSpan Cpu { get; set; }
    }
}
