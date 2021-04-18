using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviors/Cohesion")]
public class Cohesion : FlockBehaviors
{
    public override Vector3 CalculateMove(Boids boid, List<Transform> context, Flocks flock)
    {
        if (context.Count == 0)
            return Vector3.zero;

        //add all points together and average
        Vector3 cohesionMove = Vector3.zero;
        foreach (Transform item in context)
        {
            cohesionMove += item.position;
        }
        cohesionMove /= context.Count;

        cohesionMove -= boid.transform.position;
        return cohesionMove;
    }
}
