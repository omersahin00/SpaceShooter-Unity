using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipScript : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10;
    public GameObject _explosive;
    private HeartScript heartScript;
    private ScoreScript scoreScript;

    private bool hasCollided = false;


    void Start()
    {
        heartScript = FindAnyObjectByType<HeartScript>();
        scoreScript = FindAnyObjectByType<ScoreScript>();
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
        if (!hasCollided)
        {
            if (collision.gameObject.CompareTag("DeadLine"))
            {
                hasCollided = true;
                scoreScript.DecreaseScore(10);
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("SpaceShip"))
            {
                hasCollided = true;
                heartScript.DecreaseHeart(1f);
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
