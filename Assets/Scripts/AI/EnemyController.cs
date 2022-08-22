using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject[] enemy;

    public Transform enemylist;

    private Transform spawnPoints;

    private SwitchPlayer switchPlayer;

    void Start()
    {
        enemylist = this.transform.Find("Enemys");

        spawnPoints = this.transform.Find("SpawnPoint");

        switchPlayer = GameObject.Find("Players").GetComponent<SwitchPlayer>();

        spawnRandomEnemy(this.getRandomSpawn());
        disableAll();
    }
    private Vector3 getRandomSpawn() {
        return spawnPoints.GetChild((int)(Random.Range(0, spawnPoints.childCount - 1) + 0.5f)).position;
    
    }

    public void spawnRandomEnemy(Vector3 point) {

        GameObject newEnemy = Instantiate(enemy[(int)(Random.Range(0, enemy.Length-1) + 0.5f)], point, Quaternion.identity);

        newEnemy.transform.parent = this.enemylist;

        newEnemy.GetComponent<EnemyInterface>().setTarget(switchPlayer.getActivePlayer());
    }

    public void disableAll() {
        foreach (Transform child in enemylist) {
            child.GetComponent<NavMeshAgent>().enabled = false;
        }
    }
    public void enableAll()
    {
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
