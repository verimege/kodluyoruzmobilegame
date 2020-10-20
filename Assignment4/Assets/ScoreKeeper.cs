using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private  Text[] Scores;
    private float[] lstscores = new float[10];
    void Start()
    {

        ScoreAssign();
        
    }

    private void OnEnable()
    {
        for (int i = 0; i < 10; i++)
        {

            lstscores[i] = PlayerPrefsX.GetFloatArray("ScoresLast")[i];

        }
    }

    public void ScoreAssign()
    {
        

        for (int a = 0; a < 10; a++)
        {


            Scores[a].text = lstscores[a].ToString("f2");

        }


    }
    
   
}
