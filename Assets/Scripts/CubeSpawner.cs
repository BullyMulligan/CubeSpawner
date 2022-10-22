using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))//если зажата клавиша "пробел"
        {
            var newCube = Instantiate(_cube);//спавним новый куб
            newCube.transform.position =new Vector3( Random.Range(-15,15),30,10);//задаем место спавна кубиков по прямой от -15 до 15 по X и в пределах 30 по Y, 10 по Z
        }
    }
}
