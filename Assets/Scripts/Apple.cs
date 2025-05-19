using UnityEngine;

public class Apple : MonoBehaviour
{
    [field: SerializeField] public int RecoverableHealth { get; private set; } = 30;
}
