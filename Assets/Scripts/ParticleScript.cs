using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    private Timer timer;

    void Start()
    {
        timer = GetComponent<Timer>();
        timer.StartTimer(4f, DestroyYourSelf);
    }

    public void DestroyYourSelf()
    {
        Destroy(gameObject);
    }
}
