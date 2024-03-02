namespace Jujustu_API.Models
{
    public class Move
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Difficulty { get; set; }
        public string BeltRecommendation { get; set; }
        public bool LegalInCompetition { get; set; }
        public string Goal { get; set; }
        public string Type { get; set; }
    }
}
