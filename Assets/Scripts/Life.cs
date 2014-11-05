using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour
{
    public float MaxHealth;

    private float health;

    public float Health
    {
        get { return health; }

        set
        {
            health = Mathf.Clamp(value, 0, MaxHealth);
            if (health <= 0)
                Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        Health = MaxHealth;
    }


    public float ModifyHealthByScalar(float scalarAmount)
    {
        return Health += scalarAmount;
    }

    public float ModifyHealthByPercentOfCurrentHealth(float percentAmount)
    {
        return Health += Health * percentAmount;
    }

    public float ModifyHealthByPercentOfMaxHealth(float percentAmount)
    {
        return Health += MaxHealth * percentAmount;
    }


}
