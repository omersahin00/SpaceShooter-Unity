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
        timer = FindObjectOfType<Timer>();
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
            Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        }
    }


    public void CanAttack()
    {
        _canAttack = true;
    }
}
