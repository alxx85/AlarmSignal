using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    [SerializeField] private List<ThiefPurpose> _targets;

    private void Awake()
    {
        _targets = new List<ThiefPurpose>(gameObject.GetComponentsInChildren<ThiefPurpose>());
    }

    public Transform GetTargetTransform()
    {
        ThiefPurpose newTarget = _targets[Random.Range(0, _targets.Count)];
        newTarget.SetTarget();
        _targets.Remove(newTarget);
        return newTarget.gameObject.transform;
    }
}
