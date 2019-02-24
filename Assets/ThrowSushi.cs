using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSushi : MonoBehaviour {
    public GameObject sushi;
 
 
    public IEnumerator doIt2(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(sushi);
            yield return new WaitForSeconds(0.15f);
        }
       
    }
    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(sushi);
        }
    }
}
