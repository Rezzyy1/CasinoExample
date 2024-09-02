using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ����, �� ������� ����� ��������� ������
    public float smoothTime = 0.3f; // ����� �����������
    public Vector3 offset; // �������� ������ ������������ ����
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            transform.position = smoothedPosition;
        }
    }
}


