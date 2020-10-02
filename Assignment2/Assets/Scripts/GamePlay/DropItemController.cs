using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DropItemController : MonoBehaviour , IReset
{
    [SerializeField] DropItemModel behaviour;
    private Rigidbody _rigidbody;
    

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        behaviour=new ScoreObject();
    }


    private void OnCollisionEnter(Collision collision)
    {
        
            if (collision.gameObject.GetComponent<SpriteRenderer>().color == this.gameObject.GetComponent<SpriteRenderer>().color)
            {
                ObjectPooler.Instance.PoolDestroy(behaviour.dropType , this.gameObject);
            }

            
    }

    public void Reset()
    {
        
    }
}

[System.Serializable]
class DropItemModel1
{
    public PoolObjectType dropType;
    public int score;
}

