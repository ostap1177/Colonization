using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayOre : MonoBehaviour
{
    [SerializeField] private OreCounterForBase _oreCounterForBase;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _nameText;

    private void OnEnable()
    {
        _oreCounterForBase.AddedOrePoint += OnDisplayCounOre;
    }

    private void OnDisable()
    {
        _oreCounterForBase.AddedOrePoint += OnDisplayCounOre;
    }

    private void Start()
    {
        _text.text = $"{_nameText}: 0";
    }

    private void OnDisplayCounOre(int countOre)
    {
        _text.text = $"{_nameText}: {countOre}";
    }
}
