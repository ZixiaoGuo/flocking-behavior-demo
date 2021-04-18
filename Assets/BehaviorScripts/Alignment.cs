using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviors/Alignment")]
public class Alignment : FlockBehaviors
{
    public override Vector3 CalculateMove(Boids boid, List<Transform> context, Flocks flock)
    {
        if (context.Count == 0)
            return boid.transform.forward;

        Vector3 alignmentMove = Vector3.zero;
        foreach (Transform item in context)
        {
            alignmentMove += item.transform.forward;
        }
        alignmentMove /= context.Count;

        return alignmentMove;
    }
}
