using UnityEngine;
using UnityEngine.Events;

public class OreCounter : MonoBehaviour
{
    private int _oreCountPoint;

    public event UnityAction<int> AddedOrePoint;

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.TryGetComponent(out Soldier soldier))
        {
            if (soldier.IsDirected == true && soldier.GetComponentInChildren<Ore>(true))
            {
                _oreCountPoint++;
                AddedOrePoint?.Invoke(_oreCountPoint);
            }
        }
    }
}
