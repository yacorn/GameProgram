using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controll : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] ForceMode forceMode;
    [SerializeField] UnityEngine.Vector3 direction;
    // 처음 시작 위치
    private UnityEngine.Vector3 startPos;
    private bool initCommand = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        forceMode = ForceMode.Force;
        startPos = transform.position;
        speed = 5f;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        if(Keyboard.current != null)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                initCommand = true;   
            }
        }
    }

    void FixedUpdate()
    {
        if (initCommand)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.position = startPos;
            initCommand = false;
        } 
        else
        {
            UnityEngine.Vector3 movement = new UnityEngine.Vector3(direction.x, 0f, direction.z).normalized;
            rb.AddForce(movement * speed, forceMode);    
        }
        
    }
}
