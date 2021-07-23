using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongController : MonoBehaviour
{
    public GameObject[] notesInScene;
    public float BPM;
    public float speedMultiplier;
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
    public Text comboText;
    public Text scoreText;
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
            note.GetComponent<TargetScript>().speed = speedMultiplier * (BPM/60);
        }
    }
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            if(!trigger1Controller.triggered)
            {
                trigger1Controller.ChangeIndicator(trigger1Controller.TriggeredMaterial);
                trigger1Controller.triggered = true;
            }
            if (trigger1Controller.TriggerNote())
            {
                combo++;
            }
            else
            {
                combo=0;
            }
        }
        else if(trigger1Controller.triggered)
        {
            trigger1Controller.ChangeIndicator(trigger1Controller.BasicMaterial);
            trigger1Controller.triggered = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (!trigger2Controller.triggered)
            {
                trigger2Controller.ChangeIndicator(trigger2Controller.TriggeredMaterial);
                trigger2Controller.triggered = true;
            }
            if (trigger2Controller.TriggerNote())
            {
                combo++;
            }
            else
            {
                combo = 0;
            }
        }
        else if (trigger2Controller.triggered)
        {
            trigger2Controller.ChangeIndicator(trigger2Controller.BasicMaterial);
            trigger2Controller.triggered = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (!trigger3Controller.triggered)
            {
                trigger3Controller.ChangeIndicator(trigger3Controller.TriggeredMaterial);
                trigger3Controller.triggered = true;
            }
            if (trigger3Controller.TriggerNote())
            {
                combo++;
            }
            else
            {
                combo = 0;
            }
        }
        else if (trigger3Controller.triggered)
        {
            trigger3Controller.ChangeIndicator(trigger3Controller.BasicMaterial);
            trigger3Controller.triggered = false;
        }
        if (Input.GetKey(KeyCode.F))
        {
            if (!trigger4Controller.triggered)
            {
                trigger4Controller.ChangeIndicator(trigger4Controller.TriggeredMaterial);
                trigger4Controller.triggered = true;
            }
            if (trigger4Controller.TriggerNote())
            {
                combo++;
            }
            else
            {
                combo = 0;
            }
        }
        else if (trigger4Controller.triggered)
        {
            trigger4Controller.ChangeIndicator(trigger4Controller.BasicMaterial);
            trigger4Controller.triggered = false;
        }
        scoreText.text = score.ToString("2f");
        comboText.text = combo.ToString("2f");
    }
    public void Miss()
    {
        combo = 0;
    }
}
