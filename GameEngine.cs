using System.Security.Cryptography.X509Certificates;
using VisualNovelGame.Models;

public class GameEngine
{
    private SceneManager sceneManager;
    public static string userName;
    public GameEngine()
    {
        Console.WriteLine("Введите имя персонажа:");
        userName = Console.ReadLine();
        sceneManager = new SceneManager("Data/scenes.json");
    }

    public void Start()
    {

        while (true)
        {
            var currentScene = sceneManager.GetCurrentScene();
            var availableChoises = sceneManager.GetAvailableChoices(currentScene);
            int choiceIndex;

            Console.Clear();
            Console.WriteLine(currentScene.getText());

            for (int i = 0; i < availableChoises.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableChoises[i].Text}");

            }
            while (true)
            {
                string usersInput = Console.ReadLine();
                if (int.TryParse(usersInput, out int parsed)
                    && parsed >= 1
                    && parsed <= availableChoises.Count)
                {
                    choiceIndex = parsed - 1;
                    break;
                }
                Console.WriteLine("Выберите один из предложенных вариантов действий");
            }

            if (availableChoises[choiceIndex].setFlag != null)
            {
                sceneManager.SetFlag(availableChoises[choiceIndex].setFlag, true);
            }
            sceneManager.GoToNextScene(choiceIndex);

            if (sceneManager.IsGameOver())
                break;
        }

        Console.WriteLine("Спасибо за игру!");
    }
}