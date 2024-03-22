using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class OreCounter : MonoBehaviour
{
    private int _oreCountPoint = 1;

    public event UnityAction<int> ChangedOrePoint;

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.TryGetComponent(out Soldier soldier))
        {
            if (soldier.IsDirected == true && soldier.GetComponentInChildren<Ore>(true))
            {
                _oreCountPoint++;
                ChangedOrePoint?.Invoke(_oreCountPoint);
            }
        }
    }

    public bool IsSufficePoint(int point)
    {
        return _oreCountPoint > point;
    }

    public void RemovePoint(int point)
    {
        _oreCountPoint -= point;
        ChangedOrePoint(_oreCountPoint);
    }
}
