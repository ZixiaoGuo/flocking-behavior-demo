using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocks : MonoBehaviour
{
    public Boids boidPrefab;
    List<Boids> boids = new List<Boids>();
    public FlockBehaviors behavior;

    public int initialBoids = 300;
    float density = 0.08f;

    public float boidsSpeed = 5f;
    public float maxSpeed = 15f;
    public float neighborRadius = 1.5f; 
    public float avoidanceRadiusMultiplier = 0.5f;

    float squareMaxSpeed;   
    float squareNeighborRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    public Vector3 destinationPoint;
    public bool followLeader = false;
    public bool lazyFlight = false;

    void Start()
    {

        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;
        for (int i = 0; i < initialBoids; i++)
        {
            Boids childBoids = Instantiate(
                boidPrefab,
                Random.insideUnitSphere * initialBoids * density,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform
                );
            childBoids.name = "Boid " + i;
            boids.Add(childBoids);
        }

        destinationPoint = new Vector3(Random.Range(-25f, 25f), Random.Range(-25f, 25f), Random.Range(-25f, 25f));
        Debug.Log("This is the current target: " + destinationPoint);

    }

    void Update()
    {
        foreach (Boids boid in boids)
        {
            List<Transform> context = GetNearbyObjects(boid);

            Vector3 move = behavior.CalculateMove(boid, context, this);
            move *= boidsSpeed;
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            boid.Move(move);
        }
    }

    List<Transform> GetNearbyObjects(Boids boid)
    {
        List<Transform> context = new List<Transform>();
        Collider[] contextColliders = Physics.OverlapSphere(boid.transform.position, neighborRadius);
        foreach (Collider c in contextColliders)
        {
            if (c != boid.BoidsCollider)
            {
                context.Add(c.transform);
            }
        }
        return context;
    }
}
