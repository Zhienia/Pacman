using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Ghost : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Movement move;
    private Vector2 direction = Vector2.right;
    private bool animationStart;
    private float timer = 10.0f;
    private float startTime = 0f;
    private Vector2 vector = Vector2.right;
    private bool stopMove = false;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        move = gameObject.GetComponent<Movement>();
    }

    private void Update()
    {
        if (!this.stopMove)
        {
            move.SetDirection(direction);
        }
        

        if (this.animationStart)
        {
            OnBlueAnimation();

            startTime += Time.deltaTime;

            if (startTime >= timer)
            {
                OffBlueAnimation();
                animationStart = false;
                startTime = 0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Node"))
        {
            stopMove = true;
            direction = NewDirectiom();
        }
    }

    public void StartAnimation(bool animationStart)
    {
        this.animationStart = animationStart;
    }

    private void OnBlueAnimation()
    {
        spriteRenderer.color = new Color(255, 255, 255, 255);
        animator.SetBool("BlueGhost", true);   
    }

    private void OffBlueAnimation()
    {
        animator.SetBool("BlueGhost", false);
        spriteRenderer.color = originalColor;
    }

    private Vector2 NewDirectiom()
    {
        while (vector == direction)
        {
            int side = Random.Range(1, 4);
            switch (side)
            {
                case 1:
                    vector = Vector2.down;
                    break;
                case 2:
                    vector = Vector2.up;
                    break;
                case 3:
                    vector = Vector2.left;
                    break;
                case 4:
                    vector = Vector2.right;
                    break;
            }
        }

        stopMove = false;
        
        return vector;
    }
}
