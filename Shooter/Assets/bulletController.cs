using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    private const float lifespan = 3f;
    private float timer = 0f;

    private void Start()
    {
        Coroutine coroutine = StartCoroutine(DestroyIn3Seconds()); // execute en continu startcoroutine = IEenumerator
        StopCoroutine(coroutine);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > lifespan) Destroy(gameObject);
    }

    private IEnumerator DestroyIn3Seconds()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

}
