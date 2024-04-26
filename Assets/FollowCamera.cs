using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    Mover target;

    private void Start()
    {
        target = FindObjectOfType<Mover>();
    }

    private void Update()
    {
        transform.position = target.transform.position;
    }
}
