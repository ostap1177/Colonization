using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CapsuleCollider))]
public class OreCounter : MonoBehaviour
{
    [SerializeField] private int _oreForCreateBase;
    [SerializeField] private int _oreForCreateSoldier;

    private int _oreCountPoint;

    public event UnityAction<int> ShowOrePoint;
    public event UnityAction ReachedCreateSoldiers;
    public event UnityAction ReachedCreateBase;

    public int OreForCreateBase => _oreForCreateBase;
    public int OreForCreateSoldier => _oreForCreateSoldier;

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.TryGetComponent(out Soldier soldier))
        {
            if (soldier.IsDirected == true && soldier.GetComponentInChildren<Ore>(true))
            {
                _oreCountPoint++;
                ShowOrePoint?.Invoke(_oreCountPoint);

                if (_oreCountPoint >= _oreForCreateSoldier)
                {
                    ReachedCreateSoldiers?.Invoke();
                }

                if (_oreCountPoint >= _oreForCreateBase)
                {
                    ReachedCreateBase?.Invoke();
                }
            }
        }
    }

    public void SubtractPoint(int point)
    {
        _oreCountPoint -= point;
        ShowOrePoint(_oreCountPoint);
    }
}
