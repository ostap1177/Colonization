using TMPro;
using UnityEngine;

public class OreDisplay : MonoBehaviour
{
    [SerializeField] private OreCounter _oreCounter;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _oreCounter.ChangedOrePoint += OnShowOrePoint;
    }

    private void OnDisable()
    {
        _oreCounter.ChangedOrePoint += OnShowOrePoint;
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
