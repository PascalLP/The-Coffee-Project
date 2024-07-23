using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    // Mouse Buttons
    public static class BtnMouse
    {
        public static int primary = 0;
        public static int secondary = 1;
        public static int middle = 2;
    }

    public Camera cam = null;
    public GameObject target = null;
    private Vector3 previousPosition;
    private Vector3 camDistance;

    private void Start()
    {
        camDistance = target.transform.position - cam.transform.position;
    }
    void Update()
    {
        // Starting mouse drag on click
        if (Input.GetMouseButtonDown(BtnMouse.primary) == true)
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            //previousPosition = cam.transform.position;
            //camDistance = target.transform.position - cam.transform.position;
        }

        // Rotating camera
        if (Input.GetMouseButton(BtnMouse.primary) == true)
        {
            Vector3 direction = previousPosition - cam.ScreenToViewportPoint(Input.mousePosition);

            // Using Space.World to keep y-axis straight
            cam.transform.position = target.transform.position;
            cam.transform.Rotate(Vector3.right, direction.y * 180f);
            cam.transform.Rotate(Vector3.up, -direction.x * 180f, Space.World);
            cam.transform.Translate(new Vector3(0f, 0f, -camDistance.z));

            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
    }

}
