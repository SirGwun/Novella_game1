using System.Collections.Generic;

namespace VisualNovelGame.Models
{
    public class Scene
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public List<Choice> Choices { get; set; }

        public string getText()
        {
            string userName = GameEngine.userName;
            Text = Text.Replace("$userName", userName);
            return Text;
        }

    }
}