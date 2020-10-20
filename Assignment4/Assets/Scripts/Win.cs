﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("Gaming",0);
            PlayerPrefs.Save();
            
            Application.LoadLevel(2);

        }
    }
}
