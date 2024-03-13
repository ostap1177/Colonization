using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PutFlug : MonoBehaviour
{
    [SerializeField] private ClickHandler _clickHandler;
    [SerializeField] private Flag _flagPrefab;

    private Vector3 _pointFlag;
    private bool _isFlagInstalled = false;
    private Flag _flag;

    private void OnEnable()
    {
        _clickHandler.GetedClickPoint += OnGetedClickPoint;
    }

    private void OnDisable()
    {
        _clickHandler.GetedClickPoint -= OnGetedClickPoint;
    }

    private void OnGetedClickPoint(Vector3 vector)
    {
        InstalFlag(vector);
    }

    private void InstalFlag(Vector3 poinInstal)
    {
        if (_isFlagInstalled == false)
        {
           _flag = Instantiate(_flagPrefab,poinInstal,Quaternion.identity);
            _isFlagInstalled = true;
        }

        _flag.transform.position = poinInstal;
    }
}
