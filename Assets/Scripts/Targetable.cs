using System;
using Assets;
using Assets.Scripts;
using UnityEngine;
using System.Collections;

public class Targetable : MonoBehaviour
{
    private bool isTargeted;
    private SpriteRenderer targetCircle;
    public Life life;
    private StatusManager statusManager;
    // Use this for initialization
    void Start()
    {
        Singleton<TargetManager>.Instance.NewTarget(this);
        targetCircle = transform.FindChild("TargetCircle").GetComponent<SpriteRenderer>();
        targetCircle.enabled = false;
        life = GetComponent<Life>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetCircle.enabled)
            life.Health -= Time.deltaTime * 20;
    }

    public void UseAbility(Ability ability)
    {
        foreach (var statusEffect in ability.Statuses)
        {
            if (statusManager.AddStatusEffect(statusEffect))
                Debug.Log("Added Effect " + statusEffect.GetType().Name);
        }
    }

    public float GetHealthFraction()
    {
        return life.Health / life.MaxHealth;
    }

    public void Target()
    {
        targetCircle.enabled = true;
    }

    public void UnTarget()
    {
        targetCircle.enabled = false;
    }

    public void OnMouseDown()
    {
        FindObjectOfType<PlayerController>().GetComponent<Targeting>().SetTarget(this);
    }

}
