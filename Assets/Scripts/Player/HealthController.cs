using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public Transform[] health;

    private PlayerInput inputs;

    private HealthScript[] healthScript;

    private EnemyController enemyController;
    void Start()
    {
        inputs = GameObject.Find("PlayerInput").GetComponent<InputScript>().getPlayerInput();
        this.enemyController = GameObject.Find("EnemyManager").GetComponent<EnemyController>();

        this.healthScript = new HealthScript[health.Length];
        for (int i = 0; i < health.Length; i++) 
        { 
            this.healthScript[i] = this.health[i].GetComponent<HealthScript>();
        }
    }
    public bool decreaseHealthAll(DamageTyp damageTyp) 
    {
        Debug.Log("test");
        bool allDeath = true;
        bool checkSwitch = true;

        // sonderfall wenn beide nur noch ein leben haben
        bool bothDeath = true;
        foreach (HealthScript health in this.healthScript)
            bothDeath = bothDeath & health.health == 1;
        if(bothDeath)
            checkSwitch = false;
        //

        foreach (HealthScript health in this.healthScript)
            allDeath = allDeath & health.decreaseHealth(damageTyp, checkSwitch);

        return allDeath;
    }
    public bool isOneDeath() {
        bool oneDeath = false;
        foreach (HealthScript health in this.healthScript)
            oneDeath = oneDeath || health.isDeath();
        return oneDeath;
    }
    public bool allDeath()
    {
        bool allDeath = true;
        foreach (HealthScript health in this.healthScript)
            allDeath = allDeath && health.isDeath();
        return allDeath;
    }

    public void gameover()
    {
        inputs.Player.Disable();
        enemyController.disableAll();
    }
}
