using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookLoader : MonoBehaviour
{
    // Config parameters
    [SerializeField] GameObject bookPlaceholder;

	// Use this for initialization
	void Start ()
    {
        //GameObject go = Instantiate(bookPlaceholder, new Vector3(-1.1f, 1.7f, 4), Quaternion.identity) as GameObject;
        //go.transform.parent = GameObject.Find("BookCollection").transform;
	}
}
