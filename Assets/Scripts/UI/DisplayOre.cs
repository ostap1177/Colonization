using TMPro;
using UnityEngine;

public class DisplayOre : MonoBehaviour
{
    [SerializeField] private OreCounter _oreCounterForBase;
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
