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
    //[SerializeField] string filePath = @"C:\Users\owena\git\AR Books\AR Books\config.txt";

    // Use this for initialization
    void Start ()
    {
        List<Bookshelf> shelves = ReadShelvesFile();
        PlaceShelves(shelves, shelfPlaceholder);
    }

    private static List<Bookshelf> ReadShelvesFile()
    {
        using (StreamReader r = new StreamReader(@"c:\users\owena\jsonFiles\shelves.json"))
        {
            string json = r.ReadToEnd();
            List<Bookshelf> items = JsonConvert.DeserializeObject<Bookshelves>(json).Items.ToList();

            //Debug.Log(items.Count);
            //foreach (var item in items)
            //{
            //    Debug.Log(item.Id + "\n" + item.Title);
            //}
            //Debug.Log(items[1].Id + items[1].Title);
            //Debug.Log("----------------------------");
            return items;
        }
    }

    private static void PlaceShelves(List<Bookshelf> shelves, GameObject shelfPlaceholder)
    {
        int startIndex = 9;
        int maxShelves = 2;
        float startLocY = 0.8f;

        List<Bookshelf> tmpList = new List<Bookshelf>();
        //List<Bookshelf> tmpList = shelves.GetRange(8, 3);
        
        for (int i = startIndex; i <= maxShelves; i++)
        {
            tmpList.Add(shelves[i]);
        }

        foreach (var item in tmpList)
        {
            Debug.Log(item.Id + " " + item.Title);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
