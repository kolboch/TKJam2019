using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour {

    public GameObject sword;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            sword.SetActive(true);
            this.gameObject.active = false;
            Destroy(this.gameObject);
        }
    }

   

 
}
