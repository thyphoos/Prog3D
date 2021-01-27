using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DefaultNamespace
{
    
    public class TargetController : MonoBehaviour
    {
        List<GameObject> liste = new List<GameObject>();

        public void Start()
        {
            liste.Add(this.gameObject);
        }
        
        private void OnTriggerEnter(Collider other) 
        {
            foreach (GameObject cap in liste)
            {
                Renderer cubeRenderer = cap.GetComponent<Renderer>();
                cubeRenderer.material.SetColor("_Color",Color.green);
            }
            liste.Clear();
        }
    }
}
    
    

