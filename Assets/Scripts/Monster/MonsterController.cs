using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public bool _IsTriggerPlayer;
    public GameObject Monster;
    public PlayerMove PlayerMove;
    int timer;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMove = FindObjectOfType<PlayerMove>();
        InvokeRepeating("MinusHp", 0, 0.6f);
        InvokeRepeating("Spawn", 5, 13);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        print("ColissionMonster_OnTriggerEnter");
        if (collision.tag == "Buildings")
        {
            print("ColissionMonster_building");
            Destroy(collision.gameObject);
                    }
        if (collision.tag == "Tree")
        {
            print("ColissionMonster_tree");
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Animal")
        {
            print("ColissionMonster_animal");
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        print("ColissionMonster_OnTriggerStay");

        if (collider.tag == "Player")
        {
            print("start KILL MONSTER ");
            if (PlayerMove._IsAttack == true)
            {
                print("KILL MONSTER ");
                Destroy(gameObject);
                PlayerMove._IsAttack = false;
            }
            
        }
    }

    void MinusHp()
    {
        {
            if (_IsTriggerPlayer)
            {
                PlayerMove.hpCount -= 1;
            }
            
        }
    }


    void Spawn()
    {
        Instantiate(Monster);
        Monster.transform.position = new Vector2(this.transform.position.x + Random.Range(-2, 3), this.transform.position.y + Random.Range(-2, 3));
    }
}
