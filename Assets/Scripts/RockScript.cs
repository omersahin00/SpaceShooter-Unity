using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    Rigidbody rb;
    public GameObject _explosive;

    float randomRotateX;
    float randomRotateY;
    float randomRotateZ;

    float rotateSpeed;
    float drag;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

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
