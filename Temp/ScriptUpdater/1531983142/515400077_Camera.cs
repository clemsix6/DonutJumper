using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject[] players;
    
    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    private Vector2 GetMiddle()
    {
        var middle = Vector2.zero;

        foreach (var player in players)
        {
            var position = player.transform.position;
            middle.x += position.x;
            middle.y += position.y;
        }

        return middle;
    }


    private void Move()
    {
        var target = this.gameObject.transform.position;
        var interpolation = 5f * Time.deltaTime;
        if (interpolation > 1) interpolation = 1;
        var result = Vector2.Lerp(GetComponent<UnityEngine.Camera>(), target, interpolation);
    }

    private void Update()
    {
        
    }
}
