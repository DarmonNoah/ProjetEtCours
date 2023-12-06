namespace newWebAPI.Models
{
    public class BaseModel
    {
        // created at 
        public DateTime CreatedAt { get; set; }
        // updated at
        public DateTime UpdatedAt { get; set; }
        // deleted at
        public DateTime DeletedAt { get; set; }
        // created by
        public string CreatedBy { get; set; } = String.Empty;

        // updated by
        public string UpdatedBy { get; set; } = String.Empty;
    }
}