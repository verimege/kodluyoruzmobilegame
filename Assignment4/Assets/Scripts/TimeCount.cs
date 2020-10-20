using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeCount : MonoBehaviour
{
    public Text timeText, bestText;
    private float[] lastscores = new float[10];
    
    public float timeLeft = 0f;
    public GameObject Panel;
    private void Awake()
    {
        PlayerPrefs.SetInt("Gaming",1);
        PlayerPrefs.Save();
        
        
        bestText.text = PlayerPrefs.GetFloat("bestTime",500f).ToString("F1");
        
    }

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {

            lastscores[i] = PlayerPrefsX.GetFloatArray("ScoresLast")[i];

        }
        
        
        if (!beingHandled) { 
            Panel.SetActive(true);
            StartCoroutine(HandleIt());
        }

        
    }
    
    private bool beingHandled = false;
    private IEnumerator HandleIt()
    {
        beingHandled = true;
        yield return new WaitForSeconds(4f);
        Panel.SetActive(false);
        beingHandled = false;
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("Gaming") == 1)
        {
            timeLeft += Time.deltaTime;
            timeText.text = timeLeft.ToString("F1");
        }

        else
        {
            PlayerPrefs.SetFloat("TimeLeft",timeLeft);
            PlayerPrefs.Save();
            for (int num = 9; num>0; num--)
            {

                lastscores[num ] = lastscores[num-1];

            }

            lastscores[0] = timeLeft;
            PlayerPrefsX.SetFloatArray("ScoresLast", lastscores);
            
            

            if (timeLeft < PlayerPrefs.GetFloat("bestTime",500f))
            {
                PlayerPrefs.SetFloat("bestTime",timeLeft);
                PlayerPrefs.Save();
                
            }
        }
    }

    
}
