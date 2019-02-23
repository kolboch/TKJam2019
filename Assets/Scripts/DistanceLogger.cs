using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceLogger : MonoBehaviour {
    public Text distance;
    private Vector3 lastPosition;
    Vector3 startPos;
    private float distanceTraveled;
    // Use this for initialization
   
   void Start () {
        startPos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        distanceTraveled = Vector3.Distance(Camera.main.transform.position, startPos);
        //lastPosition = transform.position;
        distance.text = distanceTraveled.ToString();
    }
}
