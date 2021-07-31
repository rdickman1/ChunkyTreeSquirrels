using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MeleeCooldown : MonoBehaviour
{
    public Image overlayCoolDown;
    public TMP_Text textCoolDown;
    private bool isCooldown = false;
    private float cooldownTime = 4.0f;
    private float cooldownTimer = 0f;
    public GameObject melee;
    private void Start()
    {
        textCoolDown.gameObject.SetActive(false);
        overlayCoolDown.fillAmount = 0.0f;
        melee.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UseSpell();
        }
        if(isCooldown)
        {
            ApplyCooldown();
        }
    }
    public void UseSpell()
    {
        if (isCooldown)
        {
            // false;
        }
        else
        {
            isCooldown = true;
            textCoolDown.gameObject.SetActive(true);
            cooldownTimer = cooldownTime;
            melee.SetActive(true);
            StartCoroutine(LateCall());        
        }
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(0.5f);
        melee.SetActive(false);
    }

    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer < 0.0f)
        {
            isCooldown = false;
            textCoolDown.gameObject.SetActive(false);
            overlayCoolDown.fillAmount = 0.0f;

        }
        else
        {
            textCoolDown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            overlayCoolDown.fillAmount = cooldownTimer / cooldownTime;
        }
    }
}
