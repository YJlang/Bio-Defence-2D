using UnityEngine;

public class DraggableIngredient : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;
    private bool isDragging = false;
    private Camera mainCamera;

    void Start()
    {
        // ī�޶� ã�� ��� ����
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found! Please ensure there is a camera tagged as 'MainCamera' in the scene.");
            enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ
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