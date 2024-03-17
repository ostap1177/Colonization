using UnityEngine;

public class PutFlug : MonoBehaviour
{
    [SerializeField] private Flag _flagPrefab;

    public Flag CreteFlag(Vector3 createPosition)
    {
        return Instantiate(_flagPrefab, createPosition, Quaternion.identity);
    }
}
