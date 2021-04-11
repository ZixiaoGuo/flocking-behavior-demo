using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Lazy Flight")]
public class LazyFlightBehavior : FlockBehavior
{
    bool createdTarget = false;



    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        if (!createdTarget)
        {
           GameObject target = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            target.transform.position = flock.destinationPoint;
            target.GetComponent<Renderer>().material.color = Color.red;

            createdTarget = true;
        }
        

        //if no neighbors, return no adjustment
        if (context.Count == 0)
            return Vector3.zero;

        //add all points together and average
        Vector3 lazyMove = Vector3.zero;
        foreach (Transform item in context)
        {
            lazyMove += item.position;
        }
        lazyMove /= context.Count;

        if(Vector3.Distance(lazyMove, flock.destinationPoint) <= 2)
        {
            flock.destinationPoint = new Vector3(Random.Range(-25f, 25f), Random.Range(-25f, 25f), Random.Range(-25f, 25f));
            createdTarget = false;
            Debug.Log("This is the current target: " + flock.destinationPoint);
            Destroy(GameObject.Find("Sphere"));
        }

        lazyMove = Vector3.Normalize(flock.destinationPoint - lazyMove);
        lazyMove *= 5;
        
        return lazyMove;
    }


}
