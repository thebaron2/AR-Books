using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commands : MonoBehaviour
{
    void OnSelect()
    {
        if (GetComponent<BoxCollider>())
        {
            Debug.Log("Test");
            //SceneLoader.LoadNextScene();
        }
    }
}
