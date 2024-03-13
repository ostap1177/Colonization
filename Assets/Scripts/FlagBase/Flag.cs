using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private Transform _transform;
    private Base _parentBase;

    //private void OnEnable()
    //{
    //    _parentBase.CreatingNewBase += OnCreatingNewBase;
    //}

    //private void OnDisable()
    //{
    //    _parentBase.CreatingNewBase -= OnCreatingNewBase;
    //}

    //private void Start()
    //{
    //    if (_transform.parent != null)
    //    {
    //        if (_transform.parent.TryGetComponent(out Base parentBase) == true)
    //        {
    //            _parentBase = parentBase;
    //        }
    //    }
    //}

    public void PrepareNewBase(Soldier soldier)
    {
        soldier.transform.parent = transform;
        soldier.SetDirection(transform, transform);
    }

    //private void CreatingNewBase()
    //{
    //    if (_transform.childCount > 0)
    //    {
    //        if (_transform.GetChild(0).TryGetComponent(out Soldier soldier) == true)
    //        {
    //            soldier.SetDirection(_transform, _transform);
    //        }
    //    }
    //}
}
