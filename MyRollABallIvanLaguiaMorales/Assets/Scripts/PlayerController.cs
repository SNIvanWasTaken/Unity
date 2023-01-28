using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour {

	// Create public variables for player speed, and for the Text UI game objects
	float velocidadAvance = 2.0f;
	float velocidadAvanceZ = 6.0f;
	public float salto = 5;
	public Text countText;
	public Text winText;
	private Vector3 initialPosition;
	private AllowJump check;
	private MeshRenderer pickupMR;
	[SerializeField] Transform Explosion;

	// Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
	private Rigidbody rb;
	private int count;
	private Renderer re;

	// At the start of the game..
	void Start ()
	{
		// Assign the Rigidbody component to our private rb variable
		check = GetComponentInChildren<AllowJump>();
		rb = GetComponent<Rigidbody>();
		re = GetComponentInChildren<Renderer>();
		// Set the count to zero 
		count = 0;
		initialPosition = transform.position;

		// Run the SetCountText function to update the UI (see below)
		SetCountText ();

		// Set the text property of our Win Text UI to an empty string, making the 'You Win' (game over message) blank
		winText.text = "";
	}

    private void Update()
    {
		if (Input.GetButtonDown("Jump") && check.grounded)
        {
			rb.AddForce(Vector3.up * salto, ForceMode.Impulse);
        }
    }
    // Each physics step..
    void FixedUpdate ()
	{
		// Set some local float variables equal to the value of our Horizontal and Vertical Inputs
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
		Vector3 movement = new Vector3 (moveVertical, 0.0f, -moveHorizontal);

		// Add a physical force to our Player rigidbody using our 'movement' Vector3 above, 
		// multiplying it by 'speed' - our public player speed that appears in the inspector
		rb.AddForce (movement * velocidadAvance);
		rb.AddForce(movement * velocidadAvanceZ);
	}

	// When this game object intersects a collider with 'is trigger' checked, 
	// store a reference to that collider in a variable named 'other'..
	void OnTriggerEnter(Collider other) 
	{
		pickupMR = other.gameObject.GetComponent<MeshRenderer>();

		// ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			// Make the other game object (the pick up) inactive, to make it disappear
			other.enabled = false;
			pickupMR.enabled = false;
			Transform explosion = Instantiate(Explosion, transform.position, Quaternion.identity);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText ();

			if (transform.localScale.x <= 1.2f)
			{
				transform.localScale = new Vector3(transform.localScale.x + 0.05f, transform.localScale.y + 0.05f, transform.localScale.z + 0.05f);
			}
		}
	}

	// Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
	void SetCountText()
	{
		// Update the text field of our 'countText' variable
		countText.text = "Count: " + count.ToString ();

		// Check if our 'count' is equal to or exceeded 12
	}
    private void OnCollisionEnter(Collision collision)
    {
		if (collision.gameObject.CompareTag("Wall"))
		{
			re.material.color = new Color(Random.value, Random.value, Random.value);
			if (transform.localScale.x >= 0.8f)
			{
				transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
			}
		}
        if (collision.gameObject.CompareTag("RedWall"))
        {
			winText.text = "You have collected " + count + " pickups!";
		}
	}
	public void Restore()
    {
		transform.position = initialPosition;
		winText.text = "";
    }
}