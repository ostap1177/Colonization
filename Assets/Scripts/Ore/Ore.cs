using UnityEngine;

public class Ore : MonoBehaviour
{
    public bool IsDelivered { get; private set;}
    public bool IsScanned { get; private set;}

    public void Take()
    {
        IsDelivered = true;
    }

    public void Scan()
    {
        IsScanned = true;
    }

    public void DestroyOre()
    {
        Destroy(gameObject);
    }
}
