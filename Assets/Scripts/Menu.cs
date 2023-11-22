using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class Menu : MonoBehaviour
{
    public GameObject one;
    public GameObject two;
    public GameObject three;
    int RandomN;
    public int idPlayer;
    float index;
    public YandexGame sdk;
    // Start is called before the first frame update
    void Start()
    {
        YandexGame.CloseVideoEvent += Reward;
        InvokeRepeating("Restart", 0, 2.5f);
            
    }

    void Restart()
    {
        RandomN = Random.Range(1, 4);
        if (RandomN == 1)
        {
            one.SetActive(true);
            two.SetActive(false);
            three.SetActive(false);

        }
        if(RandomN == 2)
        {
            one.SetActive(false);
            two.SetActive(true);
            three.SetActive(false);
        }
        if(RandomN == 3)
        {
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToGame ()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void To2Game()
    {
        SceneManager.LoadScene("TwoPlayersScene");
    }



    void NormalKit()
    {
        if (idPlayer == 1)
        {
            index = PlayerPrefs.GetFloat("GameTree");
            PlayerPrefs.SetFloat("GameTree", index + 35);

            index = PlayerPrefs.GetFloat("GameStone");
            PlayerPrefs.SetFloat("GameStone", index + 30);

            index = PlayerPrefs.GetFloat("GameCloth");
            PlayerPrefs.SetFloat("GameCloth", index + 20);

        }
        if (idPlayer == 2)
        {
            index = PlayerPrefs.GetFloat("GameTree1");
            PlayerPrefs.SetFloat("GameTree1", index + 35);

            index = PlayerPrefs.GetFloat("GameStone1");
            PlayerPrefs.SetFloat("GameStone1", index + 30);

            index = PlayerPrefs.GetFloat("GameCloth1");
            PlayerPrefs.SetFloat("GameCloth1", index + 20);

        }

    }
    void IronKit()
    {
        if (idPlayer == 1)
        {
            index = PlayerPrefs.GetFloat("GameIron");
            PlayerPrefs.SetFloat("GameIron", index += 20);

            index = PlayerPrefs.GetFloat("GameStone");
            PlayerPrefs.SetFloat("GameStone", index += 5);

            index = PlayerPrefs.GetFloat("GameDiamond");
            PlayerPrefs.SetFloat("GameDiamond", index += 3);

        }
        if (idPlayer == 2)
        {
            index = PlayerPrefs.GetFloat("GameIron1");
            PlayerPrefs.SetFloat("GameIron1", index += 20);

            index = PlayerPrefs.GetFloat("GameStone1");
            PlayerPrefs.SetFloat("GameStone1", index + 5);

            index = PlayerPrefs.GetFloat("GameDiamond1");
            PlayerPrefs.SetFloat("GameDiamond1", index + 3);

        }

    }

    void DiamondKit()
    {
        if (idPlayer == 1)
        {
            index = PlayerPrefs.GetFloat("GameIron");
            PlayerPrefs.SetFloat("GameIron", index + 5);

            index = PlayerPrefs.GetFloat("GameStone");
            PlayerPrefs.SetFloat("GameStone", index + 0);

            index = PlayerPrefs.GetFloat("GameDiamond");
            PlayerPrefs.SetFloat("GameDiamond", index + 10);

        }
        if (idPlayer == 2)
        {
            index = PlayerPrefs.GetFloat("GameIron1");
            PlayerPrefs.SetFloat("GameIron1", index + 20);

            index = PlayerPrefs.GetFloat("GameStone1");
            PlayerPrefs.SetFloat("GameStone1", index + 5);

            index = PlayerPrefs.GetFloat("GameDiamond1");
            PlayerPrefs.SetFloat("GameDiamond1", index + 10);

        }

    }
    void BuildKit()
    {
        if (idPlayer == 1)
        {
            index = PlayerPrefs.GetFloat("GameTree");
            PlayerPrefs.SetFloat("GameTree", index += 100);

            

        }
        if (idPlayer == 2)
        {
            index = PlayerPrefs.GetFloat("GameTree1");
            PlayerPrefs.SetFloat("GameTree1", index += 100);

            

        }

    }

   

    public void SnowAD1(int id)
    {
        sdk._RewardedShow(id);
    }
    void Reward(int id)
    {
        if (id == 1) // Проверка награды по айди
        {
            NormalKit();
        }
            
        if (id == 4) // Проверка награды по айди
        {
            BuildKit();
        }
           
        if (id == 2) // Проверка награды по айди
        {
            IronKit();
        }
            
        if (id == 3) // Проверка награды по айди
        {
            DiamondKit();
        }
            
    }
}
