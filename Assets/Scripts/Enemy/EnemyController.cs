using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float yPos;
    [SerializeField] int damage;
    [SerializeField] int score;

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
            rndY = Random.Range(-13f, transform.position.y - 1f);
            target = new Vector3(rndX, rndY, 0);
        }
        if (transform.position.y < -10f)
        {
            PlayerHealth.instance.Damage(damage);
            transform.position = new Vector3(0, yPos, 0);
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            PlayerHealth.instance.Score(score);
            SoundManager.instance.EnemyExplosionSound();
            transform.position = new Vector3(0, yPos, 0);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            transform.position = new Vector3(0, yPos, 0);
            PlayerHealth.instance.Damage(damage);
        }
    }
}
