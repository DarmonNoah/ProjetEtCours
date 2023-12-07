namespace newWebAPI.Models.DTOs
{

    public class BookUpdateDTO
    {
        //public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public float Price { get; set; }
        public DateTime PublishDate { get; set; }
        public string? Description { get; set; }
        public string? Remarks { get; set; }
    }
}