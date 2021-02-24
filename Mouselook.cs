using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Mouselook : MonoBehaviour
{
    public Slider Slider;
    public static float mouseSensitivity = 80;
    private float xRotation;
    public bool isInMenu = false;
 
    public Transform playerbody;
    public TextMeshProUGUI Text;

   
    void Start()
    {
        if (isInMenu == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
    }

    public void SetSensitity()
    {
        mouseSensitivity = Slider.value;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -30f, 20f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerbody.Rotate(Vector3.up * mouseX);

        Text.text = (mouseSensitivity + "");
    }

    
}
