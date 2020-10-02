using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dependency : MonoBehaviour
{
    // Start is called before the first frame update
    private Movement _Movement;
    private IInputHandler _inputHandler;
    public Text _MyText;
    void Start()
    {
        var ship = new Redball(new BallSpec(10, 2) );
        _Movement = new Movement();
        _inputHandler = (IInputHandler)new BallInput();
    }
    bool isMovingleft;
    bool isMovingright;
    bool isStaying;
    bool isJumping;

    // Update is called once per frame
    void Update()
    {
        
        isMovingleft = _inputHandler.GetInputForLeftMove();
        isMovingright = _inputHandler.GetInputForRightMove();
        isJumping = _inputHandler.GetInputForJump();
        isStaying = _inputHandler.GetInputForStay();
        _Movement.LeftMove(isMovingleft, _MyText);
        _Movement.RightMove(isMovingright, _MyText);
        _Movement.Stay(isStaying, _MyText);
        _Movement.Jump(isJumping,  _MyText);
        
    }
    
    public class Redball
    {
       
        private BallSpec _Ball;

        public Redball(BallSpec ballSpec)
        {
            _Ball = ballSpec;
            
        }

        
    }

    public interface IBall
    {
        void Stay(bool stay, Text _MyText);
        void LeftMove(bool move, Text _MyText);
        void RightMove(bool move, Text _MyText);
        void Jump(bool jump, Text _MyText);
    }

    public class Movement : IBall
    {
     
        

        public void LeftMove(bool move, Text _MyText)
        {
            if(move)
                _MyText.text = "Ball is moving to left";
        }
        
        public void RightMove(bool move, Text _MyText)
        {
            if(move)
                _MyText.text = "Ball is moving to right";
        }

        public void Stay(bool stay, Text _MyText)
        {
            if(stay)
                _MyText.text = "Ball is staying";
        }
        
        public void Jump(bool jump, Text _MyText)
        {
            if(jump)
                _MyText.text = "Ball is jumping";
        }
    }

    public interface IInputHandler
    {
        bool GetInputForLeftMove();
        bool GetInputForRightMove();
        bool GetInputForJump();
        bool GetInputForStay();
    }

    public class BallInput : IInputHandler
    {
        public bool GetInputForRightMove()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                return true;
            }
            return false;
        }
        
        public bool GetInputForLeftMove()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) )
            {
                return true;
            }
            return false;
        }

        public bool GetInputForStay()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) )
            {
                return true;
            }
            return false;
        }

        public bool GetInputForJump()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) )
            {
                return true;
            }
            return false;
        }
    }
    

    public class BallSpec
    {
        private int _moveValue;
        private int _jumpValue;
        

        public BallSpec(int moveValue, int jumpValue)
        {
            _moveValue = moveValue;
            _jumpValue = jumpValue;
          
        }

        
    }

   




}



    
    
    

