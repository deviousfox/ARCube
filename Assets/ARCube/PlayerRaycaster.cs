using ARCubeBlock;
using UnityEngine;

public class PlayerRaycaster : MonoBehaviour
{
    [SerializeField] private Camera cam;

    private void Awake()
    {
        cam ??= Camera.main;
    }

    void Update()
    {
        //It would be possible to use OnMoseClick in BlockComponent
        //but I think it's better to separate user input from strictly speaking data
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            Physics.Raycast(ray, out hit);

            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent(out BlockComponent block))
                {
                    block.Collect();
                }
            }
        }
    }
}