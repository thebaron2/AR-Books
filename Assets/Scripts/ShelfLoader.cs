//using System;
//using System.Collections.Generic;
//using UnityEngine;
//using System.IO;
//using Google.Apis.Books.v1.Data;
//using Newtonsoft.Json;
//using System.Linq;

//public class ShelfLoader : MonoBehaviour
//{
//    // Config parameters
//    [SerializeField] GameObject shelfPlaceholder;
//    [SerializeField] GameObject shelfCollection;
//    //[SerializeField] int startIndex = 0;

//    //[SerializeField] string filePath = @"C:\Users\owena\git\AR Books\AR Books\config.txt";

//    // Use this for initialization
//    void Start()
//    {
//        PlaceShelves(shelfCollection, shelfPlaceholder);
//    }

//    private static void PlaceShelves(GameObject shelfCollection, GameObject shelfPlaceholder)
//    {
//        List<Bookshelf> allShelves = ReadShelvesFile();
//        var subLists = CreateSubLists(allShelves);
//        float xPos = 0f;

//        foreach (var list in subLists)
//        {
//            //shelfCollection = new GameObject("Collection");
//            GameObject collection = Instantiate(shelfCollection, new Vector3(xPos, 0f, 2f), Quaternion.identity) as GameObject;
//            collection.transform.SetParent(GameObject.Find("ShelfCollections").transform);
//            float yPos = 0.8f;
//            foreach (var shelf in list)
//            {
//                GameObject bookShelf = Instantiate(shelfPlaceholder, new Vector3(xPos, yPos, 2f), Quaternion.identity) as GameObject;
//                bookShelf.transform.SetParent(collection.transform);
//                yPos -= 0.4f;

//                var text = bookShelf.GetComponentInChildren<TextMesh>();
//                text.text = "Shelf name: " + shelf.Title + "\n" +
//                    "Volumes on shelf: " + shelf.VolumeCount + "\n" +
//                    "Last updated: " + shelf.VolumesLastUpdated;
//            }
//            xPos += 3f;
//        }
//    }

//    private static List<List<Bookshelf>> CreateSubLists(List<Bookshelf> shelves)
//    {
//        var max = 3;
//        var total = shelves.Count();

//        var taken = 0;
//        var sublists = new List<List<Bookshelf>>(); //your final result
//        while (taken < total)
//        {
//            var sublst = shelves.Skip(taken)
//                .Take(taken + max > total ? total - taken : max)
//                .ToList();
//            taken += max;
//            sublists.Add(sublst);
//        }

//        foreach (var smallList in sublists)
//        {
//            Debug.Log(smallList);
//            foreach (var small in smallList)
//            {
//                Debug.Log(small.Id);
//            }
//        }
//        return sublists;
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    /// <summary>
//    /// Reads JSON file containing information about
//    /// my bookshelves.
//    /// </summary>
//    /// <returns>
//    /// A list of Bookshelves.
//    /// </returns>
//    private static List<Bookshelf> ReadShelvesFile()
//    {
//        using (StreamReader r = new StreamReader(new FileStream("Assets/Resources/shelves.json", FileMode.Open)))
//        {
//            string json = r.ReadToEnd();
//            List<Bookshelf> items = JsonConvert.DeserializeObject<Bookshelves>(json).Items.ToList();
//            Debug.Log(items.Count);
//            foreach (var item in items)
//            {
//                Debug.Log(item.Id + "\n" + item.Title);
//            }
//            Debug.Log("----------------------------");
//            return items;
//        }
//    }
//}
