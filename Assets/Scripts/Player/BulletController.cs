using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] GameObject effect;

    private void Update()
    {

        transform.Translate(Vector3.up * speed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("Meteor"))
        {
            SoundManager.instance.MeteorExplosionSound();
            GameObject part = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(part, 1f);
        }
        
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
