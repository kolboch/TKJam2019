﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSushi : MonoBehaviour {
    public GameObject sushi;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(sushi);
        }
    }
}
