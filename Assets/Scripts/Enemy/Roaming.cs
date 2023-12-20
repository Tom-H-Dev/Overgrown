using UnityEngine;

public class Roaming : MonoBehaviour
{
    public Collider _moveArea;
    private float _moveSpeed = 0.5f;
    private Vector3 _targetPos;

    private void Start()
    {
        MoveToRandomPosition();
    }

    private void Update()
    {
        MoveTowardsTarget();
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPos, _moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, _targetPos) < 0.1f)
        {
            MoveToRandomPosition();
        }
    }

    private void MoveToRandomPosition()
    {
        float l_randomX = Random.Range(_moveArea.bounds.min.x, _moveArea.bounds.max.x);
        float l_randomZ = Random.Range(_moveArea.bounds.min.z, _moveArea.bounds.max.z);
        _targetPos = new Vector3(l_randomX, transform.position.y, l_randomZ);
    }
}
