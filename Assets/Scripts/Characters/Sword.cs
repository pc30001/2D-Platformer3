using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    //private bool _isAttack;

    [SerializeField] private int _damage;

  public bool IsAttack {  get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsAttack && collision.TryGetComponent(out Enemy enemy))
        {
            Debug.Log("hit");
            enemy.ApplyDamage(_damage);
        }
    }

    public void Attack()
    {
        IsAttack = true;
    }

    public void StopAttack()
    {
        IsAttack = false;
    }
}
