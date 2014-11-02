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

    // Update is called once per frame
    void Update()
    {

    }
}
