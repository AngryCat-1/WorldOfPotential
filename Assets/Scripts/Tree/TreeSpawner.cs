using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField] GameObject _objectToSpawn1;
    [SerializeField] GameObject _objectToSpawn2;
    [SerializeField] GameObject _objectToSpawn3;
    [SerializeField] GameObject _objectToSpawn4;
    [SerializeField] GameObject _objectToSpawn5;
    [SerializeField] float _xMax;
    [SerializeField] float _yMax;
    float needObject;
    [SerializeField] int _countOfObjects;
    
    int index;

    private void Start()
    {
        needObject = Random.Range(30, 300);
        _yMax = Random.Range(7, 20);
        _xMax = Random.Range(7, 20);
        needObject = _yMax * _xMax * Random.Range(2.1f, 4.4f);
    }
    private void Update()
    {
       

        if (_countOfObjects <= needObject)
        {
            index = Random.Range(1, 5);
            _countOfObjects += 1;
            if (index == 1)
            {
                _spawn1();
            }
            if (index == 2)
            {
                _spawn2();
            }
            if (index == 3)
            {
                _spawn3();
            }
            if (index == 4)
            {
                _spawn4();
            }
            if (index == 5)
            {
                _spawn5();
            }

            

        }
    }
    public void _spawn1()
    {
        

        GameObject obj = Instantiate(_objectToSpawn1);
        float x = Random.Range(transform.position.x - _xMax, transform.position.x + _xMax);
        float y = Random.Range(transform.position.y - _yMax, transform.position.y + _yMax);
        obj.transform.position = new Vector2(x, y);
    }

    public void _spawn2()
    {


        GameObject obj = Instantiate(_objectToSpawn2);
        float x = Random.Range(transform.position.x - _xMax, transform.position.x + _xMax);
        float y = Random.Range(transform.position.y - _yMax, transform.position.y + _yMax);
        obj.transform.position = new Vector2(x, y);
    }
    public void _spawn3()
    {


        GameObject obj = Instantiate(_objectToSpawn3);
        float x = Random.Range(transform.position.x - _xMax, transform.position.x + _xMax);
        float y = Random.Range(transform.position.y - _yMax, transform.position.y + _yMax);
        obj.transform.position = new Vector2(x, y);
    }
    public void _spawn4()
    {


        GameObject obj = Instantiate(_objectToSpawn4);
        float x = Random.Range(transform.position.x - _xMax, transform.position.x + _xMax);
        float y = Random.Range(transform.position.y - _yMax, transform.position.y + _yMax);
        obj.transform.position = new Vector2(x, y);
    }
    public void _spawn5()
    {


        GameObject obj = Instantiate(_objectToSpawn5);
        float x = Random.Range(transform.position.x - _xMax, transform.position.x + _xMax);
        float y = Random.Range(transform.position.y - _yMax, transform.position.y + _yMax);
        obj.transform.position = new Vector2(x, y);
    }
}