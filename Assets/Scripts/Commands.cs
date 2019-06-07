using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commands : MonoBehaviour
{
    void OnSelect()
    {
        if (gameObject.tag == "ShelfHolder")
        {
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
