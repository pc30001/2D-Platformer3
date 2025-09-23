using System;
using UnityEngine;

public class EnemyAnimationEvent : MonoBehaviour
{
    public event Action Attack;

    public void InvokeAttackEvent()
    {
        Attack?.Invoke();
    }
}
