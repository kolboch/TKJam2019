﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float enemyHP = 100f;
    float attack = 10f;
    public bool isAtacking = false;
    Color startColor;
    public ParabolaController parabola;

    private void Start()
    {
        startColor = GetComponent<Renderer>().material.color;
        StartCoroutine(Rotate(0.3f, 2.5f));
       
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(blink());
        if (other.gameObject.tag == "Player" && !isAtacking)
        {
            enemyHP -= other.GetComponent<PlayerController>().attack;
        }
        else
        {
            other.GetComponent<PlayerController>().stamina -= attack;
        }

        if (enemyHP <= 0)
        {
            this.gameObject.active = false;
            Destroy(this.gameObject);
        }
    }
 
    IEnumerator blink()
    {
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(.07f);
        GetComponent<Renderer>().material.color = startColor;
        yield return new WaitForSeconds(.07f);
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(.07f);
        GetComponent<Renderer>().material.color = startColor;
        yield return new WaitForSeconds(.07f);
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(.07f);
        GetComponent<Renderer>().material.color = startColor;

    }

 
    IEnumerator Rotate(float duration, float delay)
    {
        isAtacking = true;
        Quaternion startRot = transform.rotation;
        float t = 0.0f;
        while (t < duration)
        {
          
            t += Time.deltaTime;
       
            transform.localScale = new Vector3(transform.localScale.x, 0.003f, transform.localScale.z);
            transform.rotation = startRot * Quaternion.AngleAxis(t / duration * 1080f, Vector3.up); //or transform.right if you want it to be locally based
            yield return null;
        }
        transform.rotation = startRot;
        transform.localScale = new Vector3(transform.localScale.x, 0.005f, transform.localScale.z);
        isAtacking = false;
        yield return new WaitForSeconds(delay);
        parabola.moveParabola(5);
        StartCoroutine(Rotate(1, 3));

    }



}
