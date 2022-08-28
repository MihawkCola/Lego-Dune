using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    public GameObject[] enemy;

    public Transform enemylist;

    private Transform spawnPoints;

    private Transform targetPoint;

    private SwitchPlayer switchPlayer;

    public bool isStart = false;

    private void Awake()
    {
        enemylist = this.transform.Find("Enemys");

        spawnPoints = this.transform.Find("SpawnPoint");

        targetPoint = this.transform.Find("NPC_Cap_FINAL");
    }

    void Start()
    {
        spawnRandomEnemy(spawnPoints.position, targetPoint);
        foreach (Transform child in enemylist)
        {
            child.GetComponent<NavMeshAgent>().enabled = false;
        }
    }

    public void spawnRandomEnemy(Vector3 point, Transform target) {

        GameObject newEnemy = Instantiate(enemy[(int)(Random.Range(0, enemy.Length-1) + 0.5f)], point, Quaternion.identity);

        newEnemy.transform.parent = this.enemylist;

        newEnemy.GetComponent<EnemyInterface>().setTarget(target);
    }

    public void disableAll() {
        if (!isStart) return;
        foreach (Transform child in enemylist) {
            child.GetComponent<NavMeshAgent>().enabled = false;
        }
    }
    public void enableAll()
    {
        if (!isStart) return;
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
