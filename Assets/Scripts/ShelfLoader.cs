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
    [SerializeField] private static string filePath = @"C:\Users\owena\git\AR Books\AR Books\config.txt";

    // Use this for initialization
    void Start ()
    {
        ReadShelvesFile();
    }

    private static IList<Bookshelf> ReadShelvesFile()
    {
        using (StreamReader r = new StreamReader(@"c:\users\owena\jsonFiles\shelves.json"))
        {
            string json = r.ReadToEnd();
            IList<Bookshelf> items = JsonConvert.DeserializeObject<Bookshelves>(json).Items;
            Debug.Log(items.Count);
            foreach (var item in items)
            {
                Debug.Log(item.Id + "\n" + item.Title);
            }
            return items;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
