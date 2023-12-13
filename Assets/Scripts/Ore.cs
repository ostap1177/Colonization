using UnityEngine;

public class Ore : MonoBehaviour
{
    public bool IsDelivered { get; private set;}

    public void IsTaken()
    {
        IsDelivered = true;
    }

    public void DestroyOre()
    {
        Destroy(gameObject);
    }
}
