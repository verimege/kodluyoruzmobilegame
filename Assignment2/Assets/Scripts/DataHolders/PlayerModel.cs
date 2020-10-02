
using UnityEngine;

public class PlayerModel
{
   
    private int _score;

    public PlayerModel(int maxScore)
    {
        
    }
    

    public int GetScore()
    {
        return _score;
    }

    public void ChangeScore(int score)
    {
        _score += score;
    }
}
