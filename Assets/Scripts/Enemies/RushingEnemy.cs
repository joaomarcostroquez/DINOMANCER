using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushingEnemy : Enemy
{
    private void Update()
    {
        MoveUntilPlayerInRangeAndOnSight();
    }
}
