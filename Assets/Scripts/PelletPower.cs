using UnityEngine;

public class PelletPower : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            Destroy(gameObject);
        }
    }
}
