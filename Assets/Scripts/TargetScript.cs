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
    public bool isLast = false;
    private SongController songController;
    private void Start()
    {
        songController = GameObject.FindWithTag("GameController").GetComponent<SongController>();
    }
    public void Destruction()
    {
        if(isLast)
        {
            songController.WinGame();
        }
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
        if (isLast)
        {
            songController.WinGame();
        }
        Debug.Log("Missed this note");
    }
}
