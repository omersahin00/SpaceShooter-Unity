using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    public GameObject Ship1;
    public GameObject Ship2;
    public GameObject Ship3;
    public GameObject Ship4;

    public GameObject Rock1;
    public GameObject Rock2;
    public GameObject Rock3;
    public GameObject Rock4;
    public GameObject Rock5;
    public GameObject Rock6;


    private List<GameObject> shipList;
    private List<GameObject> rockList;

    private Timer timer;
    private GameSpeed gameSpeed;


    void Start()
    {
        shipList = new List<GameObject> { Ship1, Ship2, Ship3, Ship4 };
        rockList = new List<GameObject> { Rock1, Rock2, Rock3, Rock4, Rock5, Rock6 };

        timer = GetComponent<Timer>();
        gameSpeed = FindAnyObjectByType<GameSpeed>();
    }


    void Update()
    {
        int turnIndex = GetRandomTurn();
        float delay = gameSpeed.spawnDelay;

        if (turnIndex == 1)
            timer.StartTimer(delay, RandomShipCreator);

        else if (turnIndex == 2)
            timer.StartTimer(delay, RandomRockCreator);
    }


    private int GetRandomTurn()
    {
        return Random.Range(1, 3);
    }


    public void RandomRockCreator()
    {
        int rockIndex = Random.Range(0, 6);
        float rockPosition = Random.value * 30;

        int boolean = Random.Range(0, 2);
        if (boolean == 0) rockPosition *= -1;

        Instantiate(rockList[rockIndex], new Vector3(rockPosition, 90f, 7f), Quaternion.identity);
    }


    public void RandomShipCreator()
    {
        int shipIndex = Random.Range(0, 4);
        float shipPosition = Random.value * 30;

        int boolean = Random.Range(0, 2);
        if (boolean == 0) shipPosition *= -1;

        GameObject ship = Instantiate(shipList[shipIndex], new Vector3(shipPosition, 85f, 7f), Quaternion.identity);
        ship.transform.rotation = Quaternion.Euler(90f, 180f, 0f);
    }
}
