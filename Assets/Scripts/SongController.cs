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
    public int maxCombo = 0;
    public float score = 0;
    public Text comboText;
    public Text scoreText;
    public AudioSource audioSource;
    public AudioClip song;
    public float waitForSong;
    public float maxTimeHold; // max holding time
    private float HoldTime1 = 0;
    private float HoldTime2 = 0;
    private float HoldTime3 = 0;
    private float HoldTime4 = 0;
    private bool overhold1 = false;
    private bool overhold2 = false;
    private bool overhold3 = false;
    private bool overhold4 = false;
    public float minTimeDelay; // delay after using trigger
    private float DelayTime1 = 0.1f;
    private float DelayTime2 = 0.1f;
    private float DelayTime3 = 0.1f;
    private float DelayTime4 = 0.1f;
    public float health = 100;
    public Image healthFill;
    public GameObject[] priestsInScene;
    public GameObject lostPanel;
    public Text comboLoseText;
    public Text scoreLoseText;
    public Text comboWinText;
    public Text scoreWinText;
    public GameObject comboPanel;
    public GameObject scorePanel;
    public GameObject winPanel;
    void Start()
    {
        notesInScene = GameObject.FindGameObjectsWithTag("Note");
        UpdateSpeed();
        trigger1Controller = trigger1.GetComponent<TriggerController>();
        trigger2Controller = trigger2.GetComponent<TriggerController>();
        trigger3Controller = trigger3.GetComponent<TriggerController>();
        trigger4Controller = trigger4.GetComponent<TriggerController>();
        StartCoroutine( WaitForPlayingSong(waitForSong));
        DelayTime1 = minTimeDelay;
        DelayTime2 = minTimeDelay;
        DelayTime3 = minTimeDelay;
        DelayTime4 = minTimeDelay;
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
        healthFill.fillAmount = health / (float)100;


        if (Input.GetKey(KeyCode.A) && !overhold1 && minTimeDelay<=DelayTime1)
        {

            HoldTime1 += Time.deltaTime;
            if (!trigger1Controller.triggered)
            {
                trigger1Controller.ChangeIndicator(trigger1Controller.TriggeredMaterial);
                trigger1Controller.triggered = true;
            }
            if (trigger1Controller.TriggerNote())
            {
                combo++;
                if(combo >= maxCombo)
                {
                    maxCombo = combo;
                }
            }
            if(HoldTime1 > maxTimeHold)
            {
                overhold1 = true;
            }
            /*else
            {
               HoldTime1 = 0;
               combo = 0;
            }*/
        }
        else if (!Input.GetKey(KeyCode.A)&&overhold1)
        {
            DelayTime1 = 0;
            HoldTime1 = 0;
            overhold1 = false;
        }
        else if (trigger1Controller.triggered)
        {
            DelayTime1 = 0;
            HoldTime1 = 0;
            trigger1Controller.ChangeIndicator(trigger1Controller.BasicMaterial);
            trigger1Controller.triggered = false;
        }
        if(!Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.A)&& minTimeDelay >= DelayTime1))
        {
            DelayTime1 += Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.S) && !overhold2 && minTimeDelay <= DelayTime2)
        {

            HoldTime2 += Time.deltaTime;
            if (!trigger2Controller.triggered)
            {
                trigger2Controller.ChangeIndicator(trigger2Controller.TriggeredMaterial);
                trigger2Controller.triggered = true;
            }
            if (trigger2Controller.TriggerNote())
            {
                combo++;
                if (combo >= maxCombo)
                {
                    maxCombo = combo;
                }
            }
            if (HoldTime2 > maxTimeHold)
            {
                overhold2 = true;
            }
            /*else
            {
               HoldTime1 = 0;
               combo = 0;
            }*/
        }
        else if (!Input.GetKey(KeyCode.S) && overhold2)
        {
            DelayTime2 = 0;
            HoldTime2 = 0;
            overhold2 = false;
        }
        else if (trigger2Controller.triggered)
        {
            DelayTime2 = 0;
            HoldTime2 = 0;
            trigger2Controller.ChangeIndicator(trigger2Controller.BasicMaterial);
            trigger2Controller.triggered = false;
        }
        if (!Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.S) && minTimeDelay >= DelayTime2))
        {
            DelayTime2 += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D) && !overhold3 && minTimeDelay <= DelayTime3)
        {

            HoldTime3 += Time.deltaTime;
            if (!trigger3Controller.triggered)
            {
                trigger3Controller.ChangeIndicator(trigger3Controller.TriggeredMaterial);
                trigger3Controller.triggered = true;
            }
            if (trigger3Controller.TriggerNote())
            {
                combo++;
                if (combo >= maxCombo)
                {
                    maxCombo = combo;
                }
            }
            if (HoldTime3 > maxTimeHold)
            {
                overhold3 = true;
            }
            /*else
            {
               HoldTime1 = 0;
               combo = 0;
            }*/
        }
        else if (!Input.GetKey(KeyCode.D) && overhold3)
        {
            DelayTime3 = 0;
            HoldTime3 = 0;
            overhold3 = false;
        }
        else if (trigger3Controller.triggered)
        {
            DelayTime3 = 0;
            HoldTime3 = 0;
            trigger3Controller.ChangeIndicator(trigger3Controller.BasicMaterial);
            trigger3Controller.triggered = false;
        }
        if (!Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.D) && minTimeDelay >= DelayTime3))
        {
            DelayTime3 += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.F) && !overhold4 && minTimeDelay <= DelayTime4)
        {

            HoldTime4 += Time.deltaTime;
            if (!trigger4Controller.triggered)
            {
                trigger4Controller.ChangeIndicator(trigger4Controller.TriggeredMaterial);
                trigger4Controller.triggered = true;
            }
            if (trigger4Controller.TriggerNote())
            {
                combo++;
                if (combo >= maxCombo)
                {
                    maxCombo = combo;
                }
            }
            if (HoldTime4 > maxTimeHold)
            {
                overhold4 = true;
            }
            /*else
            {
               HoldTime1 = 0;
               combo = 0;
            }*/
        }
        else if (!Input.GetKey(KeyCode.F) && overhold4)
        {
            DelayTime4 = 0;
            HoldTime4 = 0;
            overhold4 = false;
        }
        else if (trigger4Controller.triggered)
        {
            DelayTime4 = 0;
            HoldTime4 = 0;
            trigger4Controller.ChangeIndicator(trigger4Controller.BasicMaterial);
            trigger4Controller.triggered = false;
        }
        if (!Input.GetKey(KeyCode.F) || (Input.GetKey(KeyCode.F) && minTimeDelay >= DelayTime4))
        {
            DelayTime4 += Time.deltaTime;
        }

        scoreText.text = score.ToString();
        comboText.text = combo.ToString();
    }
    public void Miss()
    {
        health -= 30;
        if(health <=0)
        {
            LoseGame();
        }    
        combo = 0;
    }
    private void LoseGame()
    {
        Time.timeScale = 0;
        audioSource.Stop();
        comboLoseText.text = maxCombo.ToString();
        scoreLoseText.text = scoreText.text;
        comboPanel.SetActive(false);
        scorePanel.SetActive(false);
        lostPanel.SetActive(true);
        Debug.Log("Lost game");
    }
    public void WinGame()
    {

        comboPanel.SetActive(false);
        scorePanel.SetActive(false);
        comboWinText.text = maxCombo.ToString();
        scoreWinText.text = scoreText.text;
        winPanel.SetActive(true);
    }

    private IEnumerator WaitForPlayingSong(float waitTime)
    {
        Debug.Log("Started coroutine");
        yield return new WaitForSeconds(waitTime);
        audioSource.clip = song;
        audioSource.Play();
    }
}
