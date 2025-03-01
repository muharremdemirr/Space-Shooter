using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] AudioSource mouseClick;
    [SerializeField] AudioSource enemyExplosion;
    [SerializeField] AudioSource meteorExplosion;
    [SerializeField] AudioSource playerExplosion;

    private void Awake()
    {
        instance = this;
    }

    public void MouseClickSound()
    {
        mouseClick.Play();
    }
    public void EnemyExplosionSound()
    {
        enemyExplosion.Play();
    }
    public void MeteorExplosionSound()
    {
        meteorExplosion.Play();
    }
    public void PlayerExplosionSound()
    {
        playerExplosion.Play();
    }

}
