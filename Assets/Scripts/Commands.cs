using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commands : MonoBehaviour
{
    void OnSelect()
    {
        if (this.GetComponent<BoxCollider>())
        {
            Debug.Log("Test");
            //SceneLoader.LoadNextScene();
        }
    }
}
