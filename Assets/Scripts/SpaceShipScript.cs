using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipScript : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 50;
    public GameObject _explosive;

    void Start()
    {
        
    }

    void Update()
    {
        HorizontalMove();
        VerticalMove();
    }


    private void HorizontalMove()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if ((horizontalInput > 0 && transform.position.x <= 30) || (horizontalInput <0 && transform.position.x >= -30))
        {
            transform.Translate(new Vector3(horizontalInput, 0f, 0f) * _moveSpeed * Time.deltaTime);
        }    
    }


    private void VerticalMove()
    {
        float verticalInput = Input.GetAxis("Vertical");

        if ((verticalInput > 0 && transform.position.y <= 70) || (verticalInput < 0 && transform.position.y >= -12))
        {
            transform.Translate(new Vector3(0f, 0f, verticalInput) * _moveSpeed * Time.deltaTime);
        }
    }


    public void ExplosiveYourSelf()
    {
        Instantiate(_explosive, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
