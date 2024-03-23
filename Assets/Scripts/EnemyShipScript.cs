using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipScript : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10;

    void Start()
    {
        
    }

    void Update()
    {
        VerticalMove();
    }


    private void VerticalMove()
    {
        transform.Translate(new Vector3(0f, 0f, 1f) * _moveSpeed * Time.deltaTime);
    }
}
