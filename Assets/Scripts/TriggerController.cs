using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public GameObject note;
    public bool canTrigger;
    public SongController songController;
    public Material BasicMaterial;
    public Material TriggeredMaterial;
    public GameObject TriggerIndicator;
    public bool triggered = false;
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
            if(songController.health <=90)
            {
                songController.health += 10;
            }
            songController.score += 100 * ((float)(songController.combo+1)/10);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ChangeIndicator(Material mat)
    {
        TriggerIndicator.GetComponent<Renderer>().material = mat;
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
