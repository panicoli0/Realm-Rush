using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] GameObject ballistaPrefab;

    public bool IsPlaceable { get { return isPlaceable; } }

    void OnMouseDown()
    {
        if (isPlaceable)
        {
            Debug.Log(transform.name);
            Instantiate(ballistaPrefab, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
        
    }
}
