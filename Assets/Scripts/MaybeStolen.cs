using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaybeStolen : MonoBehaviour
{
    private bool _isActive = false;

    public void SetActive()
    {
        _isActive = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isActive)
        {
            if (collision.gameObject.TryGetComponent<ThiefMove>(out ThiefMove thief))
            {
                thief.TimeToSteal();
            }
        }
    }
}
