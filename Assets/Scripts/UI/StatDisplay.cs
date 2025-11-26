using UnityEngine;

public abstract class StatDisplay : MonoBehaviour
{
    private void Awake()
    {
        SetMaximumStatDisplay();
        UpdateHealthDisplay();
    }

    public abstract void SetMaximumStatDisplay();

    public abstract void UpdateHealthDisplay();
}
