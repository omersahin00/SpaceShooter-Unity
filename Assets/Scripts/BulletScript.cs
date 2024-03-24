using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 60;
    private SpriteRenderer _spriteRenderer;
    public TeamType teamType;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = true;

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
        if (collision.gameObject.CompareTag("EnemyShip") && teamType == TeamType.Friendly)
        {
            EnemyShipScript enemyShipScript = collision.gameObject.GetComponent<EnemyShipScript>();
            enemyShipScript.ExplosiveYourSelf();
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("SpaceShip") && teamType == TeamType.Enemy)
        {
            // Can işlemleri
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("DeadLine"))
        {
            Destroy(gameObject);
        }
    }
}
