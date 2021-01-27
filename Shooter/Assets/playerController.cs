using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    
 [SerializeField] private Transform selfTransform;    
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float movementSpeed = 0.1f;
    [SerializeField] private float cameraSensibility = 0.1f;
    [SerializeField] private Transform spheresHolderTransform;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Rigidbody rb;
    
    
    private GameObject capsule;
    [SerializeField] private Transform targetHolderTransform;
    public Vector3 number;
    List<GameObject> liste = new List<GameObject>();
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(); 
        RotateCamera();
        Shoot();
        Spawn();

    }

    private void MovePlayer()
    {
       
        Vector3 cameraRight = cameraTransform.right;
        Vector3 cameraforward = cameraTransform.forward;           
        Vector3 deltaposition = new Vector3(cameraRight.x,0f,cameraRight.z) * Input.GetAxis("Horizontal") +
                                new Vector3(cameraforward.x,0f,cameraforward.z) * Input.GetAxis("Vertical");
        
        selfTransform.position += deltaposition *movementSpeed;
        
        rb.MovePosition(rb.position + deltaposition*movementSpeed);
        
    }
    public void  RotateCamera()
    {
        float pitch = Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        
        
        cameraTransform.eulerAngles += new Vector3(pitch, Input.GetAxis("Mouse X"), 0f) *cameraSensibility;    
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject sphere = (GameObject) Instantiate(Resources.Load("Sphere"), spawnPoint.transform.position,
                Quaternion.identity, spheresHolderTransform);
            sphere.GetComponent<Rigidbody>().AddForce(cameraTransform.forward * 5000f);
        }

    }
    
    private void Spawn()
    {
        if(Input.GetButtonDown("Jump"))
        {
            number = new Vector3( Random.Range(0, 20),Random.Range(5,10),Random.Range(0,20));
            capsule = (GameObject) Instantiate(Resources.Load("Capsule"), number, Quaternion.identity, targetHolderTransform);
            capsule.GetComponent<Renderer>().material.SetColor("_Color",Color.red);
            liste.Add(capsule);
        }
    }

 
    
}
