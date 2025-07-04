namespace VisualNovelGame.Models
{
    public class Choice
    {
        public string Text { get; set; }
        public string NextSceneId { get; set; }
        public string setFlag { get; set; }
        public List<Condition> Conditions { get; set; }

    }
}