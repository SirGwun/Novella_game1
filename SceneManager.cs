using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using NovellGame.Models;

public class SceneManager
{
    Dictionary<string, Scene> scenes;
    string currentSceneId;

    public SceneManager(string pathToFile)
    {
        scenes = LoadScenes(pathToFile);
        currentSceneId = "start";
    }

    internal Scene GetCurrentScene() => scenes[currentSceneId];

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
}