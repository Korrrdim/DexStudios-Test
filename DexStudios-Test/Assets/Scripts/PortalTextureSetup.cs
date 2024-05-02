using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
	[SerializeField] private Camera _cameraA;
	[SerializeField] private Camera _cameraB;

	[SerializeField] private Material _cameraMatA;
	[SerializeField] private Material _cameraMatB;

	private void Start()
	{
		if (_cameraA.targetTexture != null)
		{
			_cameraA.targetTexture.Release();
		}
		_cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		_cameraMatA.mainTexture = _cameraA.targetTexture;

		if (_cameraB.targetTexture != null)
		{
			_cameraB.targetTexture.Release();
		}
		_cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		_cameraMatB.mainTexture = _cameraB.targetTexture;
	}

}
