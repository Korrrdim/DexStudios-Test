using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public Collider LastCollider;

    [SerializeField] private float _distanceToPortal = 2f;
    [SerializeField] private Transform _portalA;
    [SerializeField] private Transform _portalB;
    private Transform _currentPortal;

    private void Awake()
    {
        int currentW = Screen.width;
        int currentH = Screen.height;

        int defaultW = 1080;
        int defaultH = 1920;

        _distanceToPortal *= Mathf.Sqrt((float)(currentW * currentH) / (defaultW * defaultH));

        _currentPortal = _portalA;
        PortalCentralising();
    }

    private void OnTriggerExit(Collider other)
    {
        if (LastCollider == other)
        {
            LastCollider = null;
            _currentPortal = _currentPortal == _portalA ? null : _portalA;
        }
    }

    public void PortalCentralising()
    {
        if (_currentPortal == null)
            return;

        Vector3 targetPos = transform.position + transform.forward * _distanceToPortal;
        _currentPortal.position = new Vector3(targetPos.x, _currentPortal.position.y, targetPos.z);

        Vector3 direction = _currentPortal.position - transform.position;
        direction.y = 0;
        Quaternion targetRot = Quaternion.LookRotation(direction, Vector3.up);

        _portalA.rotation = targetRot;
        _portalB.rotation = targetRot;
    }
}
