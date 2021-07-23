using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public Vector3 dir;
    public float speed;
    void Start()
    {

    }

    public void Destruction()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
    public void MissedNote()
    {
        Debug.Log("Missed this note");
    }
}
