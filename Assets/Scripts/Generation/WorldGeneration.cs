using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    [SerializeField] GameObject _forest;
    [SerializeField] GameObject _tree1;
    [SerializeField] GameObject _tree2;
    [SerializeField] GameObject _SaveGameObject;
    [SerializeField] GameObject _Water;
    [SerializeField] GameObject _Stone;
    [SerializeField] GameObject _Sheep;
    [SerializeField] GameObject _Monster;
    [SerializeField] GameObject _StoneMassive;
    [SerializeField] float _xMax;
    [SerializeField] float _yMax;
    int index_forest;
    int index_Tree;
    int index_saveobject;
    int index_stone;
    int index_stonemassive;
    int index_Sheep;

    void Spawn()
    {
        index_Sheep = Random.Range(20, 85);
        _spawn8();
        index_Tree = Random.Range(20, 250);
        index_stonemassive = Random.Range(1, 6);
        index_stone = Random.Range(50, 300);
        _spawn4();
        _spawn5();
        _spawn6();
        _spawn7();
        index_forest = Random.Range(1, 2);
        index_saveobject = Random.Range(2, 5);

        _yMax = 20;
        _xMax = 20;
        if (index_forest == 1)
        {
            _spawn1();
        }
        if (index_forest == 2)
        {
            _spawn1();
            _spawn1();
        }

        if (index_saveobject == 1)
        {
            _spawn2();
        }
        if (index_saveobject == 2)
        {
            _spawn2();
            _spawn2();
        }
        if (index_saveobject == 3)
        {
            _spawn2();
            _spawn2();
            _spawn2();
        }
        if (index_saveobject == 4)
        {
            _spawn2();
            _spawn2();
            _spawn2();
            _spawn2();
        }
        if (index_saveobject == 5)
        {
            _spawn2();
            _spawn2();
            _spawn2();
            _spawn2();
            _spawn2();
        }



    }
    private void Start()
    {
        InvokeRepeating("Spawn", 0, 2400);
        InvokeRepeating("MonsterSpawn", 0, 20);


    }
    private void Update()
    {


        
       
    }

    void MonsterSpawn()
    {
        GameObject obj = Instantiate(_Monster);
        float x = Random.Range(-20, 36);
        float y = Random.Range(-35, 6);
        _Monster.transform.position = new Vector3(x, y, -1);
    }
    public void _spawn1()
    {


        GameObject obj = Instantiate(_forest);
        float x = Random.Range(-20, 36);
        float y = Random.Range(-35, 6);
        _forest.transform.position = new Vector3(x, y, -1);
    }
    public void _spawn2()
    {


        GameObject obj = Instantiate(_SaveGameObject);
        float x = Random.Range(-20, 36);
        float y = Random.Range(-35, 6); 
        _SaveGameObject.transform.position = new Vector3(x, y, -1);
    }
    public void _spawn3()
    {


        GameObject obj = Instantiate(_Water);
        float x = Random.Range(-20, 36);
        float y = Random.Range(-35, 6);
        _SaveGameObject.transform.position = new Vector3(x, y, -1);
    }

    public void _spawn4()
    {

        for (int i = 0; i < index_stone; i++)
        {
            GameObject obj = Instantiate(_Stone);
            float x = Random.Range(-20, 36);
            float y = Random.Range(-35, 6);
            _Stone.transform.position = new Vector3(x, y, -1);
        }
        
    }

    public void _spawn5()
    {

        for (int i = 0; i < index_stonemassive; i++)
        {
            GameObject obj = Instantiate(_StoneMassive);
            float x = Random.Range(-20, 36);
            float y = Random.Range(-35, 6);
            _StoneMassive.transform.position = new Vector3(x, y, -1);
        }

    }

    public void _spawn6()
    {

        for (int i = 0; i < index_Tree / 2; i++)
        {
            GameObject obj = Instantiate(_tree1);
            float x = Random.Range(-20, 36);
            float y = Random.Range(-35, 6);
            _tree1.transform.position = new Vector3(x, y, -1);
        }
        

    }
    public void _spawn8()
    {

        
        for (int i = 0; i < index_Sheep; i++)
        {
            GameObject obj = Instantiate(_Sheep);
            float x = Random.Range(-20, 36);
            float y = Random.Range(-35, 6);
            _Sheep.transform.position = new Vector3(x, y, -1);
        }

    }

    public void _spawn7()
    {

        for (int i = 0; i < index_Tree / 2; i++)
        {
            GameObject obj = Instantiate(_tree2);
            float x = Random.Range(-20, 36);
            float y = Random.Range(-35, 6);
            _tree2.transform.position = new Vector3(x, y, -1);
        }

    }
}
