using UnityEngine;

public class Collect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Debug.Log("You got the mirror");
            Destroy(gameObject);
        }
    }
}
