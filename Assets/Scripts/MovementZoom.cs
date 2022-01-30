using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementZoom : MonoBehaviour
{
    public float zoomLevel;
    public Transform parentObject;

    private float zoomPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Follows the zoomLevel value at 30 units per second
        zoomPosition = Mathf.MoveTowards(zoomPosition, zoomLevel, 10 * Time.deltaTime);
        transform.position = parentObject.position + (transform.forward * zoomPosition);
    }
}
