using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Newtonsoft.Json;
using Assets.Scripts;
using System.Linq;

public class ShelfLoader : MonoBehaviour
{
    // Config parameters
    [SerializeField] GameObject shelfPlaceholder;
    [SerializeField] int startIndex = 0;

    //[SerializeField] string filePath = @"C:\Users\owena\git\AR Books\AR Books\config.txt";

    // Use this for initialization
    void Start ()
    {
        List<Bookshelf> shelves = ReadShelvesFile();
        PlaceShelves(shelves, shelfPlaceholder, "ShelfCollection", startIndex);
    }

	// Update is called once per frame
	void Update ()
    {
		
	}

    /// <summary>
    /// Reads JSON file containing information about
    /// my bookshelves.
    /// </summary>
    /// <returns>
    /// A list of Bookshelves.
    /// </returns>
    private static List<Bookshelf> ReadShelvesFile()
    {
        using (StreamReader r = new StreamReader(@"c:\users\owena\jsonFiles\shelves.json"))
        {
            string json = r.ReadToEnd();
            List<Bookshelf> items = JsonConvert.DeserializeObject<Bookshelves>(json).Items.ToList();

            Debug.Log(items.Count);
            foreach (var item in items)
            {
                Debug.Log(item.Id + "\n" + item.Title);
            }
            Debug.Log("----------------------------");
            return items;
        }
    }

    private static void PlaceShelves(List<Bookshelf> shelves, GameObject shelfPlaceholder, string parent, int startIndex)
    {
        List<Bookshelf> list = RetrieveShelves(shelves, shelfPlaceholder, startIndex);

        float startLocY = 0.8f;

        foreach (var item in list)
        {
            Debug.Log(item.Id + " " + item.Title);
            GameObject shelf = Instantiate(shelfPlaceholder, new Vector3(0f, startLocY, 2f), Quaternion.identity) as GameObject;

            shelf.transform.SetParent(GameObject.Find(parent).transform);
            startLocY -= 0.4f;
        }
    }

    private static List<Bookshelf> RetrieveShelves(List<Bookshelf> shelves, GameObject shelfPlaceholder, int startIndex)
    {
        int maxShelves = 3;
        int maxNumberOfShelves = startIndex + 2;

        List<Bookshelf> tmpList = new List<Bookshelf>();

        for (int i = startIndex; i < shelves.Count; i++)
        {
            if (i <= maxNumberOfShelves)
            {
                tmpList.Add(shelves[i]);
            }
        }
        return tmpList;
    }
}
