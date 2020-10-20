using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameOverManage : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Score,Best;
    
    
    void Start()
    {
        
        Score.text = PlayerPrefs.GetFloat("TimeLeft").ToString("F1");
        Best.text = PlayerPrefs.GetFloat("bestTime").ToString("F1");
        
    }

    // Update is called once per frame
    public void Restart()
    {
        
        Application.LoadLevel(0);
        
    }
    
    
    
}
