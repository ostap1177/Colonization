using TMPro;
using UnityEngine;

public class DisplayOre : MonoBehaviour
{
    [SerializeField] private OreCounter _base;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _nameText;

    private void OnEnable()
    {
        _base.ShowOrePoint += OnShowOrePoint;
    }

    private void OnDisable()
    {
        _base.ShowOrePoint += OnShowOrePoint;
    }

    private void Start()
    {
        _text.text = $"{_nameText}: 0";
    }

    private void OnShowOrePoint(int point)
    {
        _text.text = $"{_nameText}: {point}";
    }
}
