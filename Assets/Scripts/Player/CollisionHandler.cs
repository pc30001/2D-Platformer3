using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action<Finish> FinishReached;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Finish finish))
        {
            FinishReached?.Invoke(finish); // после ?. вылолнится если слева от него не NULL
        }
    }
}
