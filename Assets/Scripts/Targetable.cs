using Assets.Scripts;
using UnityEngine;
using System.Collections;

public class Targetable : MonoBehaviour
{
    private bool isTargeted;
    private SpriteRenderer targetCircle;
    private Life life;
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
}
