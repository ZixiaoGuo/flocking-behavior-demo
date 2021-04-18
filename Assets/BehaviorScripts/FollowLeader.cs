using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Follow Leader")]
public class FollowLeader : FlockBehavior
{


    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        if (flock.followLeader == false)
        {
            return Vector3.zero;
        }
        else
        {
            Vector3 leaderPosition = GameObject.Find("Leader").transform.position;
            //if no neighbors, return no adjustment
            if (context.Count == 0)
                return Vector3.zero;

            //add all points together and average
            Vector3 followLeader = Vector3.zero;
            foreach (Transform item in context)
            {
                followLeader += item.position;
            }
            followLeader /= context.Count;

            if (Vector3.Distance(followLeader, leaderPosition) <= 6)
            {
                return Vector3.zero;
            }

            followLeader = Vector3.Normalize(leaderPosition - followLeader);
            followLeader *= 5;

            return followLeader;
        }

    }


}
