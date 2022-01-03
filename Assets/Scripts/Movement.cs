using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public GameObject passege_Left;
    public GameObject passege_Right;
    public GameObject connection_Left;
    public GameObject connection_Right;
    private Vector2 direction = Vector2.right;
    
    private void Update()
    {
        Move(direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Passege_Left")
        {
            gameObject.transform.position = connection_Right.transform.position;
        }

        if (collision.gameObject.tag == "Passege_Right")
        {
            gameObject.transform.position = connection_Left.transform.position;
        }
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    public void Move(Vector3 vector)
    {
        gameObject.transform.Translate(vector * speed * Time.deltaTime);
    }

    
}
