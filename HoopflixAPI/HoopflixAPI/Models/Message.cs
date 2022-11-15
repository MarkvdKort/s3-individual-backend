namespace HoopflixAPI.Models
{
    public class Message
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ChatID { get; set; }
        public string MessageContent { get; set; }
        public string Type { get; set; }
        public string Time { get; set; }
        public int New { get; set; }
    }
}
