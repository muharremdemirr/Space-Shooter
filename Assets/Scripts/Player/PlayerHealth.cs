using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{

    public static PlayerHealth instance;

    [SerializeField] int maxHealth;
    int currentHealth;
    int score = 0;

    [SerializeField] TMP_Text HealthText;
    [SerializeField] TMP_Text ScoreText;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        currentHealth = maxHealth;
        UpdateUIBar();
    }

    public void Score(int score)
    {
        this.score += score;
        UpdateUIBar();
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateUIBar();

        if (currentHealth <= 0)
        {
            SoundManager.instance.PlayerExplosionSound();
            gameObject.SetActive(false);
            UIManager.instance.OpenGameOverPanel();
        }
    }


    void UpdateUIBar()
    {
        HealthText.text = currentHealth.ToString();
        ScoreText.text = score.ToString();

    }


    public int GetScore()
    {
        return score;
    }
}
