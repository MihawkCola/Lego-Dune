using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNote : MonoBehaviour
{
    private void OnDestroy()
    {
        GetComponentInParent<NoteAnimation>().noteIsFinish();
    }

}
