using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private PlayerModel _playerModel;
    
    [SerializeField] private GameObject _scoreGmo;
    [SerializeField] private TextMeshProUGUI _scoreText, _bestScoreText;
    private Rigidbody rb;
    public Color32 a, b, c;
    public String d="Red";

    
    private CallBack _dieCallBack;

    public void SetCallBack(CallBack callBack)
    {
        _dieCallBack = callBack;
    }

    public void Start()
    {
        PlayerPrefs.SetInt("score",0);
        PlayerPrefs.Save();
        d = "Red";
        a=new Color32(255,0,0,255);
        b=new Color32(0,47,255,255);
        c=new Color32(0,255,13,255);

       

    }

    private void OnEnable()
    {
       // Reset();
        rb = GetComponent<Rigidbody>();
      //  _playerModel = new PlayerModel( GameManager.Instance.GetMaxScore());
        _scoreGmo.SetActive(true);
        
    }

    public void ColorChange()
    {

        if (this.gameObject.GetComponent<SpriteRenderer>().color == a)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = b;
            d = "Blue";
        }

        else if (this.gameObject.GetComponent<SpriteRenderer>().color == b)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = c; d = "Green";
        }

        else if (this.gameObject.GetComponent<SpriteRenderer>().color == c)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = a;
            d = "Red";
        }

        
    }
    

    public void Update()
    {
        _scoreText.text = PlayerPrefs.GetInt("score").ToString();

        if (PlayerPrefs.GetInt(("score")) > GameManager.Instance.GetMaxScore())
        {
            
            GameManager.Instance.SetMaxScore(PlayerPrefs.GetInt("score"));
            
        }
        _bestScoreText.text = GameManager.Instance.GetMaxScore().ToString();
     
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        
        if (d == collision.gameObject.tag)
        {
            
            int score = PlayerPrefs.GetInt("score");
            PlayerPrefs.SetInt("score", score+1);
            PlayerPrefs.Save();
            Destroy(collision.gameObject);
           
        }

        else
        {
            Destroy(collision.gameObject);
            
            Die();
        }
        // Reset();
            
    }
    
    public void Die()
    {
        
        var gameManager = GameManager.Instance;
        gameManager.SetMaxScore(PlayerPrefs.GetInt("score"));
        PlayerPrefs.SetInt("score",0);
        PlayerPrefs.Save();
        gameManager.SetState(StateType.EndGameState);
    }

  

    public void Reset()
    {
//        gameObject.transform.position = GameValues.Instance.startPosition;
    }
}
