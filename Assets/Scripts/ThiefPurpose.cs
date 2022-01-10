using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefPurpose : MonoBehaviour
{
    private bool _isTarget = false;

    public void SetTarget()
    {
        _isTarget = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isTarget)
        {
            if (collision.gameObject.TryGetComponent<ThiefMove>(out ThiefMove thief))
            {
                thief.TimeToSteal();
            }
        }
    }
}
