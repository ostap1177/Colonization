using UnityEngine;

public class SpawnBase : MonoBehaviour
{
    [SerializeField] Base departmentPrefab;

    public Base Create(Vector3 position)
    {
        return Instantiate(departmentPrefab, position, Quaternion.identity);
    }
}
