using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Static 
{
    public static Vector3 RandomPointInAnnulus(float minRadius, float maxRadius)
    {

        var randomDirection = Random.insideUnitSphere.normalized;
        randomDirection.y = 0;

        var randomDistance = Random.Range(minRadius, maxRadius);

        var point = randomDirection * randomDistance;

        return point;
    }
}
