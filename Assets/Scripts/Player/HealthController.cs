using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public Transform[] health;

    private HealthScript[] healthScript;
    // Start is called before the first frame update
    void Start()
    {
        this.healthScript = new HealthScript[health.Length];
        for (int i = 0; i < health.Length; i++) 
        { 
            this.healthScript[i] = this.health[i].GetComponent<HealthScript>();
        }
    }
    public bool decreaseHealthAll(DamageTyp damageTyp) 
    {
        bool allDeath = true;
        foreach (HealthScript health in this.healthScript)
            allDeath = allDeath & health.decreaseHealth(damageTyp);

        return allDeath;
    }
}
