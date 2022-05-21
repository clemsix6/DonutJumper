using System;
using UnityEngine;
using UnityEngine.UI;

public class Member : MonoBehaviour
{
    [SerializeField] private Image image;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;
        this.image.color = Color.white;
        Destroy(gameObject.GetComponent<Collider2D>());
        Destroy(gameObject.GetComponent<SpriteRenderer>());
    }
}
