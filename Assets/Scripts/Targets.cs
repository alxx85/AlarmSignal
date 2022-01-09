using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    [SerializeField] private List<Stolen> _targets;

    public Transform SetNewTarget()
    {
        Stolen newTarget = _targets[Random.Range(0, _targets.Count)];
        newTarget.SetActive();
        _targets.Remove(newTarget);
        return newTarget.gameObject.transform;
    }

    private void Awake()
    {
        _targets = new List<Stolen>(gameObject.GetComponentsInChildren<Stolen>());
    }
}
