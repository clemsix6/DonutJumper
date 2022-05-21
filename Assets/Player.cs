using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject gameOverPanel;
    private int donuts = 0;
    private bool grounded = false;
    private Rigidbody2D rigidBody;

    private void Start()
    {
        this.rigidBody = this.gameObject.GetComponent<Rigidbody2D>();
    }


    private void Die()
    {
        rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        gameOverPanel.SetActive(true);
    }


    public void Restart()
    {
        SceneManager.LoadScene(0);
    }


    private void Move()
    {
        var move = 0;

        if (Input.GetKey(KeyCode.RightArrow))
            move += 1;
        if (Input.GetKey(KeyCode.LeftArrow))
            move -= 1;
        this.rigidBody.velocity = new Vector2(move * speed, this.rigidBody.velocity.y);
        if (this.transform.position.y < -10)
            Die();
    }


    private void Jump()
    {
        if (!Input.GetKeyDown(KeyCode.Space) || !this.grounded)
            return;
        this.rigidBody.velocity = new Vector2(this.rigidBody.velocity.x, jumpForce);
        this.grounded = false;
    }


    private void CameraMove()
    {
        if (Camera.main == null)
            return;
        var camera = Camera.main.transform.position;
        var target = this.gameObject.transform.position;
        var interpolation = 5f * Time.deltaTime;
        if (interpolation > 1) interpolation = 1;
        var result = Vector2.Lerp(camera, target, interpolation);

        Camera.main.transform.position = new Vector3(result.x, result.y, camera.z);
    }
    

    private void UpdateText()
    {
        text.SetText($"{donuts}");
    }


    private void Update()
    {
        Move();
        Jump();
        CameraMove();
        UpdateText();
        
        if (gameOverPanel.gameObject.active && Input.GetKeyDown(KeyCode.Return))
            Restart();
    }


    private void TakeDonut(GameObject donut)
    {
        GameObject.Destroy(donut);
        this.donuts++;
    }
    
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ground"))
            this.grounded = true;
        else if (coll.gameObject.CompareTag("Donut"))
            TakeDonut(coll.gameObject);
    }
}
