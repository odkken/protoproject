using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class ObjectSpawner : MonoBehaviour
    {
        public List<GameObject> ObjectsToSpawn;
        public float SpawnInterval = .1f;
        // Use this for initialization
        void Start()
        {
            StartCoroutine(Spawn());
        }


        IEnumerator Spawn()
        {
            while (enabled)
            {
                Instantiate(ObjectsToSpawn[Random.Range(0, ObjectsToSpawn.Count)]);
                yield return new WaitForSeconds(SpawnInterval);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
