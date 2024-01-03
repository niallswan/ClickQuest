using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        weapon.transform.position = mouseWorldPosition;
    }

}
