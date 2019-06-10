using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commands : MonoBehaviour
{
    // TODO: fix gaze and select gesture, doesn't work!
    void OnSelect()
    {
        // Check the gameObject's tag
        if (gameObject.tag == "ShelfHolder")
        {
            //var rigidbody = gameObject.AddComponent<Rigidbody>();
            //rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
            var component = gameObject.GetComponent<ShelfManager>();

            Dictionary<string, string> info = new Dictionary<string, string>()
            {
                { "Shelf", component.shelfId.ToString() },
                { "VolumesOnShelf", component.booksOnShelf.ToString() }
            };
            Scenes.Load("AR Books", info);
        }
        else if (gameObject.tag == "BackButton")
        {
            Scenes.Load("AR Shelves");
        }
    }
}
