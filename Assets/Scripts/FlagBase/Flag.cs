using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] BaseSpawner _spawnerBase;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public void Instal(Vector3 poinInstal)
    {
        _transform.position = poinInstal;
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.TryGetComponent(out Soldier soldier) == true && soldier.IsDirectionNewBase == true)
        {
            Base newBase = _spawnerBase.Create(_transform.position);
            soldier.transform.parent = newBase.transform;
            _transform.gameObject.SetActive(false);
        }
    }
}
