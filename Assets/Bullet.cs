using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject boom;
    private float speed;
    private GameObject player;
    
    private void Start()
    {
        speed = Random.Range(3f, 10f);
        GetPlayer();
        gameObject.transform.right = player.transform.position - transform.position;
    }

    private void GetPlayer()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");
        var distance = float.MaxValue;
        
        foreach (var p in players)
        {
            var currentDistance = Vector2.Distance(p.transform.position, transform.position);
            if (!(currentDistance < distance))
                continue;
            this.player = p;
            distance = currentDistance;
        }
    }

    private void UpdateRotation()
    {
        var before = gameObject.transform.right;
        var target = player.transform.position - transform.position;
        var interpolation = 0.3f * Time.deltaTime;
        if (interpolation > 1)
            interpolation = 1;
        var after = Vector3.Lerp(before, target, interpolation);

        gameObject.transform.right = after;
    }

    private void CheckDistance()
    {
        var distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > 50)
            Destroy(gameObject);
        gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void Update()
    {
        if (player == null)
            return;
        UpdateRotation();
        CheckDistance();
        if (Player.locked)
            Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (!coll.gameObject.CompareTag("Ground") && !coll.gameObject.CompareTag("Bullet"))
            return;
        Instantiate(boom, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
