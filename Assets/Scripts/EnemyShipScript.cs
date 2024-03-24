using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipScript : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10;
    public GameObject _explosive;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DeadLine"))
        {
            Destroy(gameObject);
        }
    }

    public void ExplosiveYourSelf()
    {
        Instantiate(_explosive, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
