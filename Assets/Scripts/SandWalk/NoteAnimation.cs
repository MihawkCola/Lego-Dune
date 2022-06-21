using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteAnimation : MonoBehaviour
{
    public void noteIsFinish() 
    {
        if (this.transform.childCount - 1 > 0) return;
            
        this.transform.GetComponentInParent<AnimationController>().nextNote();
        Destroy(this.gameObject);
    }
    
}
