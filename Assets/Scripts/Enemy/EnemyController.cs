using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float yPos;
    [SerializeField] int damage;

    public float speed;
    bool isFirst = true;
    float rndX;
    float rndY;
    Vector3 target;
    private void FixedUpdate()
    {
        if (isFirst || transform.position == target)
        {
            isFirst = false;
            rndX = Random.Range(minX, maxX);
            rndY = Random.Range(-13f, transform.position.y);
            target = new Vector3(rndX, rndY, 0);
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

    }

    private void OnBecameInvisible()
    {
        transform.position = new Vector3(0, yPos, 0);
        PlayerHealth.instance.Damage(damage);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            SoundManager.instance.EnemyExplosionSound();
            GameManager.instance.DestroyEnemy(gameObject);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.DestroyEnemy(gameObject);
            Destroy(gameObject);
            PlayerHealth.instance.Damage(damage);
        }
    }
}
