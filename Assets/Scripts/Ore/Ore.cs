using UnityEngine;

public class Ore : MonoBehaviour
{
    public bool IsDelivered { get; private set;}
    public bool IsScanned { get; private set;}

    public void IsTaken()
    {
        IsDelivered = true;
    }

    public void IsScaning()
    {
        IsScanned = true;
    }

    public void DestroyOre()
    {
        Destroy(gameObject);
    }
}
