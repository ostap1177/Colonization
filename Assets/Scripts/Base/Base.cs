using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OreCounterForBase))]
public class Base : MonoBehaviour
{
    [SerializeField] private OreSpawn _oreSpawn;
    [SerializeField] private Soldier _soldierPrefab;
    [SerializeField] private float _soldierSpeed;
    [SerializeField] private Vector3 _offsetSpawnPositionSoldier = new Vector3(0, -0.1f, 0);

    private OreCounterForBase _oreCounterForBase;
    private Queue <Transform> _transformsOre;
    private int _limitSoldiers = 3;
    private List<Soldier> _soldiersAll;
    private Queue <Soldier> _soldiers;
    private Transform _transform;

    private void OnEnable()
    {
        _oreSpawn.OreSpawned += OnSpawnedOre;
    }

    private void OnDisable()
    {
        _oreSpawn.OreSpawned -= OnSpawnedOre;
    }

    private void Awake()
    {
        _oreCounterForBase = GetComponent<OreCounterForBase>();
    }

    private void Start()
    {
        _soldiersAll = new List<Soldier>();
        _transformsOre = new Queue<Transform>();
        _soldiers = new Queue<Soldier>();
        _transform = transform;

        CreateSoldiers();
    }

    private void FixedUpdate()
    {
        SendSodier();
    }

    private void CreateSoldiers()
    {
        for (int i=0; i<_limitSoldiers ; i++ )
        {
            Soldier soldier = Instantiate(_soldierPrefab, _transform.position + _offsetSpawnPositionSoldier, Quaternion.identity, _transform);
            soldier.SetSpeed(_soldierSpeed);
            _soldiersAll.Add(soldier);
            _soldiers.Enqueue(soldier);
        }
    }

    private void SendSodier()
    {
        if (_transformsOre.Count > 0)
        {
            if (_soldiers.Count != 0)
            {
                _soldiers.Dequeue().SetDirection(_transformsOre.Dequeue(), _transform);
            }
            else
            {
                foreach (Soldier soldier in _soldiersAll)
                {
                    if (soldier.IsDirected == false)
                    {
                        _soldiers.Enqueue(soldier);
                    }
                }
            }
        }
    }

    private void OnSpawnedOre(Transform transform)
    {
        _transformsOre.Enqueue(transform);
    }
}
