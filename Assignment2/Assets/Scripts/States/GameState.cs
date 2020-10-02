using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour, IState
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private DropController _dropController;
    
    
    

    public void Enter()
    {
     
        _player.enabled = true;
        _player.SetCallBack(StopGameLoop);
        _dropController.enabled = true;

       
    }

    public void Exit()
    {
        StopGameLoop();
    }

    private void StopGameLoop()
    {
        _player.Reset();
        _player.enabled = false;
        _dropController.enabled = false;
    }

  
}
