using UnityEngine;

public class FlugSpawner : MonoBehaviour
{
    [SerializeField] private Flag _flagPrefab;

    public Flag Crete(Vector3 createPosition)
    {
        return Instantiate(_flagPrefab, createPosition, Quaternion.identity);
    }
}
