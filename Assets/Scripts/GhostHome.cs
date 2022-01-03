using UnityEngine;

public class GhostHome : MonoBehaviour
{
    public GameObject outside;
    public float timeForEnter = 2.0f;
    private float startTime = 0.0f;
    private Ghost ghost;
    private Movement movement;
    private GhostHome ghostHome;

    private void Start()
    {
        ghost = GetComponent<Ghost>();
        movement = GetComponent<Movement>();
        ghostHome = GetComponent<GhostHome>();
    }

    private void Update()
    {
        startTime += Time.deltaTime;

        if (startTime >= timeForEnter)
        {
            gameObject.transform.position = outside.transform.position;
            ghost.enabled = true;
            movement.enabled = true;
            ghostHome.enabled = false;
        }
    }
}
