using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action<IInteractable> FinishReached;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable finish))
        {
            FinishReached?.Invoke(finish); // после ?. вылолнится если слева от него не NULL
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable _)) //_ не хранить память 
        {
            FinishReached?.Invoke(null); // если покинули какой то триггер то будет  NULL
        }
    }
}
