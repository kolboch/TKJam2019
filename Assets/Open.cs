using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour {

    public GameObject sword;
    public AudioClip tuturu;
    public AudioSource audio;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            audio.PlayOneShot(tuturu);
            sword.SetActive(true);
            this.gameObject.active = false;
            other.GetComponent<ParabolaController>().sword.GetComponent<MeshRenderer>().material = sword.GetComponent<MeshRenderer>().material;
            other.GetComponent<ParabolaController>().trail.GetComponent<TrailRenderer>().material = sword.GetComponent<MeshRenderer>().material;
            this.sword.active = false;
            Destroy(this.gameObject);
        }
    }

   

 
}
