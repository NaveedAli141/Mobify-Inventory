using UnityEngine;
using System.Linq;

public class ColorOnHover : MonoBehaviour {

	public Color color;
	public Renderer meshRenderer;

	Color[] originalColours;

	void Start() {
		if (meshRenderer == null) {
			meshRenderer = GetComponent<MeshRenderer> ();
		}
		originalColours = meshRenderer.materials.Select (x => x.color).ToArray ();
	}
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
			OnFocus();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
			OnDeFocus();
        }
    }
    void OnFocus ()
	{
		foreach (Material mat in meshRenderer.materials) {
			mat.color *= color;
		}

	}

	void OnDeFocus()
	{
		for (int i = 0; i < originalColours.Length; i++) {
			meshRenderer.materials [i].color = originalColours [i];
		}
	}

}
