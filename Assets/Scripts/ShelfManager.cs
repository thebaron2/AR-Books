using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfManager : MonoBehaviour {

    [SerializeField] int shelfId;
    [SerializeField] int booksOnShelf;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed on shelf with ID: " + shelfId);
            GameObject parent = transform.parent.gameObject;
            parent.SetActive(false);
        }
    }
}
