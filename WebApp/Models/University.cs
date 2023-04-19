namespace WebApp.Models
{
    public class University
    {
        //entity framework
        public int Id { get; set; }
        public int QSRank { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string Website { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Image { get; set; } = null!;
    }
}
