using UnityEngine;

public class ClickHandler : MonoBehaviour
{ 
    [SerializeField] private Camera _camera;

    private bool _isBaseTap = false;
    private Vector3 _hitPoint;
    private Base _tempBase;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            if (GetHitTransform(out Transform transformHit) == true) 
            {
                if (transformHit.TryGetComponent(out Base gameBase) == true)
                {
                    _isBaseTap = true;
                    _tempBase = gameBase;
                    _tempBase.ClickedBase(_isBaseTap);
                }

                if (transformHit.TryGetComponent(out OreSpawn spawmTerritory) == true)
                {
                    _isBaseTap = false;

                    if (_tempBase != null)
                    {
                        _tempBase.GetClickPoint(_hitPoint);
                        _tempBase.ClickedBase(_isBaseTap);
                    }
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
