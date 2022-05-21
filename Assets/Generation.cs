using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Generation : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;

    private void Start()
    {
        for (int y = 0; y < 3; y++)
        {
            for (var i = 0; i < 500; i += 6)
            {
                var obj = Instantiate(prefabs[Random.Range(0, prefabs.Length)]);
                obj.transform.position = new Vector3(i, (-10 * (y + 1)));
            }
        }
    }
}
