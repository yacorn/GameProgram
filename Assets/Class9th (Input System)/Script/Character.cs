using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    [SerializeField] UnityEngine.Vector3 direction; 
    [SerializeField] float speed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
    //     Debug.Log("현재 위치" + transform.position);
    //     transform.position = new UnityEngine.Vector3(3,3,3);
    //     Debug.Log("변경된 위치" + transform.position);
    // }

    // Update is called once per frame
    void Update()
    {
        // // 새로운 입력 시스템 사용
        // if(Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        // {
        //     Debug.Log("스페이스바 눌림");
        // }

        // // 예전 입력 시스템 사용
        // if (Input.GetKeyDown(KeyCode.W))
        // {
        //     transform.position += new UnityEngine.Vector3(0,0,1);
        // }
        
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        transform.position += direction * Time.deltaTime * speed;

        Debug.Log("방향" + direction);
        
    }
}
