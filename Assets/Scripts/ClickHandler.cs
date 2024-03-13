using UnityEngine;
using UnityEngine.Events;

public class ClickHandler : MonoBehaviour
{ 
    [SerializeField] private Camera _camera;

    public event UnityAction<Vector3> GetedClickPoint;
    public event UnityAction ClickedNotBase;

    private bool _isBaseTap = false;
    private Vector3 _hitPoint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            if (GetHitTransform(out Transform transformHit) == true) 
            {
                if (transformHit.TryGetComponent(out Base gameBase) == true)
                {
                    _isBaseTap = true;
                    gameBase.ClickedBase(_isBaseTap);
                }

                if (transformHit.TryGetComponent(out OreSpawn spawmTerritory) == true)
                {
                    _isBaseTap = false;
                    GetedClickPoint?.Invoke(_hitPoint);
                }
            }
        }
    }

    private bool GetHitTransform(out Transform transform)
    {
        transform = null;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit) == true)
        {
            transform = hit.transform;
            _hitPoint = hit.point;
        }

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);

        return transform != null;
    }
}
