using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ore : MonoBehaviour
{
    
    public bool IsDelivered { get; private set;}

    /*private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.TryGetComponent<Base>(out Base soldier))
        {
            Destroy(gameObject);
        }
    }*/

    public void IsTaken()
    {
        IsDelivered = true;
    }

    public void DestroyOre()
    {
        Destroy(gameObject);
    }
}
