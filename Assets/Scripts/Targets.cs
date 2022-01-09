using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    [SerializeField] private List<MaybeStolen> _targets;

    private void Awake()
    {
        _targets = new List<MaybeStolen>(gameObject.GetComponentsInChildren<MaybeStolen>());
    }

    public Transform SetNewTarget()
    {
        MaybeStolen newTarget = _targets[Random.Range(0, _targets.Count)];
        newTarget.SetActive();
        _targets.Remove(newTarget);
        return newTarget.gameObject.transform;
    }
}
