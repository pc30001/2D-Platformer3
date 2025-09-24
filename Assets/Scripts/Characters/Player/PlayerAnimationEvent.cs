using System;
using UnityEngine;

public class PlayerAnimationEvent : MonoBehaviour
{
    public event Action AttackPlayer;
    public event Action EndAttackPlayer;

    public void InvokeAttackPlayerkEvent() => AttackPlayer?.Invoke();


    public void InvokeEndAttackPlayerAttackEvent() => EndAttackPlayer?.Invoke();
}
