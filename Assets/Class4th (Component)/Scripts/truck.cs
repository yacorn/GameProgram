using UnityEngine;

public class truck : MonoBehaviour
{
    [SerializeField] Rigidbody rigidBody;

    [SerializeField] GameObject[] wheels;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        for(int i = 0; i < wheels.Length; i++)
        {
            Debug.Log(wheels[i].name);
        }

        rigidBody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
