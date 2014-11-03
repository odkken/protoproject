using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour
{
    public float MaxHealth;
    public float Health { get; set; }

    // Use this for initialization
    void Start()
    {
        Health = MaxHealth;
    }


    public float ModifyHealthByScalar(float scalarAmount)
    {
        return Health = Mathf.Clamp(Health + scalarAmount, 0, MaxHealth);
    }

    public float ModifyHealthByPercentOfCurrentHealth(float percentAmount)
    {
        return Health = Mathf.Clamp(Health + Health * percentAmount, 0, MaxHealth);
    }

    public float ModifyHealthByPercentOfMaxHealth(float percentAmount)
    {
        return Health = Mathf.Clamp(Health + MaxHealth * percentAmount, 0, MaxHealth);
    }


}
