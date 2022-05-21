using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static bool locked = false;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode jump;
    public int donuts = 0;
    private bool grounded = false;
    private Rigidbody2D rigidBody;

    private void Start()
    {
        this.rigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        locked = false;
    }


    private void Die()
    {
        foreach (var player in GameObject.FindGameObjectsWithTag("Player"))
            player.GetComponent<Player>().rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        gameOverPanel.SetActive(true);
        locked = true;
    }


    public void Restart()
    {
        locked = false;
        SceneManager.LoadScene(0);
    }


    private void Move()
    {
        var move = 0;

        if (Input.GetKey(right))
            move += 1;
        if (Input.GetKey(left))
            move -= 1;
        gameObject.transform.eulerAngles = move switch
        {
            > 0 => new Vector3(0, 0, 0),
            < 0 => new Vector3(0, 180, 0),
            _ => gameObject.transform.eulerAngles
        };
        this.rigidBody.velocity = new Vector2(move * speed, this.rigidBody.velocity.y);
        if (this.transform.position.y < -40)
            Die();
    }


    private void Jump()
    {
        if (!Input.GetKeyDown(jump) || !this.grounded)
            return;
        this.rigidBody.velocity = new Vector2(this.rigidBody.velocity.x, jumpForce);
        this.grounded = false;
    }


    private void UpdateText()
    {
        text.SetText($"{donuts}");
    }


    private void Update()
    {
        if (gameOverPanel.gameObject.active && Input.GetKeyDown(KeyCode.Return))
            Restart();
        if (locked)
            return;
        Move();
        Jump();
        UpdateText();
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Menu");
    }


    private void TakeDonut(GameObject donut)
    {
        GameObject.Destroy(donut);
        this.donuts++;
    }
    
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ground") ||
            coll.gameObject.CompareTag("Player") ||
            coll.gameObject.CompareTag("Bullet"))
            this.grounded = true;
        else if (coll.gameObject.CompareTag("Donut"))
            TakeDonut(coll.gameObject);
    }
}
