using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float attack = 10f;
    public float stamina = 100f;
    public int lootCount = 0;
    public float staminaSpeed = 1f;
    public DistanceLogger logger;
    public Text staminaTxt;
	
	
	// Update is called once per frame
	void Update () {
         if (stamina < 100 && stamina > 0)
        {
            stamina += Time.deltaTime * staminaSpeed;
            stamina -= logger.distanceTraveled;
        }

        staminaTxt.text = stamina.ToString();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "loot")
        {
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            lootCount++;
        }
        if(other.gameObject.tag == "lootDrop")
        {
            other.GetComponent<ThrowSushi>().doIt2(lootCount);
        }
    }
}
