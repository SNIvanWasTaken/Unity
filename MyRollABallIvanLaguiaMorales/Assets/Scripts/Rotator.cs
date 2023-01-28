using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	private Vector3 initialPosition;
	private Renderer re;
	private Vector3 giro;
	MeshRenderer mr;
	BoxCollider bc;

	// Before rendering each frame..
	void Update () 
	{
		transform.Rotate(giro * Time.deltaTime);
	}
    private void Start()
    {
		mr = GetComponent<MeshRenderer>();
		bc = GetComponent<BoxCollider>();

		re = GetComponent<Renderer>();
		giro = new Vector3(Mathf.Round(Random.Range(0, 90)), Mathf.Round(Random.Range(0, 90)), Mathf.Round(Random.Range(0, 90)));
		initialPosition = transform.position;
		StartCoroutine(ChangeColors());
	}
	public void Restore()
    {
		transform.position = initialPosition;
		mr.enabled = true;
		bc.enabled = true;
	}
	private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
			re.material.color = new Color(Random.value, Random.value, Random.value);
		}
	}
	public IEnumerator ChangeColors()
    {
		yield return new WaitForSeconds(1.5f);
		re.material.color = new Color(Random.value, Random.value, Random.value);
		StartCoroutine(ChangeColors());
	}
}	