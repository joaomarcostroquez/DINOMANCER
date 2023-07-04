using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : Health
{
    [SerializeField] private TextMeshProUGUI txHealth;
    [SerializeField] private TextMeshProUGUI txMaxHealth;

    /*public static PlayerHealth instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }*/

    protected override void Start()
    {
        base.Start();

        txHealth.text = Mathf.RoundToInt(health).ToString();
        txMaxHealth.text = " / " + Mathf.RoundToInt(maxHealth).ToString() + " +";
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Backspace))
        {
            ChangeHealth(Time.deltaTime * -10);
        }
    }

    protected override void Die()
    {
        base.Die();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    protected override void OnHealthChanged(float previousHealth)
    {
        base.OnHealthChanged(previousHealth);

        txHealth.text = Mathf.RoundToInt(health).ToString();
    }

    protected override void OnMaxHealthChanged(float previousHealth)
    {
        base.OnMaxHealthChanged(previousHealth);

        txMaxHealth.text = " / " + Mathf.RoundToInt(maxHealth).ToString() + " +";
    }
}
