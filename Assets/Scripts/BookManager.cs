using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour {
    [SerializeField] GameObject bookPlaceholder;

	// Use this for initialization
	void Start ()
    {
        Book book1 = new Book("A Dance with Dragons", "A Song of Ice and Fire: Book Five", "George R. R. Martin", 1040);
        Book book2 = new Book("The Lady of the Lake", "", "Andrzej Sapkowski", 544);
        Book book3 = new Book("The Tower of the Swallow", "", "Andrzej Sapkowski", 400);

        Dictionary<string, string> info = Scenes.getSceneParameters();
        foreach (KeyValuePair<string, string> y in info){
            Debug.Log(y.Key + " " + y.Value);
        }

        if (info["VolumesOnShelf"] != 0.ToString())
        {
            int numberOfBooks = 0;
            
            if (Int32.TryParse(info["VolumesOnShelf"], out numberOfBooks))
            {
                float xStart = -0.5f;
                Book[] books = { book1, book2, book3 };
                int bookIndex = 0;
                // TODO: Update so it only spawns a max of 3 bookObjects.
                for (int i = 0; i < numberOfBooks; i++)
                {
                    GameObject bookHolder = Instantiate(bookPlaceholder, new Vector3(xStart, 0f, 2f), Quaternion.identity) as GameObject;
                    bookHolder.transform.parent = GameObject.Find("BookCollection").transform;

                    TextMesh text = bookHolder.GetComponentInChildren<TextMesh>();
                    text.text = "Title:\n" + books[bookIndex].Title + "\n\n" +
                        "Author:\n" + books[bookIndex].Author + "\n\n" +
                        "Page count:\n" + books[bookIndex].PageCount;

                    xStart += 0.5f;
                    bookIndex += 1;
                }
            } 
        }
	}

    //private void OnMouseOver()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {

    //    }
    //}

    // Update is called once per frame
    void Update ()
    {
		
	}
}

public class Book
{
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Author { get; set; }
    public int PageCount { get; set; }

    public Book(string title, string subTitle, string author, int pageCount)
    {
        Title = title;
        SubTitle = subTitle;
        Author = author;
        PageCount = pageCount;
    }
}
