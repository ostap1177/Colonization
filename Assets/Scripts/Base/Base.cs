using System;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private LevelScaner _levelScan;
    [SerializeField] private OreCounter _oreCounter;
    [SerializeField] private SoldierSpawn _soldierSpawn;
    [SerializeField] private Flag _flagPrefab;
    [SerializeField] private int _limitSoldiers;
    [SerializeField] private int _oreCreateBase;
    [SerializeField] private int _oreCreateSoldier;

    private Queue <Transform> _transformsOre;

    private List<Soldier> _soldiersAll;
    private Queue <Soldier> _soldiers;

    private Transform _transform;
    private Flag _flag;
    
    private bool _isClickOnBase = false;
    private bool _isPutFlag;

    private void Awake()
    {
        _soldiersAll = new List<Soldier>();
        _transformsOre = new Queue<Transform>();
        _soldiers = new Queue<Soldier>();
        _transform = transform;

        _limitSoldiers++;

        SetFlag();
    }

    private void OnEnable()
    {
        _levelScan.OreFounded += OnSpawnedOre;
    }

    private void OnDisable()
    {
        _levelScan.OreFounded -= OnSpawnedOre;
    }

    private void Start()
    {
        AddedSoldier(_soldierSpawn.CreateSoldiers());
    }

    private void FixedUpdate()
    {
        ControlSoldiers();
    }

    public void ClickedBase(bool isBaseClicked)
    {
        _isClickOnBase = isBaseClicked;
    }

    public void GetClickPoint(Vector3 instalPosition)
    {
        if (_flag != null && _isClickOnBase == true)
        {
            if (_flag.gameObject.activeSelf == false)
            {
                _flag.gameObject.SetActive(true);
                _isPutFlag = true;
            }

            _flag.Instal(instalPosition);
        }
    }

    private void ControlSoldiers()
    {
        SendSodierOre();

        if (_isPutFlag == true && _soldiersAll.Count > 1)
        {
            if (_oreCounter.CanSpawn(_oreCreateBase) == true)
            {
                SendSodierCreatingBase();
            }
        }
        else
        {
            if (_oreCounter.CanSpawn(_oreCreateSoldier) && _soldiersAll.Count < _limitSoldiers)
            {
                AddedSoldier(_soldierSpawn.CreateSoldiers());
            }
        }
    }

    private void SendSodierOre()
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

    private void SendSodierCreatingBase()
    {   
        if (_soldiers.Count != 0 )
        {
            _oreCounter.RemovePoint(_oreCreateBase);

            Soldier soldier = _soldiers.Dequeue();
            _soldiersAll.Remove(soldier);
            soldier.SetDirection(_flag.transform,_transform);
        }
    }

    private void AddedSoldier(Soldier soldier)
    {
        _soldiersAll.Add(soldier);
        _soldiers.Enqueue(soldier);
        _oreCounter.RemovePoint(_oreCreateSoldier);
    }

    private void OnSpawnedOre(Transform transform)
    {
        _transformsOre.Enqueue(transform);
    }

    private void SetFlag()
    {
        _flag = Instantiate(_flagPrefab, _transform);
        _flag.transform.parent = _transform;
        _flag.gameObject.SetActive(false);
    }
}