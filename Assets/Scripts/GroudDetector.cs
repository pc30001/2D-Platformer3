using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroudDetector : MonoBehaviour
{
    public bool IsGround { get; private set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ConstantsData.Tags.GROUND_TAG))
            IsGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ConstantsData.Tags.GROUND_TAG))
            IsGround = false;
    }
}
