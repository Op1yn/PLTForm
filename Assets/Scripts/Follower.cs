using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Follower
{
    private float _distanceCeasePersecution = 1.2f;
   
    private EnemyDetector _persecutionDetector;
    
    EnemyMover _enemyMover;

    public Follower(EnemyStateMachine stateMachine, Transform transform, Flipper flipper, EnemyDetector persecutionDetector, EnemyAnimator animator, EnemyDetector attackDetector, EnemyMover enemyMover) : base(stateMachine, transform, flipper, persecutionDetector, animator, attackDetector, enemyMover)
    {
        _persecutionDetector = persecutionDetector;
       
        _enemyMover = enemyMover;
    }

    //private Health GetNearestHealthVisibleZone()
    //{
    //    List<Health> targetsOrderedByDistance = new List<Health>(_playersInZoneVisible.OrderBy(p => Mathf.Abs(p.transform.position.x - _transform.position.x)));

    //    return targetsOrderedByDistance[0];
    //}

    public void SetTargetForPersecution()
    {
        _enemyMover.SetTargetToMoveTowards(_persecutionDetector.GetNearestTarget().transform);
    }

}
