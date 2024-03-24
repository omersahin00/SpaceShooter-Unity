using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipCreator : MonoBehaviour
{
    public GameObject Ship1;
    public GameObject Ship2;
    public GameObject Ship3;
    public GameObject Ship4;

    private List<GameObject> shipList;
    private Timer timer;

    void Start()
    {
        shipList = new List<GameObject> { Ship1, Ship2, Ship3, Ship4 };
        timer = GetComponent<Timer>();
    }

    void Update()
    {
        timer.StartTimer(2f, RandomShipCreator);
    }


    public void RandomShipCreator()
    {
        int shipIndex = Random.Range(0, 4);
        float shipPosition = Random.value * 30;

        int boolean = Random.Range(0, 2);
        if (boolean == 0) shipPosition *= -1;

        GameObject ship = Instantiate(shipList[shipIndex], new Vector3(shipPosition, 90f, 7f), Quaternion.identity);
        ship.transform.rotation = Quaternion.Euler(90f, 180f, 0f);
    }
}
