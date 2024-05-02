using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
	[SerializeField] private Transform _object;
	[SerializeField] private Transform _reciever;

	private Collider _recieverCollider;
	private Collider _collider;

    private void Awake()
    {
		_recieverCollider = _reciever.GetComponent<Collider>();
		_collider = GetComponent<Collider>();
	}

    private void OnTriggerEnter(Collider other)
	{
		if (!other.gameObject.TryGetComponent(out Player player))
			return;

		if (player.LastCollider != _collider)
		{
			player.LastCollider = _recieverCollider;
			Vector3 portalToPlayer = _object.position - transform.position;
			float rotationDiff = -Quaternion.Angle(transform.rotation, _reciever.rotation);
			rotationDiff += 180;
			_object.Rotate(Vector3.up, rotationDiff);

			Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
			_object.position = _reciever.position + positionOffset;
		}
	}
}
