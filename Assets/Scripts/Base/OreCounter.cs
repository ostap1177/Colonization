using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CapsuleCollider))]
public class OreCounter : MonoBehaviour
{
    private int _oreCountPoint = 1;

    public event UnityAction<int> ShowOrePoint;

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.TryGetComponent(out Soldier soldier))
        {
            if (soldier.IsDirected == true && soldier.GetComponentInChildren<Ore>(true))
            {
                _oreCountPoint++;
                ShowOrePoint?.Invoke(_oreCountPoint);
            }
        }
    }

    public bool CanSpawn(int point)
    {
        return _oreCountPoint > point;
    }

    public void RemovePoint(int point)
    {
        _oreCountPoint -= point;
        ShowOrePoint(_oreCountPoint);
    }
}
