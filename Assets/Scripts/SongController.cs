using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongController : MonoBehaviour
{
    public GameObject[] notesInScene;
    public float BPM;
    public float interval;
    public GameObject trigger1;
    public GameObject trigger2;
    public GameObject trigger3;
    public GameObject trigger4;
    private TriggerController trigger1Controller;
    private TriggerController trigger2Controller;
    private TriggerController trigger3Controller;
    private TriggerController trigger4Controller;
    public int combo = 0;
    public float score = 0;
    void Start()
    {
        notesInScene = GameObject.FindGameObjectsWithTag("Note");
        UpdateSpeed();
        trigger1Controller = trigger1.GetComponent<TriggerController>();
        trigger2Controller = trigger2.GetComponent<TriggerController>();
        trigger3Controller = trigger3.GetComponent<TriggerController>();
        trigger4Controller = trigger4.GetComponent<TriggerController>();
    }

    void UpdateSpeed()
    {
        foreach(GameObject note in notesInScene)
        {
            note.GetComponent<TargetScript>().speed = 1;
        }

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if(trigger1Controller.TriggerNote())
            {
                combo++;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (trigger2Controller.TriggerNote())
            {
                combo++;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (trigger3Controller.TriggerNote())
            {
                combo++;
            }
        }
        if (Input.GetKey(KeyCode.F))
        {
            if (trigger4Controller.TriggerNote())
            {
                combo++;
            }
        }

    }
    public void Miss()
    {
        combo = 0;
    }
}
