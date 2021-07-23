using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public GameObject note;
    public bool canTrigger;
    public SongController songController;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public bool TriggerNote()
    {
        if(canTrigger && note != null)
        {
            note.GetComponent<TargetScript>().Destruction();
            note = null;
            canTrigger = false;
            songController.score += 100 * ((float)(songController.combo+1)/10);
            return true;

        }
        else
        {
            return false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Note"))
        {
            note = other.gameObject;
            canTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        note = null;
        canTrigger = false;
        other.GetComponent<TargetScript>().MissedNote();
        songController.Miss();
    }
}