using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayOre : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] private OreCounterForBase _oreCounterForBase;
=======
    [SerializeField] private OreCounter _oreCounterForBase;
>>>>>>> parent of 1a32865 (Colonization)
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _nameText;

    private void OnEnable()
    {
        _oreCounterForBase.AddedOrePoint += OnAddedOrePoint;
    }

    private void OnDisable()
    {
        _oreCounterForBase.AddedOrePoint += OnAddedOrePoint;
    }

    private void Start()
    {
        _text.text = $"{_nameText}: 0";
    }

    private void OnAddedOrePoint(int point)
    {
        _text.text = $"{_nameText}: {point}";
    }
}
