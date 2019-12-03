namespace PrivateAccountant.Model.Classes
{
    public class TravelDetail
    {
        public int Id { get; set; }
        public Travel Travel { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Airlines { get; set; }
    }
}
