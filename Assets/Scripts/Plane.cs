using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public PlaneCoords _planeCoords { get; private set; }
    private void Awake()
    {
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Bounds bounds = mesh.bounds;

        _planeCoords = new PlaneCoords()
        {
            minX = bounds.min.x,
            minZ = bounds.min.z,
            maxZ = bounds.max.z,
            maxX = bounds.max.x,
            maxY = bounds.max.y,
            minY = bounds.max.y,
        };
    }
}
