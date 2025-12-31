using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controll : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] ForceMode forceMode;
    [SerializeField] UnityEngine.Vector3 direction;
    // 처음 시작 위치
    private UnityEngine.Vector3 startPos;
    private bool initCommand = false;
    public bool inZone = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
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
            jumpForce = 5.0f;
            initCommand = false;
        } 
        else
        {
            rb.AddForce(direction.normalized * speed, forceMode);
        }
    }

    public void Soar()
    {
        jumpForce = 0.05f;
        forceMode = ForceMode.Impulse;
        direction = Vector3.up * jumpForce;
    }

    public void Initialize()
    {
        forceMode = ForceMode.Force;
        jumpForce = 5.0f;
    }

}
