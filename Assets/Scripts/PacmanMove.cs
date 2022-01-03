using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class PacmanMove : MonoBehaviour
{
    public List<GameObject> ghosts;
    private Animator animator;
    private Movement move;

    private void Start()
    {
        move = GetComponent<Movement>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        ChangeDirection();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerPellet")
        {
            foreach(GameObject ghost in ghosts)
            {
                ghost.GetComponent<Ghost>().StartAnimation(true);
            }
        }

        if (collision.gameObject.tag == "Ghost")
        {
            move.SetDirection(Vector2.zero);
            animator.SetBool("PacmanIsDead", true);

        }
    }

    private void ChangeDirection()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            this.move.SetDirection(Vector2.down);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            this.move.SetDirection(Vector2.up);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.move.SetDirection(Vector2.left);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.move.SetDirection(Vector2.right);
        }
    }

    public void DestroyPacman()
    {
        Destroy(gameObject);
    }
}
