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
        var tm = gameObject.GetComponentInChildren<TextMesh>();
        tm.text = "Shelf name: " + shelfName + "\n" +
            "Volumes on shelf: " + booksOnShelf + "\n" +
            "Last updated: " + lastUpdated;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Dictionary<string, string> info = new Dictionary<string, string>()
            {
                { "Shelf", shelfId.ToString() },
                { "VolumesOnShelf", booksOnShelf.ToString() }
            };
            //Debug.Log("Pressed on shelf with ID: " + shelfId);
            Scenes.Load("AR Books", info);
        }
    }
}
