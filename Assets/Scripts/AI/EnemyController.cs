using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject[] enemy;

    private Transform enemylist;

    private Transform spawnPoints;

    private SwitchPlayer switchPlayer;

    public bool isStart = false;

    private bool allEnable = false;
    private void Awake()
    {
        enemylist = this.transform.Find("Enemys");

        spawnPoints = this.transform.Find("SpawnPoint");

        switchPlayer = GameObject.Find("Players").GetComponent<SwitchPlayer>();
    }

    void Start()
    {
        spawnRandomEnemy();
        foreach (Transform child in enemylist)
        {
            child.GetComponent<NavMeshAgent>().enabled = false;
        }
    }
    private Vector3 getRandomSpawn() {
        return spawnPoints.GetChild((int)(Random.Range(0, spawnPoints.childCount - 1) + 0.5f)).position;
    
    }

    public void spawnRandomEnemy(Vector3 point) {

        GameObject newEnemy = Instantiate(enemy[(int)(Random.Range(0, enemy.Length-1) + 0.5f)], point, Quaternion.identity);

        newEnemy.transform.parent = this.enemylist;

        newEnemy.GetComponent<EnemyInterface>().setTarget(switchPlayer.getActivePlayer());
        newEnemy.GetComponent<NavMeshAgent>().enabled = allEnable;
    }

    public void spawnRandomEnemy()
    {
        spawnRandomEnemy(this.getRandomSpawn());
    }

    public void disableAll() {
        if (!isStart) return;
        allEnable = false;
        foreach (Transform child in enemylist) {
            child.GetComponent<NavMeshAgent>().enabled = false;
        }
    }
    public void enableAll()
    {
        if (!isStart) return;
        allEnable = true;
        foreach (Transform child in enemylist)
        {
            child.GetComponent<NavMeshAgent>().enabled = true;
        }
    }
    public void changeAllTarget(Transform target) {
        foreach (Transform child in enemylist)
        {
            child.GetComponent<EnemyInterface>().setTarget(target);
        }
    }
}
