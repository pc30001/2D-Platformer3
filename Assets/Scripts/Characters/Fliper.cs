using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fliper : MonoBehaviour
{
    public bool IsTurnRight { get; private set; } = false;

    public void LookAtTarget(Vector2 targetPosition)
    { 

      if ((transform.position.x < targetPosition.x && IsTurnRight == false)
         || (transform.position.x > targetPosition.x && IsTurnRight))
        {
            IsTurnRight = !IsTurnRight;
            transform.Flip();
        }
    }
}
