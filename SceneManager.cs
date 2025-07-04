using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using VisualNovelGame.Models;

public class SceneManager
{
    private Dictionary<string, Scene> scenes;
    private string currentSceneId;
    private Dictionary<string, bool> flags;
    public SceneManager(string pathToFile)
    {
        scenes = LoadScenes(pathToFile);
        currentSceneId = "start";
        flags = new Dictionary<string, bool>();
    }
    public void SetFlag(string key, bool value)
    {
        flags.Add(key, value);
    }
    public Scene GetCurrentScene() => scenes[currentSceneId];

    public void GoToNextScene(int choiceIndex)
    {
        var scene = scenes[currentSceneId];
        currentSceneId = scene.Choices[choiceIndex].NextSceneId;
    }

    public bool IsGameOver() => !scenes.ContainsKey(currentSceneId);

    private Dictionary<string, Scene> LoadScenes(string filePath)
    {
        string json = File.ReadAllText(filePath);
        var sceneList = JsonSerializer.Deserialize<List<Scene>>(json);
        return sceneList.ToDictionary(s => s.Id, s => s);
    }

    public bool CheckConditions(List<Condition> conditions)
    {
        for (int i = 0; i < conditions.Count; i++)
        {
            if (!flags.ContainsKey(conditions[i].flagName)
                || !flags[conditions[i].flagName])
            {
                return false;
            }

        }
        return true;
    }
}