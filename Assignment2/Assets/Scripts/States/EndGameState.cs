using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndGameState : MonoBehaviour , IState
{

    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private Text _bestScoreText;
    [SerializeField] private Text _ScoreText;
    private Button restartButton;
    
    public void Enter()
    {
        _gameOverScreen.SetActive(true);
        _bestScoreText.text ="High Score : " + GameManager.Instance.GetMaxScore().ToString();
        _ScoreText.text = "Score : " + PlayerPrefs.GetInt("score").ToString();
        restartButton = _gameOverScreen.GetComponentInChildren<Button>();
        restartButton.onClick.AddListener(HandlePauseButton);
        
        
    }

    public void Exit()
    {
        _gameOverScreen.SetActive(false);
      
    }


    private void HandlePauseButton()
    {
        GameManager.Instance.SetState(StateType.PreGameState);
    }
}