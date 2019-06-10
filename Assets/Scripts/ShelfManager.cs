using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfManager : MonoBehaviour {

    [SerializeField] public int shelfId;
    [SerializeField] public string shelfName;
    [SerializeField] public int booksOnShelf;
    [SerializeField] public string lastUpdated;

    // Use this for initialization
    void Start ()
    {
        // Changes the text of the gameobject to be what is filled in in the inspector menu.
        var tm = gameObject.GetComponentInChildren<TextMesh>();
        tm.text = "Shelf name: " + shelfName + "\n" +
            "Volumes on shelf: " + booksOnShelf + "\n" +
            "Last updated: " + lastUpdated;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    /// <summary>
    /// Allows clicking on the cubes, loads the next scene and passes parameters with it.
    /// </summary>
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Create a dict
            Dictionary<string, string> info = new Dictionary<string, string>()
            {
                { "Shelf", shelfId.ToString() },
                { "VolumesOnShelf", booksOnShelf.ToString() }
            };
            // Load the next scene with the dict
            Scenes.Load("AR Books", info);
        }
    }
}
