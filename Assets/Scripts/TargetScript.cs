using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float showLine=10;
    public bool showed =false;
    public Vector3 dir;
    public float speed;
    void Start()
    {

    }

    public void Destruction()
    {
        gameObject.SetActive(false);
    }
    void FixedUpdate()
    {
        transform.position += dir * speed * Time.deltaTime;
        if(transform.position.z < showLine && !showed)
        {
            showed = true;
            ShowNote();
        }
    }
    public void ShowNote()
    {
        Debug.Log("Showed this note");
        gameObject.GetComponent<Renderer>().enabled = true;
    }
    public void MissedNote()
    {
        Debug.Log("Missed this note");
    }
}
