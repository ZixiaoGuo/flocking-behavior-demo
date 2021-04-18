using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    public Flocks flock;

    public void SetLazyFlight()
    {
        flock.followLeader = false;
        flock.lazyFlight = true;
    }

    public void SetFollowLeader()
    {
        flock.lazyFlight = false;
        flock.followLeader = true;

    }

    public void ResetMode()
    {
        flock.lazyFlight = false;
        flock.followLeader = false;
    }
}
