using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour {

    public void Quitt()
    {

#if UNITY_STANDALONE 

		Application.Quit();

#endif


#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}