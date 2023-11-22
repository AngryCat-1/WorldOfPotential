using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden : MonoBehaviour
{
    bool Grow = false;
    public GameObject FoodGarden;
    public PlayerMove PlayerMove;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("growfunction", 0, 90);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void growfunction()
    {
        Grow = true;
        FoodGarden.SetActive(true);
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FoodGarden.SetActive(false);
            Grow = false;
            PlayerMove.foodcount += 2;

        }
    }


}
