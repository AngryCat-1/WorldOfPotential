using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    
    public int playerIndex;
    [SerializeField] float speed;
    private Rigidbody2D rb;
    public GameObject AnotherPlayer;
    [SerializeField] Animator anim;
    [SerializeField] int directionIndex;
    public GameObject Hp1;
    public GameObject Hp2;
    public GameObject Hp3;
    public GameObject Hp4;
    public GameObject Hp5;
    public GameObject Energy1;
    public GameObject Energy2;
    public GameObject Energy3;
    public GameObject Energy4;
    public GameObject Energy5;
    public GameObject Energy6;
    public GameObject Energy7;
    public GameObject Energy8;
    public GameObject Energy9;
    public GameObject Energy10;
    public GameObject food1;
    public GameObject food2;
    public GameObject food3;
    public GameObject food4;
    public GameObject food5;
    public GameObject food6;
    public GameObject food7;
    public GameObject food8;
    public GameObject food9;
    public GameObject food10;
    public int hpCount;
    public float energyCount;
    public float hungry;
    public float temparure;
    public GameObject temparureobject;
    public float foodcount;
    public Text foodText;
    bool specialindex;
    public bool _IsAttack;
    public GameObject Canopy;
    public GameObject Carpet;
    public GameObject TreeFloor;
    public GameObject StoneFloor;
    public GameObject Hammock;
    public GameObject UpgradeCanopy;
    public GameObject Fence1;
    public GameObject Fence2;
    public GameObject Well;
    public GameObject House1;
    public GameObject Tower;
    public GameObject BonFire;
    public GameObject Tunnel;
    public GameObject Tunnel1;
    public GameObject Garden;
    public GameObject Bake;
    public GameObject Bed;
    public GameObject Chair;
    public GameObject CupBoard;
    public GameObject FlashLight;
    public GameObject NightStand;
    public GameObject Table;
    public GameObject Tron;
    public GameObject Aquriam;

    public GameObject AttackButton;

    public float tree;
    public float iron;
    public float cloth;
    public float diamond;
    public float stone;

    [SerializeField]   public Text treeT;
    [SerializeField] public Text ironT;
    [SerializeField] public Text clothT;
    [SerializeField] public Text diamondT;
    [SerializeField] public Text stoneT;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("EnergyDelete", 0, 0.4f);
        InvokeRepeating("EnergyNew", 0, 0.1f);
        InvokeRepeating("hungrydelete", 0, 1);
        
        InvokeRepeating("MinusTemperature", 0, 3);
        if (playerIndex == 1)
        {
            tree = PlayerPrefs.GetFloat("GameTree");
            iron = PlayerPrefs.GetFloat("GameIron");
            cloth = PlayerPrefs.GetFloat("GameCloth");
            diamond = PlayerPrefs.GetFloat("GameDiamond");
            stone = PlayerPrefs.GetFloat("GameStone");
        }
        if (playerIndex == 2)
        {
            tree = PlayerPrefs.GetFloat("GameTree1");
            iron = PlayerPrefs.GetFloat("GameIron1");
            cloth = PlayerPrefs.GetFloat("GameCloth1");
            diamond = PlayerPrefs.GetFloat("GameDiamond1");
            stone = PlayerPrefs.GetFloat("GameStone1");
        }
    }

    // Update is called once per frame


    public void ToMenu()
    {
        SceneManager.LoadScene("StartGame");
    }
    public void Tp()
    {
        
        
            transform.position = new Vector3(AnotherPlayer.transform.position.x,AnotherPlayer.transform.position.y, AnotherPlayer.transform.position.z);
        
        
    }
    private void Update()
    {
        if (tree < 0) { tree = 0; }
        if (tree < 0) { iron = 0; }
        if (tree < 0) { cloth = 0; }
        if (tree < 0) { diamond = 0; }
        if (tree < 0) { stone = 0; }

        if (playerIndex == 1)
        {
            PlayerPrefs.SetFloat("GameTree", tree);
            PlayerPrefs.GetFloat("GameIron", iron);
            PlayerPrefs.SetFloat("GameCloth", cloth);
            PlayerPrefs.SetFloat("GameDiamond", diamond);
            PlayerPrefs.SetFloat("GameStone", stone);
        }
        if (playerIndex == 2)
        {
            PlayerPrefs.SetFloat("GameTree1", tree);
            PlayerPrefs.GetFloat("GameIron1", iron);
            PlayerPrefs.SetFloat("GameCloth1", cloth);
            PlayerPrefs.SetFloat("GameDiamond1", diamond);
            PlayerPrefs.SetFloat("GameStone1", stone);
        }


        treeT.text = tree + "";
        ironT.text = iron + "";
        clothT.text = cloth + "";
        diamondT.text = diamond + "";
        stoneT.text = stone + "";
        foodText.text = foodcount + "";
        
        UIController();

        if (energyCount < 1)
        {
            speed = 12;
        }
        else
        {
            speed = 28;
        }
        if (hpCount < 0)
        {
            
                PlayerPrefs.DeleteAll();
            
            
        }
        if (playerIndex == 1)
        {
            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                specialindex = true;
                anim.Play("BackWalk");
                directionIndex = 1;
                rb.AddForce(new Vector3(0, speed / 4));

            }
            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D))
            {

                specialindex = false;
                directionIndex = 3;
                anim.Play("LeftWalk");
                rb.AddForce(new Vector3(- speed / 4, 0));
            }
            if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                
                specialindex = true;
                directionIndex = 2;
                anim.Play("FrontWalk");
                rb.AddForce(new Vector3(0, - speed / 4));
            }
            if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W))
            {
                specialindex = false;
                directionIndex = 4;
                anim.Play("RightWalk");
                rb.AddForce(new Vector3(speed / 4, 0));
            }

            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                if (directionIndex == 3)
                {
                    anim.Play("Left");
                    specialindex = false;
                }
                if (directionIndex == 1)
                {
                    anim.Play("Back");
                    specialindex = true;

                }
                if (directionIndex == 2)
                {
                    anim.Play("Front");
                    specialindex = true;
                }
                if (directionIndex == 4)
                {
                    anim.Play("Right");
                    specialindex = false;
                }
            }
        }

        if (playerIndex == 2)
        {
            if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            {
                specialindex = true;
                anim.Play("BackWalk");
                directionIndex = 1;
                rb.AddForce(new Vector3(0, speed / 4));

            }
            if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.RightArrow))
            {

                specialindex = false;
                directionIndex = 3;
                anim.Play("LeftWalk");
                rb.AddForce(new Vector3(- speed / 4, 0));
            }
            if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            {

                specialindex = true;
                directionIndex = 2;
                anim.Play("FrontWalk");
                rb.AddForce(new Vector3(0, - speed / 4));
            }
            if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow))
            {
                specialindex = false;
                directionIndex = 4;
                anim.Play("RightWalk");
                rb.AddForce(new Vector3(speed / 4, 0));
            }

            if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            {
                if (directionIndex == 3)
                {
                    anim.Play("Left");
                    specialindex = false;
                }
                if (directionIndex == 1)
                {
                    anim.Play("Back");
                    specialindex = true;

                }
                if (directionIndex == 2)
                {
                    anim.Play("Front");
                    specialindex = true;
                }
                if (directionIndex == 4)
                {
                    anim.Play("Right");
                    specialindex = false;
                }
            }
        }
    }

    void MinusTemperature()
    {
        temparure -= Random.Range(-0.5f, 0.4f);
    }
    void FixedUpdate()
    {
       if (temparure >= 60)
        {

        }
       if (hungry <= 1)
        {
            hpCount -= 1;
        }
        if (temparure <= -5)
        {
            hpCount -= 1;
        }




        if (hpCount == 1)
        {
            Hp5.GetComponent<Animator>().enabled = true;
            Hp5.GetComponent<Animator>().Play("DangerHP");
        }
        if (hpCount != 1)
        {
            Hp5.GetComponent<Animator>().enabled = false;
        }
       
       
        
            
        
        





    }


    void PlusHp()
    {
        if (foodcount >= 0)
        {
            hpCount += 1;
            foodcount -= 1;
        }
    }
    public void canopy()
    {
        if (tree >= 7 && cloth >= 5 )
        {
           
           Instantiate(Canopy, transform.position, Quaternion.identity);
            tree -= 7;
            cloth -= 5;
        }

    }
    public void upgradecanopy()
    {
        if (tree >= 11 && cloth >= 5 && stone >= 5)
        {

            Instantiate(UpgradeCanopy, transform.position, Quaternion.identity);
            tree -= 11;
            cloth -= 5;
            stone -= 5;
        }

    }
    public void carpet()
    {
        if (cloth >= 6)
        {
            Instantiate(Carpet, transform.position, Quaternion.identity);
            cloth -= 6;
        }
    }

    public void treefloor()
    {
        if (tree >= 6)
        {
            Instantiate(TreeFloor, transform.position, Quaternion.identity);
            tree -= 6;
        }
    }
    public void stonefloor()
    {
        if (stone >= 6)
        {
            Instantiate(StoneFloor, transform.position, Quaternion.identity);
            stone -= 6;
        }
    }
    public void hammock()
    {
        if (tree >= 6 && stone >= 2 && cloth >= 4)
        {
            Instantiate(Hammock, transform.position, Quaternion.identity);
            tree -= 6;
            stone -= 2;
            cloth -= 4;
        }
    }


    public void fence()
    {
        if (tree >= 8)
        {
            if (specialindex == true)
            {
                Instantiate(Fence2, transform.position, Quaternion.identity);
                tree -= 8;

            }
            if (specialindex == false)
            {
                Instantiate(Fence1, transform.position, Quaternion.identity);
                tree -= 8;
            }
        }
        
    }


    public void well()
    {
        if (tree >= 5 && iron >= 5 && stone >= 10)
        {
            Instantiate(Well, transform.position, Quaternion.identity);
            tree -= 5;
            iron -= 5;
            stone -= 10;

        }
    }


    public void house1()
    {
        if (tree >= 38 && iron >= 18 && cloth >= 4)
        {
            Instantiate(House1, transform.position, Quaternion.identity);
            tree -= 38;
            iron -= 18;
            cloth -= 4;
        }
    }
    public void tower()
    {
        if (stone >= 64 && iron >= 20)
        {
            Instantiate(Tower, transform.position, Quaternion.identity);
            stone -= 64;
            iron -= 25;
            
        }
    }

    public void bonfire()
    {
        if (tree >= 10 && cloth <= 1)
        {
            Instantiate(BonFire, transform.position, Quaternion.identity);
            tree -= 10;
            cloth -= 1;
        }
    }



    public void tunnel()
    {
        if (tree >= 4 && stone >= 10)
        {
            if (specialindex == true)
            {
                Instantiate(Tunnel, transform.position, Quaternion.identity);
                tree -= 4;
                stone -= 10;

            }
            if (specialindex == false)
            {
                Instantiate(Tunnel1, transform.position, Quaternion.identity);
                tree -= 4;
                stone -= 10;
            }
        }
    }


    public void aquaruim()
    {
        if (diamond >= 7)
        {
            Instantiate(Aquriam, transform.position, Quaternion.identity);
            diamond -= 7;
        }
    }
    public void bake()
    {
        if (tree >= 3 && stone >= 10)
        {
            Instantiate(Bake, transform.position, Quaternion.identity);
            tree -= 3;
            stone -= 10;
        }
    }
    public void chair()
    {
        if (tree >= 8)
        {
            Instantiate(Chair, transform.position, Quaternion.identity);
            tree -= 8;
            
        }
    }
    public void cupboard()
    {
        if (tree >= 10)
        {
            Instantiate(CupBoard, transform.position, Quaternion.identity);
            tree -= 10;

        }
    }
    public void flaslight()
    {
        if (diamond >= 2 && stone >= 7)
        {
            Instantiate(FlashLight, transform.position, Quaternion.identity);
            diamond -= 2;
            stone -= 7;

        }
    }
    public void nightstand()
    {
        if (tree >= 4)
        {
            Instantiate(NightStand, transform.position, Quaternion.identity);
            tree -= 4;
            

        }
    }
    public void table()
    {
        if (tree >= 4 && iron >= 2)
        {
            Instantiate(Table, transform.position, Quaternion.identity);
            tree -= 4;
            iron -= 2;


        }
    }
    public void bed()
    {
        if (tree >= 10 && cloth >= 10)
        {
            Instantiate(Bed, transform.position, Quaternion.identity);
            tree -= 10;
            cloth -= 10;
        }
    }
    public void garden()
    {
        if (tree >= 3 && cloth >= 2)
        {
            Instantiate(Garden, transform.position, Quaternion.identity);
            tree -= 3;
            cloth -= 2;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.tag == "Tree" && energyCount >= 3)
            {
                energyCount -= 3;
                Destroy(collision.gameObject);
                print("tree");
                tree += Random.Range(1, 3);
                if (Random.Range(0, 101) <= 33)
                {
                    cloth += 1;
                }
                if (Random.Range(0, 101) <= 90)
                {
                    foodcount += 2;
                }
            }
            if (collision.tag == "Stone" && energyCount >= 5)
            {
                energyCount -= 5;
                Destroy(collision.gameObject);
                stone += Random.Range(2, 3);
                if (Random.Range(0, 101) <= 10)
                {
                    diamond += 1;
                }
                if (Random.Range(0, 101) <= 20)
                {
                    iron += Random.Range(1, 2);
                }

            }



        }

        if (collision.tag == "bonfire")
        {
            temparure += 10;
        }

        if (collision.tag == "Animal")
        {
            AttackButton.SetActive(true);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bonfire")
        {
            temparure -= 10;
            print("bonfireexit");
        }
        if (collision.gameObject.tag == "Animal")
        {
            AttackButton.SetActive(false);
        }
    }

    void EnergyDelete()
    {
        if (rb.velocity.magnitude >= 0.2f && energyCount >= 0)
        {
            energyCount -= 0.2f;
            UIController();
        }
    }

    void EnergyNew()
    {
        if (rb.velocity.magnitude <= 0.1f)
        {
            if (energyCount < 10.2f && hungry >= 3)
            {
                energyCount += 0.1f;
                UIController();
            }
        }
          
        
    }

    void hungrydelete()
    {
        hungry -= 0.001f;
    }

    public void addhungry()
    {
        if (foodcount >= 1 && hungry < 9)
        {
            hungry += 1;
            foodcount -= 1;
        }
        
    }

    public void Attack()
    {
        _IsAttack = true;
    }
    void UIController()
    {
        if (hpCount == 5)
        {
            Hp1.gameObject.SetActive(true);
            Hp2.gameObject.SetActive(true);
            Hp3.gameObject.SetActive(true);
            Hp4.gameObject.SetActive(true);
            Hp5.gameObject.SetActive(true);
        }
        if (hpCount == 4)
        {
            Hp1.gameObject.SetActive(false);
            Hp2.gameObject.SetActive(true);
            Hp3.gameObject.SetActive(true);
            Hp4.gameObject.SetActive(true);
            Hp5.gameObject.SetActive(true);
        }
        if (hpCount == 3)
        {
            Hp1.gameObject.SetActive(false);
            Hp2.gameObject.SetActive(false);
            Hp3.gameObject.SetActive(true);
            Hp4.gameObject.SetActive(true);
            Hp5.gameObject.SetActive(true);
        }
        if (hpCount == 2)
        {
            Hp1.gameObject.SetActive(false);
            Hp2.gameObject.SetActive(false);
            Hp3.gameObject.SetActive(false);
            Hp4.gameObject.SetActive(true);
            Hp5.gameObject.SetActive(true);
        }
        if (hpCount == 1)
        {
            Hp1.gameObject.SetActive(false);
            Hp2.gameObject.SetActive(false);
            Hp3.gameObject.SetActive(false);
            Hp4.gameObject.SetActive(false);
            Hp5.gameObject.SetActive(true);
        }


        if (energyCount >= 10)
        {
            Energy1.gameObject.SetActive(true);
            Energy2.gameObject.SetActive(true);
            Energy3.gameObject.SetActive(true);
            Energy4.gameObject.SetActive(true);
            Energy5.gameObject.SetActive(true);
            Energy6.gameObject.SetActive(true);
            Energy7.gameObject.SetActive(true);
            Energy8.gameObject.SetActive(true);
            Energy9.gameObject.SetActive(true);
            Energy10.gameObject.SetActive(true);
            

        }

        if (energyCount >= 9 && energyCount < 10) 
        {
            Energy1.gameObject.SetActive(false);
            Energy2.gameObject.SetActive(true);
            Energy3.gameObject.SetActive(true);
            Energy4.gameObject.SetActive(true);
            Energy5.gameObject.SetActive(true);
            Energy6.gameObject.SetActive(true);
            Energy7.gameObject.SetActive(true);
            Energy8.gameObject.SetActive(true);
            Energy9.gameObject.SetActive(true);
            Energy10.gameObject.SetActive(true);


        }
        if (energyCount >= 8 && energyCount < 9) 
        {
            Energy1.gameObject.SetActive(false);
            Energy2.gameObject.SetActive(false);
            Energy3.gameObject.SetActive(true);
            Energy4.gameObject.SetActive(true);
            Energy5.gameObject.SetActive(true);
            Energy6.gameObject.SetActive(true);
            Energy7.gameObject.SetActive(true);
            Energy8.gameObject.SetActive(true);
            Energy9.gameObject.SetActive(true);
            Energy10.gameObject.SetActive(true);


        }
        if (energyCount >= 7 && energyCount < 8)
        {
            Energy1.gameObject.SetActive(false);
            Energy2.gameObject.SetActive(false);
            Energy3.gameObject.SetActive(false);
            Energy4.gameObject.SetActive(true);
            Energy5.gameObject.SetActive(true);
            Energy6.gameObject.SetActive(true);
            Energy7.gameObject.SetActive(true);
            Energy8.gameObject.SetActive(true);
            Energy9.gameObject.SetActive(true);
            Energy10.gameObject.SetActive(true);


        }
        if (energyCount >= 6 && energyCount < 7)
        {
            Energy1.gameObject.SetActive(false);
            Energy2.gameObject.SetActive(false);
            Energy3.gameObject.SetActive(false);
            Energy4.gameObject.SetActive(false);
            Energy5.gameObject.SetActive(true);
            Energy6.gameObject.SetActive(true);
            Energy7.gameObject.SetActive(true);
            Energy8.gameObject.SetActive(true);
            Energy9.gameObject.SetActive(true);
            Energy10.gameObject.SetActive(true);


        }
        if (energyCount >= 5  && energyCount < 6)
        {
            Energy1.gameObject.SetActive(false);
            Energy2.gameObject.SetActive(false);
            Energy3.gameObject.SetActive(false);
            Energy4.gameObject.SetActive(false);
            Energy5.gameObject.SetActive(false);
            Energy6.gameObject.SetActive(true);
            Energy7.gameObject.SetActive(true);
            Energy8.gameObject.SetActive(true);
            Energy9.gameObject.SetActive(true);
            Energy10.gameObject.SetActive(true);


        }
        if (energyCount >= 4 && energyCount < 5)
        {
            Energy1.gameObject.SetActive(false);
            Energy2.gameObject.SetActive(false);
            Energy3.gameObject.SetActive(false);
            Energy4.gameObject.SetActive(false);
            Energy5.gameObject.SetActive(false);
            Energy6.gameObject.SetActive(false);
            Energy7.gameObject.SetActive(true);
            Energy8.gameObject.SetActive(true);
            Energy9.gameObject.SetActive(true);
            Energy10.gameObject.SetActive(true);


        }
        if (energyCount >= 3 && energyCount < 4)
        {
            Energy1.gameObject.SetActive(false);
            Energy2.gameObject.SetActive(false);
            Energy3.gameObject.SetActive(false);
            Energy4.gameObject.SetActive(false);
            Energy5.gameObject.SetActive(false);
            Energy6.gameObject.SetActive(false);
            Energy7.gameObject.SetActive(false);
            Energy8.gameObject.SetActive(true);
            Energy9.gameObject.SetActive(true);
            Energy10.gameObject.SetActive(true);


        }
        if (energyCount >= 2 && energyCount < 3)
        {
            Energy1.gameObject.SetActive(false);
            Energy2.gameObject.SetActive(false);
            Energy3.gameObject.SetActive(false);
            Energy4.gameObject.SetActive(false);
            Energy5.gameObject.SetActive(false);
            Energy6.gameObject.SetActive(false);
            Energy7.gameObject.SetActive(false);
            Energy8.gameObject.SetActive(false);
            Energy9.gameObject.SetActive(true);
            Energy10.gameObject.SetActive(true);


        }

        if (energyCount < 2)
        {
            Energy1.gameObject.SetActive(false);
            Energy2.gameObject.SetActive(false);
            Energy3.gameObject.SetActive(false);
            Energy4.gameObject.SetActive(false);
            Energy5.gameObject.SetActive(false);
            Energy6.gameObject.SetActive(false);
            Energy7.gameObject.SetActive(false);
            Energy8.gameObject.SetActive(false);
            Energy9.gameObject.SetActive(false);
            Energy10.gameObject.SetActive(true);


        }

        if (hungry >= 9)
        {
            food1.gameObject.SetActive(true);
            food2.gameObject.SetActive(true);
            food3.gameObject.SetActive(true);
            food4.gameObject.SetActive(true);
            food5.gameObject.SetActive(true);
            food6.gameObject.SetActive(true);
            food7.gameObject.SetActive(true);
            food8.gameObject.SetActive(true);
            food9.gameObject.SetActive(true);
            food10.gameObject.SetActive(true);


        }
        if (hungry >= 8 && hungry <= 9)
        {
            food1.gameObject.SetActive(false);
            food2.gameObject.SetActive(true);
            food3.gameObject.SetActive(true);
            food4.gameObject.SetActive(true);
            food5.gameObject.SetActive(true);
            food6.gameObject.SetActive(true);
            food7.gameObject.SetActive(true);
            food8.gameObject.SetActive(true);
            food9.gameObject.SetActive(true);
            food10.gameObject.SetActive(true);


        }
        if (hungry >= 7 && hungry <= 8)
        {
            food1.gameObject.SetActive(false);
            food2.gameObject.SetActive(false);
            food3.gameObject.SetActive(true);
            food4.gameObject.SetActive(true);
            food5.gameObject.SetActive(true);
            food6.gameObject.SetActive(true);
            food7.gameObject.SetActive(true);
            food8.gameObject.SetActive(true);
            food9.gameObject.SetActive(true);
            food10.gameObject.SetActive(true);


        }
        if (hungry >= 6 && hungry <= 7)
        {
            food1.gameObject.SetActive(false);
            food2.gameObject.SetActive(false);
            food3.gameObject.SetActive(false);
            food4.gameObject.SetActive(true);
            food5.gameObject.SetActive(true);
            food6.gameObject.SetActive(true);
            food7.gameObject.SetActive(true);
            food8.gameObject.SetActive(true);
            food9.gameObject.SetActive(true);
            food10.gameObject.SetActive(true);


        }
        if (hungry >= 5 && hungry <= 6)
        {
            food1.gameObject.SetActive(false);
            food2.gameObject.SetActive(false);
            food3.gameObject.SetActive(false);
            food4.gameObject.SetActive(false);
            food5.gameObject.SetActive(true);
            food6.gameObject.SetActive(true);
            food7.gameObject.SetActive(true);
            food8.gameObject.SetActive(true);
            food9.gameObject.SetActive(true);
            food10.gameObject.SetActive(true);


        }
        if (hungry >= 4 && hungry <= 5)
        {
            food1.gameObject.SetActive(false);
            food2.gameObject.SetActive(false);
            food3.gameObject.SetActive(false);
            food4.gameObject.SetActive(false);
            food5.gameObject.SetActive(false);
            food6.gameObject.SetActive(true);
            food7.gameObject.SetActive(true);
            food8.gameObject.SetActive(true);
            food9.gameObject.SetActive(true);
            food10.gameObject.SetActive(true);


        }
        if (hungry >= 3 && hungry <= 4)
        {
            food1.gameObject.SetActive(false);
            food2.gameObject.SetActive(false);
            food3.gameObject.SetActive(false);
            food4.gameObject.SetActive(false);
            food5.gameObject.SetActive(false);
            food6.gameObject.SetActive(false);
            food7.gameObject.SetActive(true);
            food8.gameObject.SetActive(true);
            food9.gameObject.SetActive(true);
            food10.gameObject.SetActive(true);


        }
        if (hungry >= 2 && hungry <= 3)
        {
            food1.gameObject.SetActive(false);
            food2.gameObject.SetActive(false);
            food3.gameObject.SetActive(false);
            food4.gameObject.SetActive(false);
            food5.gameObject.SetActive(false);
            food6.gameObject.SetActive(false);
            food7.gameObject.SetActive(false);
            food8.gameObject.SetActive(true);
            food9.gameObject.SetActive(true);
            food10.gameObject.SetActive(true);


        }
        if (hungry >= 1 && hungry <= 2)
        {
            food1.gameObject.SetActive(false);
            food2.gameObject.SetActive(false);
            food3.gameObject.SetActive(false);
            food4.gameObject.SetActive(false);
            food5.gameObject.SetActive(false);
            food6.gameObject.SetActive(false);
            food7.gameObject.SetActive(false);
            food8.gameObject.SetActive(false);
            food9.gameObject.SetActive(true);
            food10.gameObject.SetActive(true);


        }
        if (hungry <= 1)
        {
            food1.gameObject.SetActive(false);
            food2.gameObject.SetActive(false);
            food3.gameObject.SetActive(false);
            food4.gameObject.SetActive(false);
            food5.gameObject.SetActive(false);
            food6.gameObject.SetActive(false);
            food7.gameObject.SetActive(false);
            food8.gameObject.SetActive(false);
            food9.gameObject.SetActive(false);
            food10.gameObject.SetActive(true);


        }


        if (temparure < 10)
        {
            temparureobject.GetComponent<Animator>().Play("1");

        }
        if (temparure >= 10 && temparure < 16)
        {
            temparureobject.GetComponent<Animator>().Play("2");
        }
        if (temparure > 16 && temparure < 25)
        {
            temparureobject.GetComponent<Animator>().Play("3");
        }
        if (temparure >= 25 && temparure < 30)
        {
            temparureobject.GetComponent<Animator>().Play("4");
        }
        if (temparure >= 30 && temparure < 40)
        {
            temparureobject.GetComponent<Animator>().Play("5");
        }
        if (temparure >= 40)
        {
            temparureobject.GetComponent<Animator>().Play("6");
        }


    }


}    