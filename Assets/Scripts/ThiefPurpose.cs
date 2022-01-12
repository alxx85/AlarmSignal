using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefPurpose : MonoBehaviour
{
    private bool _isTarget = false;

    public bool IsTarget => _isTarget;

    public void IsTargetThief()
    {
        _isTarget = true;
    }
}
