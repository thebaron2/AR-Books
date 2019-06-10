using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    /// <summary>
    /// Loads the previous scene.
    /// Can be expanded by checking the objects tag before loading the previous scene.
    /// </summary>
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Scenes.Load("AR Shelves");
        }
    }
}
