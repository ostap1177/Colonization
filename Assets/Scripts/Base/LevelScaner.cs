using UnityEngine;
using UnityEngine.Events;

public class LevelScaner : MonoBehaviour
{
    [SerializeField] private float _scanDistance;
    [SerializeField] private float _scanSpeed = 0.5f;
    private Transform _transform;

    public event UnityAction<Transform> OreFounded;

    private void Awake()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        Scan();
    }

    private void Scan()
    {
        _transform.Rotate(0,_scanSpeed,0);

        RaycastHit[] raycastHits = Physics.RaycastAll(_transform.position,_transform.forward,_scanDistance );
        Debug.DrawRay(_transform.position, _transform.forward, Color.blue,_scanDistance);

        foreach (var hit in raycastHits)
        {
            if (hit.transform.TryGetComponent(out Ore ore) == true && ore.IsScanned == false)
            {
                ore.IsScaning();
                OreFounded?.Invoke(ore.transform);
            }
        }
    }
}
