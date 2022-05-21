using UnityEngine;
using Random = UnityEngine.Random;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private float nextShoot = 2;

    private void Update()
    {
        if (Time.time < nextShoot)
            return;
        nextShoot += Random.Range(2, 4);
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
