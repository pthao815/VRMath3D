using UnityEngine;

public class PCTestController : MonoBehaviour
{
    public float speed = 3f;
    public float sensitivity = 2f;
    float rotX, rotY;

    
    
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            rotX -= Input.GetAxis("Mouse Y") * sensitivity;
            rotY += Input.GetAxis("Mouse X") * sensitivity;
            rotX = Mathf.Clamp(rotX, -90f, 90f);
            transform.rotation = Quaternion.Euler(rotX, rotY, 0);
        }

        Vector3 move = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
        );
        transform.position += transform.TransformDirection(move) 
                              * speed * Time.deltaTime;
    }
}