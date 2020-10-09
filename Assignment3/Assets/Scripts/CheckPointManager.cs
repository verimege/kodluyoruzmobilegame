
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace CheckPointSystem
{
    public class CheckPointManager : MonoBehaviour
    {

        [SerializeField] private List<CheckPointController> checkPoints = new List<CheckPointController>();
        public GameObject[] Spawner;
        private int _lastPassedCheckPoint;
        public Slider Sliderr;
        public Text SliderText;

        private void Start()
        {
            for (int i = 0; i < checkPoints.Count; i++)
            {
                checkPoints[i].checkPointManager = this;
                if (i == 0) checkPoints[i].isMyTurn = true;
            }
        }

        public void SetLastPassedCheckPoint(int id)
        {
            _lastPassedCheckPoint = id;
           

            if (checkPoints.Count - 1 > id)
            {
                checkPoints[id + 1].isMyTurn = true;
            }
           
        }
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {

                other.gameObject.transform.position = Spawner[_lastPassedCheckPoint].transform.position;

            }
        }


        private void Update()
        {
            float currentvalue = (float) ( ((float) _lastPassedCheckPoint + 1) / 5 );
            Sliderr.value = currentvalue;
            SliderText.text = "FLOOR" + "\n" + "\n"  + (_lastPassedCheckPoint+1);


        }
    }
}



