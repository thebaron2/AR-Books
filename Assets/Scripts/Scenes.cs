using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A class that enables passing parameters when switching scenes.
/// </summary>
public class Scenes : MonoBehaviour
{
    private static Dictionary<string, string> parameters;

    public static void Load(string sceneName, Dictionary<string, string> parameters = null)
    {
        Scenes.parameters = parameters;
        SceneManager.LoadScene(sceneName);
    }

    public static void Load(string sceneName, string paramKey, string paramValue)
    {
        parameters = new Dictionary<string, string>();
        parameters.Add(paramKey, paramValue);
        SceneManager.LoadScene(sceneName);
    }

    public static Dictionary<string, string> getSceneParameters()
    {
        return parameters;
    }

    public static string GetParam(string paramKey)
    {
        if (parameters == null) return "";
        return parameters[paramKey];
    }

    public static void SetParam(string paramKey, string paramValue)
    {
        if (parameters == null)
            parameters = new Dictionary<string, string>();
        parameters.Add(paramKey, paramValue);
    }
}
