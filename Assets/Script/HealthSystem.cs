using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : Singleton<HealthSystem>
{
    //variables
    [SerializeField] int maxHealth;
    int currentHealth;

    [SerializeField] Image HealthBar;

    //properties
    protected override bool persistent => false;
    public int CurrentHealth
    {
        get => currentHealth;

        set
        {
            currentHealth = value;
            HealthBar.fillAmount = (float)currentHealth/maxHealth;
            if (currentHealth <= 0)
            {
                die();
            }
        }
    }
    //methods
    private void Start()
    {
        currentHealth = maxHealth;
    }

    void die()
    {

    }

}
