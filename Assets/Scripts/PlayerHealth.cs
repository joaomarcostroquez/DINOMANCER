using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    protected override void Die()
    {
        base.Die();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
