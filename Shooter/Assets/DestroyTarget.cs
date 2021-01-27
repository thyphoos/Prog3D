using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class DestroyTarget : MonoBehaviour
    {
        private const float lifespan = 30f;
        private float timer = 0f;

        public void Start()
        {
            Coroutine coroutine = StartCoroutine(DestroyIn30Seconds()); 
            StopCoroutine(coroutine);
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if(timer >lifespan) Destroy(gameObject);
        }
        
        private IEnumerator DestroyIn30Seconds()
        {
            yield return new WaitForSeconds(30f);
            Destroy(gameObject);
            
        }

    }
}