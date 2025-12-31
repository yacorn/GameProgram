using UnityEngine;
using UnityEngine.InputSystem;

public class Mouse : MonoBehaviour
{
    [SerializeField] Ray ray;
    [SerializeField] RaycastHit raycastHit;
    [SerializeField] float duration;

    private Camera mainCam;

    void Awake()
    {
        mainCam = Camera.main;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Legacy
        // if (Input.GetMouseButtonDown(0))
        // {
        //     ray = mainCam.ScreenPointToRay(Input.mousePosition);
            
        //     if(Physics.Raycast(ray, out raycastHit, Mathf.Infinity))
        //     {
        //         Debug.DrawLine(ray.origin, raycastHit.point, Color.green, duration); 
        //     }
        // }

        // New Input System
        if (UnityEngine.InputSystem.Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = UnityEngine.InputSystem.Mouse.current.position.ReadValue();
            ray = mainCam.ScreenPointToRay(mousePos);
            if(Physics.Raycast(ray, out raycastHit, Mathf.Infinity))
            {
                Debug.DrawLine(ray.origin, raycastHit.point, Color.red, duration);

                if(raycastHit.collider.TryGetComponent<Equipment>(out Equipment equipment))
                {
                    equipment.OnHit();
                }
            }
        }
    }
}
