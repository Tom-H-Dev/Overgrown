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
        Vector3 l_newPos = Vector3.MoveTowards(transform.position, _targetPos, _moveSpeed * Time.deltaTime);

        if (_moveArea.bounds.Contains(l_newPos))
        {
            // Align the bottom of the enemy with the bottom of the collider
            l_newPos.y = _moveArea.bounds.min.y + (GetComponent<Collider>().bounds.extents.y);
            transform.position = l_newPos;
        }
        else
        {
            MoveToRandomPosition();
        }
    }

    private void MoveToRandomPosition()
    {
        float randomX = Random.Range(_moveArea.bounds.min.x, _moveArea.bounds.max.x);
        float randomZ = Random.Range(_moveArea.bounds.min.z, _moveArea.bounds.max.z);

        // Set y-coordinate to the bottom of the collider plus half the height of the enemy
        float yPos = _moveArea.bounds.min.y + (GetComponent<Collider>().bounds.extents.y);

        _targetPos = new Vector3(randomX, yPos, randomZ);
    }
}
