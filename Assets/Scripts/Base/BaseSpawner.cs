using UnityEngine;

public class BaseSpawner : MonoBehaviour
{
    [SerializeField] private Base _basePfefab;

    public Base Create(Vector3 createPosition)
    {
        return Instantiate(_basePfefab, createPosition, Quaternion.identity);
    }
}
