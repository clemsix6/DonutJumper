using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    [SerializeField] private GameObject secondPlayer;
    private GameObject[] players;
    public static bool multiplayer = false;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        if (multiplayer)
            secondPlayer.SetActive(true);
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

        return middle / players.Length;
    }


    private void Move()
    {
        var target = GetMiddle();
        var interpolation = 5f * Time.deltaTime;
        if (interpolation > 1) interpolation = 1;
        var position = transform.position;
        var result = Vector2.Lerp(position, target, interpolation);
        position = new Vector3(result.x, result.y, position.z);
        transform.position = position;
    }

    private void Update()
    {
        Move();
    }
}
