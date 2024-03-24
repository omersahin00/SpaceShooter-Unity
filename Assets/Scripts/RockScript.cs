using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    Rigidbody rb;
    public GameObject _explosive;
    private HeartScript _heartScript;

    float randomRotateX;
    float randomRotateY;
    float randomRotateZ;

    float rotateSpeed;
    float drag;

    private bool hasCollided = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _heartScript = FindAnyObjectByType<HeartScript>();

        randomRotateX = Random.Range(0f, 360f);
        randomRotateY = Random.Range(0f, 360f);
        randomRotateZ = Random.Range(0f, 360f);

        rotateSpeed = Random.Range(0.1f, 1f);

        drag = Random.value;
        rb.drag = drag;
    }


    void Update()
    {
        // Dönme Hareketi:
        transform.Rotate(new Vector3(randomRotateX, randomRotateY, randomRotateZ) * rotateSpeed * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!hasCollided)
        {
            if (collision.gameObject.CompareTag("DeadLine"))
            {
                hasCollided = true;
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("SpaceShip"))
            {
                hasCollided = true;
                _heartScript.DecreaseHeart(1f);
                ExplosiveYourSelf();
            }
        }
    }


    public void ExplosiveYourSelf()
    {
        Instantiate(_explosive, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
