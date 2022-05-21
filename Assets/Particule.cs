using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particule : MonoBehaviour
{
    [SerializeField] private float time = 0;
    
    IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(time);
        Destroy(this.gameObject);
    }
}
