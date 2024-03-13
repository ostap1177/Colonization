using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Base : MonoBehaviour
{
    [SerializeField] private ClickHandler _clickHandler;
    [SerializeField] private ScanLevelToRay _scanLevel;
    [SerializeField] private OreCounter _oreCounterForBase;
    [SerializeField] private SoldierSpawn _soldierSpawn;
    [SerializeField] private Flag _flagPrefab;
    [SerializeField] private int _limitSoldiers;

    //public event UnityAction CreatingNewBase;

    private Queue <Transform> _transformsOre;

    private List<Soldier> _soldiersAll;
    private Queue <Soldier> _soldiers;

    private Transform _transform;
    private Flag _flag;
    private Transform _flagTransform;

    private bool _isClickOnBase = false;
    private bool _isPutFlag;
    private bool _isSufficeCreatinSoldier;
    private bool _isSufficeCreatinBase;

    private void Awake()
    {
        _soldiersAll = new List<Soldier>();
        _transformsOre = new Queue<Transform>();
        _soldiers = new Queue<Soldier>();
        _transform = transform;

        _limitSoldiers++;

        CreateFlag();
    }

    private void OnEnable()
    {
        _scanLevel.OreFounded += OnSpawnedOre;

        _oreCounterForBase.ReachedCreateSoldiers += OnReachedCreateSoldiers;
        _oreCounterForBase.ReachedCreateBase += OnReachedCreateBase;

        _clickHandler.ClickedNotBase += OnClickedNotBase;
        _clickHandler.GetedClickPoint += OnGetedClickPoint;
    }

    private void OnDisable()
    {
        _scanLevel.OreFounded -= OnSpawnedOre;

        _oreCounterForBase.ReachedCreateSoldiers += OnReachedCreateSoldiers;
        _oreCounterForBase.ReachedCreateBase += OnReachedCreateBase;

        _clickHandler.ClickedNotBase -= OnClickedNotBase;
        _clickHandler.GetedClickPoint -= OnGetedClickPoint;
    }

    private void Start()
    {
        AddedSoldier(_soldierSpawn.CreateSoldiers());
    }

    private void FixedUpdate()
    {
        ControlSoldiers();
    }

    private void ControlSoldiers()
    {
        SendSodierOre();

        if (_isPutFlag == true && _soldiersAll.Count > 1)
        {
            if (_isSufficeCreatinBase == true)
            {
                SendSodierCreatingBase();
            }
        }
        else
        {
            if (_isSufficeCreatinSoldier == true && _soldiersAll.Count < _limitSoldiers)
            {
                AddedSoldier(_soldierSpawn.CreateSoldiers());

                _oreCounterForBase.SubtractPoint(_oreCounterForBase.OreForCreateSoldier);
                _isSufficeCreatinSoldier = false;
            }
            else if (_soldiersAll.Count == _limitSoldiers)
            {
                _isSufficeCreatinSoldier = false;
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
            _isPutFlag = false;
            _isSufficeCreatinBase = false;
            _oreCounterForBase.SubtractPoint(_oreCounterForBase.OreForCreateBase);

            Soldier soldier = _soldiers.Dequeue();
            _flag.PrepareNewBase(soldier);
            _soldiersAll.Remove(soldier);

            _flag.transform.parent = null;
            CreateFlag();
        }
    }

    private void AddedSoldier(Soldier soldier)
    {
        _soldiersAll.Add(soldier);
        _soldiers.Enqueue(soldier);
    }

    private void CreateFlag()
    {
        _flag = Instantiate(_flagPrefab, _transform);
        _flagTransform = _flag.transform;
        _flag.gameObject.SetActive(false);
    }

    public void ClickedBase(bool isBaseClicked)
    {
        _isClickOnBase = isBaseClicked;
    }

    private void OnReachedCreateBase()
    {
       _isSufficeCreatinBase = true;
    }

    private void OnReachedCreateSoldiers()
    {
        _isSufficeCreatinSoldier = true;
    }

    private void OnSpawnedOre(Transform transform)
    {
        _transformsOre.Enqueue(transform);
    }

    private void OnClickedNotBase()
    {
        _isClickOnBase = false;   
    }

    private void OnGetedClickPoint(Vector3 instalPosition)
    {
        if (_flag != null && _isClickOnBase == true)
        {
            if (_flag.gameObject.activeSelf == false)
            {
                _flag.gameObject.SetActive(true);
                _flag.transform.position = instalPosition;
                _isPutFlag = true;
            }
            else
            {
                _flag.transform.position = instalPosition;
            }
        }

        _isClickOnBase = false;
    }
}