using UnityEngine;

public class EnemyStateMachineFactory
{
    private EnemyStateMachine _stateMachine;

    public EnemyStateMachineFactory(EnemyAnimator animator, PlayerDetectionDetector persecutionDetector, Flipper flipper, MoverByPoints moverByPoints, Follower follower, PlayerDetectionDetector attackDetector, EnemyDamageDealer damageDealer)
    {
        _stateMachine = new EnemyStateMachine();

        _stateMachine.AddState(new EnemyStatePatrolling(_stateMachine, animator, persecutionDetector, moverByPoints, flipper));
        _stateMachine.AddState(new EnemyStatePersecution(_stateMachine, animator, persecutionDetector, follower, flipper, attackDetector));
        _stateMachine.AddState(new EnemyStateAttack(_stateMachine, animator, persecutionDetector, attackDetector, damageDealer));
    }

    public EnemyStateMachine GatStateMachine()
    {
        return _stateMachine;
    }
}