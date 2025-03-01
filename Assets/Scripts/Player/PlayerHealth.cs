using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{

    public static PlayerHealth instance;

    [SerializeField] int maxHealth;
    int currentHealth;

    [SerializeField] TMP_Text HealthText;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealth();
    }


    public void Damage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealth();

        if (currentHealth <= 0)
        {
            SoundManager.instance.PlayerExplosionSound();
            gameObject.SetActive(false);
            UIManager.instance.OpenGameOverPanel();
        }
    }


    void UpdateHealth()
    {
        HealthText.text = currentHealth.ToString();
    }
}
