using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Attributes
    public int maxHealth = 100; //Player's Max Health
    private int maxShield = 0; //Player's Max Shield at beginning
    public int currentHealth; //Player's current Health
    public int currentShield; //Player's current Shield                                                                      
    public GameObject shield; //GameObject for the shield

    public HealthBar healthBar; //Call HealthBar Class
    public ShieldBar shieldBar; //Call ShieldBar Class
    public float shieldGain;
    public int max = 100;

    private IEnumerator coroutine;
    public float regenSpeed = 1f;
    public float regenWait = 5f;
    bool isRegen = false;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        shieldBar.SetMaxShield(maxShield);
        shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        // Test
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
        // End Test

        if (currentShield < maxShield && !isRegen)
        {
            coroutine = Regen();
            StartCoroutine(coroutine);

        }
    }

    IEnumerator Regen()
    {
        isRegen = true;
        yield return new WaitForSeconds(regenWait);

        while (currentShield < maxShield && maxShield > 0)
        {
            shield.SetActive(true);
            currentShield += (int)Mathf.Round(shieldGain); 
            shieldBar.SetShield(currentShield);
                yield return new WaitForSeconds(regenSpeed);
        }
        isRegen = false;
    }

    public void UpgradeShield (int amount)
    {
        maxShield += amount;
        if (maxShield >= max)
        {
            maxShield = max;
        }
        shieldGain = 0.1f * maxShield;
        shieldBar.SetMaxShield(maxShield);
        currentShield = maxShield;
        shieldBar.SetShield(currentShield);
    }

    
    public void TakeDamage(int damage)
    {
        if (isRegen) 
        {
            StopCoroutine(coroutine);
            isRegen = false;
        }
        if (shield.activeSelf)
        {
            currentShield -= damage;
            shieldBar.SetShield(currentShield);
            if (currentShield <= 0)
            {
                currentShield = 0;
                shield.SetActive(false);
            }
        }
        else
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
    }

    public void UpgradeHealth(int upgradeAmount)
    {
        currentHealth = upgradeAmount;
        healthBar.SetHealth(currentHealth);
    }


}
