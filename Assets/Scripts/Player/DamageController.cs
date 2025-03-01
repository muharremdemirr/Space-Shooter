using UnityEngine;

public class DamageController : MonoBehaviour
{

    [SerializeField] int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.instance.Damage(damage);
            Destroy(gameObject);
        }
    }

}
