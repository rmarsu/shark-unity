using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxGFX : MonoBehaviour
{
    [SerializeField] Transform followingTarget;
    [SerializeField] float Parallax = 0.1f;
    Vector3 targetPreviousPosition;
    // Start is called before the first frame update
    void Start()
    {
        if (!followingTarget)
            followingTarget = Camera.main.transform;

        targetPreviousPosition = followingTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        var delta = followingTarget.position - targetPreviousPosition;

        delta.y = 0;
        targetPreviousPosition = followingTarget.position;
        transform.position += delta * Parallax;
    }
}
