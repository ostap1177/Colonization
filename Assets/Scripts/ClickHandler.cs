using UnityEngine;

public class ClickHandler : MonoBehaviour
{ 
    [SerializeField] private Camera _camera;

    private bool _isBaseTap = false;
    private Base _gameBase;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            if (GetHitTransform(out Transform transformHit, out Vector3 hitPoint) == true) 
            {
                if (transformHit.TryGetComponent(out Base gameBase) == true)
                {
                    _isBaseTap = true;
                    _gameBase = gameBase;
                    _gameBase.ClickOnBase(_isBaseTap);
                }

                if (transformHit.TryGetComponent(out OreSpawn spawmTerritory) == true)
                {
                    _isBaseTap = false;

                    if (_gameBase != null)
                    {
                        _gameBase.TakeClickPoint(hitPoint);
                        _gameBase.ClickOnBase(_isBaseTap);
                    }
                }
            }
        }
    }

    private bool GetHitTransform(out Transform transform, out Vector3 hitPoint)
    {
        transform = null;
        hitPoint = Vector3.zero;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit) == true)
        {
            transform = hit.transform;
            hitPoint = hit.point;
        }

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);

        return transform != null;
    }
}
