using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    public float spawnDelay = 2f;
    public float attackDelay = 0.5f;

    private Timer timer;
    private bool canRun = true;


    void Start()
    {
        timer = GetComponent<Timer>();
    }


    void Update()
    {
        if (canRun)
            timer.StartTimer(5f, SlowDown);
    }


    public void SlowDown()
    {
        if (spawnDelay >= 0.1f)
            spawnDelay -= Random.Range(0.02f, 0.08f);

        if (attackDelay >= 0.1f)
            attackDelay -= Random.Range(0.009f, 0.017f);

        if (spawnDelay <= 0.1f && attackDelay <= 0.1f)
            canRun = false;
    }
}
