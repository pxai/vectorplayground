using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ball : MonoBehaviour {

	bool toggle = true;
	public int speed;
	public Slider speedSlider;
	public Text status;


	// Use this for initialization
	void Start () {
		speed = 1;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 previous = this.GetComponent<Rigidbody2D>().velocity;
		Vector3 direction = previous;

				if (Input.GetKeyDown(KeyCode.Space)) {
					if (toggle) {
						direction = new Vector3(1,1);
					} else {
						direction = Vector3.back;
					}
					toggle = !toggle;
				}
				if (Input.GetKeyDown(KeyCode.Keypad8)) {
					direction = Vector3.up;
				}
				if (Input.GetKeyDown(KeyCode.Keypad4)) {
					direction = Vector3.left;
				}
				if (Input.GetKeyDown(KeyCode.Keypad6)) {
					direction = Vector3.right;
				}
				if (Input.GetKeyDown(KeyCode.Keypad2)) {
					direction = Vector3.down;
				}

				if (Input.GetKeyDown(KeyCode.Keypad7)) {
					direction =  new Vector3(-1,1,0);
				}
				if (Input.GetKeyDown(KeyCode.Keypad1)) {
					direction =  new Vector3(-1,-1,0);
				}
				if (Input.GetKeyDown(KeyCode.Keypad9)) {
					direction =  new Vector3(1,1,0);
				}
				if (Input.GetKeyDown(KeyCode.Keypad3)) {
					direction =  new Vector3(1,-1,0);
				}

		if (previous.x != direction.x || previous.y != direction.y ) {

			this.GetComponent<Rigidbody2D>().velocity = direction * speed;
			Debug.Log (this.GetComponent<Rigidbody2D>().velocity.ToString () + ". Speed: " + speed);
			status.text = this.GetComponent<Rigidbody2D>().velocity.ToString () + ". Speed: " + speed;
		}
	}

	public void OnSliderChanged() {
		speed = (int) speedSlider.value;
		this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity.normalized * speed;

		status.text = this.GetComponent<Rigidbody2D>().velocity.ToString () + ". Changed speed to " + speed;
		Debug.Log ("Changed speed to " + speed);
	}
}
