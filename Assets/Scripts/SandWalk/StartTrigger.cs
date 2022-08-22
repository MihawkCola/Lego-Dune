using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    private SandWalk sandWalk;

    private EnemyController enemyController;

    private void Start()
    {
        sandWalk = this.transform.parent.GetComponent<SandWalk>();
        this.enemyController = GameObject.Find("EnemyManager").GetComponent<EnemyController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        sandWalk.StartGame();
        enemyController.isStart = true;
        Destroy(this.gameObject);
    }
}
