using TMPro;
using UnityEngine;

public class DisplayOre : MonoBehaviour
{
    [SerializeField] private OreCounter _oreCounter;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _oreCounter.ShowOrePoint += OnShowOrePoint;
    }

    private void OnDisable()
    {
        _oreCounter.ShowOrePoint += OnShowOrePoint;
    }

    private void Start()
    {
        _text.text = $"0";
    }

    private void OnShowOrePoint(int point)
    {
        _text.text = $"{point}";
    }
}
