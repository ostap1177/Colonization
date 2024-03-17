using UnityEngine;

[RequireComponent(typeof(Base))]
public class SoldierSpawn : MonoBehaviour
{
    [SerializeField] private Soldier _soldierPrefab;
    [SerializeField] private float _soldierSpeed;
    [SerializeField] private Vector3 _offsetSpawnPositionSoldier = new Vector3(0, -0.1f, 0);

    private Transform _baseTransform;

    private void Awake()
    {
        _baseTransform = GetComponent<Base>().transform;
    }

    public Soldier CreateSoldiers()
    {
        Soldier soldier = Instantiate(_soldierPrefab, _baseTransform.position + _offsetSpawnPositionSoldier, Quaternion.identity, _baseTransform);
        soldier.SetSpeed(_soldierSpeed);

        return soldier;
    }
}