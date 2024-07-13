using UnityEngine;

public class DraggableIngredient : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;
    private bool isDragging = false;
    private Camera mainCamera;

    void Start()
    {
        // 카메라를 찾는 방법 개선
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found! Please ensure there is a camera tagged as 'MainCamera' in the scene.");
            enabled = false; // 스크립트 비활성화
            return;
        }
    }

    void OnMouseDown()
    {
        if (mainCamera == null) return;

        zCoord = mainCamera.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPos();
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (isDragging && mainCamera != null)
        {
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    private Vector3 GetMouseWorldPos()
    {
        if (mainCamera == null) return Vector3.zero;

        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }
}