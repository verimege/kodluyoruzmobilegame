using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PreGameState : MonoBase, IState
{
    [SerializeField] private GameObject _waitScreen;
    [SerializeField] private TextMeshProUGUI _waitText;
    [SerializeField] private TextMeshProUGUI _bestScoreText;

    private bool _isWaitingToStart;
    
    private InputController _inputController;


    public void Enter()
    {
        
        _inputController = new InputController(HandleInputResult);

        _isWaitingToStart = true;
        
        _waitScreen.SetActive(true);
        _bestScoreText.text = GameManager.Instance.GetMaxScore().ToString();
    }

    private void HandleInputResult()
    {
        GameManager.Instance.SetState(StateType.GameState);
    }

    public void Exit()
    {
        _isWaitingToStart = false;
        _inputController = null;
        _waitScreen.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.Instance.GetCurrentState() != this) return;

        _inputController?.GetInput();
    }

    
}
