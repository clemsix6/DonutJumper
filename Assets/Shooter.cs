using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private float nextShoot = 2;


    private void Start()
    {
        nextShoot = Time.time + Random.Range(0.5f, 2f);
    }


    private void Update()
    {
        if (Time.time < nextShoot || Player.locked)
            return;
        nextShoot += Random.Range(2, 4);
        Instantiate(bullet, transform.position, Quaternion.identity);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player"))
            return;
        col.gameObject.GetComponent<Player>().donuts += 10;
        Destroy(gameObject);
    }
}
