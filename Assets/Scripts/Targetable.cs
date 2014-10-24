using Assets.Scripts;
using UnityEngine;
using System.Collections;

public class Targetable : MonoBehaviour
{
    private bool isTargeted;
    private SpriteRenderer targetCircle;
    // Use this for initialization
    void Start()
    {
        Singleton<TargetManager>.Instance.NewTarget(this);
        targetCircle = transform.FindChild("TargetCircle").GetComponent<SpriteRenderer>();
        targetCircle.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
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
