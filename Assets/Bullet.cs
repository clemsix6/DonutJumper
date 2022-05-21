using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private GameObject player;
    
    private void Start()
    {
        player = GameObject.Find("Player");
        gameObject.transform.right = player.transform.position - transform.position;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            1);
    }

    private void UpdateRotation()
    {
        var before = gameObject.transform.right;
        var target = player.transform.position - transform.position;
        var interpolation = 0.1f * Time.deltaTime;
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
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        UpdateRotation();
        CheckDistance();
    }


    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ground"))
            Destroy(gameObject);
    }
}
