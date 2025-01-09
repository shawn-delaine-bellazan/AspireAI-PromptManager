namespace ProjectName.DataService.Models.Dtos
{
    public class PromptDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? PromptDesignId { get; set; }
        public int UserId { get; set; }
    }
}
