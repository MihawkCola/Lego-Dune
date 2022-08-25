using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDestroy : MonoBehaviour
{
    [SerializeField] private GameObject buildcontroller;
    private void OnDestroy()
    {
        if (buildcontroller == null) return;
        buildcontroller.GetComponent<BuildController>().canBuild();
    }
}
