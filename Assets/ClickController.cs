using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour {
    public ArenaController arena;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                // whatever tag you are looking for on your game object
                arena.setProgressValue(FirebaseDbUtils.getProgress());
                if (hit.transform.name == "HouseWhite" && FirebaseDbUtils.playerNum == 1)
                {
                    hit.transform.gameObject.GetComponent<ThrowSushi>().doIt();
                
                    //arena.setProgressValue(10);
                    //arena.setProgressValue(FirebaseDbUtils.getProgress());
                }
                if (hit.transform.name == "HouseBlack" && FirebaseDbUtils.playerNum == 2)
                {
                    //arena.setProgressValue(10);
                    //arena.setProgressValue(FirebaseDbUtils.getProgress());
                    hit.transform.gameObject.GetComponent<ThrowSushi>().doIt();
                }
            }
        }
    }
}
