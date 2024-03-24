using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 60;
    private SpriteRenderer _spriteRenderer;

    private ScoreScript _scoreScript;
    private HeartScript _heartScript;

    public TeamType teamType;
    private bool hasCollided = false;


    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = true;

        _scoreScript = FindAnyObjectByType<ScoreScript>();

        _heartScript = FindAnyObjectByType<HeartScript>();


        if (teamType == TeamType.Friendly)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (teamType == TeamType.Enemy)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else Destroy(gameObject);
        
        transform.position = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
    }

    void Update()
    {
        VerticalMove();
    }


    private void VerticalMove()
    {
        transform.Translate(new Vector3(1f, 0f, 0f) * _moveSpeed * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!hasCollided)
        {
            if (collision.gameObject.CompareTag("EnemyShip") && teamType == TeamType.Friendly)
            {
                hasCollided = true;
                _scoreScript.IncreaseScore(20);
                EnemyShipScript enemyShipScript = collision.gameObject.GetComponent<EnemyShipScript>();
                enemyShipScript.ExplosiveYourSelf();
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("Rock") && teamType == TeamType.Friendly)
            {
                hasCollided = true;
                _scoreScript.IncreaseScore(10);
                RockScript rockScript = collision.gameObject.GetComponent<RockScript>();
                rockScript.ExplosiveYourSelf();
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("SpaceShip") && teamType == TeamType.Enemy)
            {
                hasCollided = true;
                _heartScript.DecreaseHeart(0.5f);
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("DeadLine"))
            {
                hasCollided = true;
                Destroy(gameObject);
            }
        }
    }
}
