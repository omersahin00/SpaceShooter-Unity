using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [SerializeField] private float _attackDelay = 1f;

    public GameObject _bulletPrefab;
    private Timer timer;
    private bool _canAttack = true;

    void Start()
    {
        timer = GetComponent<Timer>();
    }

    void Update()
    {
        Attack();
    }


    private void Attack()
    {
        float attackInput = Input.GetAxisRaw("Attack");
        if (_canAttack && attackInput == 1)
        {
            _canAttack = false;
            timer.StartTimer(_attackDelay, CanAttack);


            GameObject bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            bullet.transform.position = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);

            BulletScript bulletScript = bullet.gameObject.GetComponent<BulletScript>();
            bulletScript.teamType = TeamType.Friendly;
        }
    }


    public void CanAttack()
    {
        _canAttack = true;
    }
}
