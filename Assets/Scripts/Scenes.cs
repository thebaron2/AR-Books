using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A class that enables passing parameters when switching scenes.
/// </summary>
public class Scenes : MonoBehaviour
{
    // An empty dict for the parameters
    private static Dictionary<string, string> parameters;

    /// <summary>
    /// Loads a scene by name with a optional parameter of dict.
    /// </summary>
    /// <param name="sceneName">String, the name of the scene</param>
    /// <param name="parameters">
    /// Dict, the parameters that are to passed to the next scene
    /// </param>
    public static void Load(string sceneName, Dictionary<string, string> parameters = null)
    {
        Scenes.parameters = parameters;
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Loads a scene by name with a parameter key and value
    /// </summary>
    /// <param name="sceneName">String, the name of the scene</param>
    /// <param name="paramKey">String, the key within a dict</param>
    /// <param name="paramValue">String, the value belonging to the key</param>
    public static void Load(string sceneName, string paramKey, string paramValue)
    {
        parameters = new Dictionary<string, string>();
        parameters.Add(paramKey, paramValue);
        SceneManager.LoadScene(sceneName);
    }

    public static Dictionary<string, string> GetSceneParameters()
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
