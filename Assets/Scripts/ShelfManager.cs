using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfManager : MonoBehaviour {

    [SerializeField] int shelfId;
    [SerializeField] string name;
    [SerializeField] int booksOnShelf;
    [SerializeField] string lastUpdated;

    // Use this for initialization
    void Start ()
    {
        var tm = gameObject.GetComponentInChildren<TextMesh>();
        tm.text = "Shelf name: " + name + "\n" +
            "Volumes on shelf: " + booksOnShelf + "\n" +
            "Last updated: " + lastUpdated;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed on shelf with ID: " + shelfId);
            //GameObject parent = transform.parent.gameObject;
            //parent.SetActive(false);
            SceneLoader.LoadNextScene();
        }
    }
}
