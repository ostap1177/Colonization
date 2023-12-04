using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OreCounterForBase : MonoBehaviour
{
    private int _oreCountPoint;

    public event UnityAction<int> AddedOrePoint;

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.TryGetComponent<Soldier>(out Soldier soldier))
        {
            if (soldier.IsDirected == true && soldier.GetComponentInChildren<Ore>(true))
            {
                _oreCountPoint++;
                AddedOrePoint?.Invoke(_oreCountPoint);
            }
        }
    }
}
