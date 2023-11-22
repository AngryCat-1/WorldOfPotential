using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    public int RandomVector;
    bool _IsColision;
    public Rigidbody2D rb2D;
    public Animator anim;
     public PlayerMove PlayerMove;
    // Start is called before the first frame update

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        InvokeRepeating("RandomVectorMove", 0, 5);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RandomVectorMove()
    {
        
        RandomVector = Random.Range(1, 6);
        if (RandomVector == 1)
        {
            anim.Play("Back");
            rb2D.velocity = new Vector2(0, 0);
            rb2D.velocity = new Vector2(0, 0);
            rb2D.velocity = new Vector2(0, -0.1f);

        }
        if (RandomVector == 2)
        {
            anim.Play("Forward");
            rb2D.velocity = new Vector2(0, 0);
            rb2D.velocity = new Vector2(0, 0);
            rb2D.velocity = new Vector2(0, 0.1f);

        }
        if (RandomVector == 3)
        {
            anim.Play("Left");
            rb2D.velocity = new Vector2(0, 0);
            rb2D.velocity = new Vector2(0, 0);
            rb2D.velocity = new Vector2(-0.1f, 0);

        }
        if (RandomVector == 4)
        {
            anim.Play("Right");
            rb2D.velocity = new Vector2(0, 0);
            rb2D.velocity = new Vector2(0, 0);
            rb2D.velocity = new Vector2(0.1f, 0);
        }
        if (RandomVector == 5)
        {
            rb2D.velocity = new Vector2(0, 0);
            rb2D.velocity = new Vector2(0, 0);

        }
        if (RandomVector == 6)
        {
            rb2D.velocity = new Vector2(0, 0);
            rb2D.velocity = new Vector2(0, 0);

        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            if (PlayerMove._IsAttack == true)
            {
                PlayerMove.foodcount += Random.Range(6, 10);
                PlayerMove._IsAttack = false;
                Destroy(this.gameObject);
            }

        }

    }
    
}
