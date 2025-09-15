using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Остановился тут. Надо перенести сюда всю логику преследования из состояния преследования. 
//1 надо обновлять список игроков которые входят в зону видимости.
//2 каждый кадр проверять какой игрок находится ближе всего и устанавливать его в качестве цели.
//3 переход в состояние атаки и в состояние патрулирования (но это в самом состоянии преследования).
public class Follower
{
    private float _distanceCeasePersecution = 1.2f;
    private IReadOnlyList<Health> _playersInZoneVisible;//остановился тут. надо придумать как инициализировать этот список, ну или как его сюда передать. и дальше придумать как обновлять список каждый кадр, чтобы устанавливать цель приследования.
    private EnemyDetector _attackDetector;

    public Follower(EnemyStateMachine stateMachine, Transform transform, Flipper flipper, EnemyDetector persecutionDetector, EnemyAnimator animator, EnemyDetector attackDetector, EnemyMover enemyMover) : base(stateMachine, transform, flipper, persecutionDetector, animator, attackDetector, enemyMover)
    {

    }

   


    public Health GetNearestPlayerInVisibleZone()
    {
        List<Health> targetsOrderedByDistance = new List<Health>(_playersInZoneVisible.OrderBy(p => Mathf.Abs(p.transform.position.x - Transform.position.x)));

        return targetsOrderedByDistance[0];
    }

    public void UpdateListPlayersInZoneOfVisibility()// 1 вот этот метод надо вызывать в состоянии преследования в апдейте. Надо подписать этот метод на событие входа и выхода коллайдера в зону видимости. Метод 
    {
        _playersInZoneVisible = PersecutionDetector.Targets;
    }
}
