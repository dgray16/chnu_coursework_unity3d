using UnityEngine;
using System.Collections;
using System.Collections.Generic;



[RequireComponent(typeof(Camera))]
public class GhostFreeRoamCamera : MonoBehaviour
{
	public float initialSpeed = 10f;
	public float increaseSpeed = 1.25f;

	public bool allowMovement = true;
	public bool allowRotation = true;

	public KeyCode forwardButton = KeyCode.W;
	public KeyCode backwardButton = KeyCode.S;
	public KeyCode rightButton = KeyCode.D;
	public KeyCode leftButton = KeyCode.A;

	public float cursorSensitivity = 0.025f;
	public bool cursorToggleAllowed = true;
	public KeyCode cursorToggleButton = KeyCode.Escape;

	private float currentSpeed = 0f;
	private bool moving = false;
	private bool togglePressed = false;

	/*private void OnEnable()
	{
		if (cursorToggleAllowed)
		{
			Screen.lockCursor = true;
			Cursor.visible = false;
		}
	}

	private void Update()
	{
		if (allowMovement)
		{
			bool lastMoving = moving;
			Vector3 deltaPosition = Vector3.zero;

			if (moving)
				currentSpeed += increaseSpeed * Time.deltaTime;

			moving = false;

			CheckMove(forwardButton, ref deltaPosition, transform.forward);
			CheckMove(backwardButton, ref deltaPosition, -transform.forward);
			CheckMove(rightButton, ref deltaPosition, transform.right);
			CheckMove(leftButton, ref deltaPosition, -transform.right);

			if (moving)
			{
				if (moving != lastMoving)
					currentSpeed = initialSpeed;

				transform.position += deltaPosition * currentSpeed * Time.deltaTime;
			}
			else currentSpeed = 0f;            
		}

		if (allowRotation)
		{
			Vector3 eulerAngles = transform.eulerAngles;
			eulerAngles.x += -Input.GetAxis("Mouse Y") * 359f * cursorSensitivity;
			eulerAngles.y += Input.GetAxis("Mouse X") * 359f * cursorSensitivity;
			transform.eulerAngles = eulerAngles;
		}

		if (cursorToggleAllowed)
		{
			if (Input.GetKey(cursorToggleButton))
			{
				if (!togglePressed)
				{
					togglePressed = true;
					Screen.lockCursor = !Screen.lockCursor;
					Cursor.visible = !Cursor.visible;
				}
			}
			else togglePressed = false;
		}
		else
		{
			togglePressed = false;
			Cursor.visible = false;
		}
	}

	private void CheckMove(KeyCode keyCode, ref Vector3 deltaPosition, Vector3 directionVector)
	{
		if (Input.GetKey(keyCode))
		{
			moving = true;
			deltaPosition += directionVector;
		}
	}*/

	List<Na> listOfLevelOneNa;
	List<Cl> listOfLevelOneCl;

	void Start(){
		Debug.LogWarning ("Hello!");

		GameObject naPrefab = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Na/Na.prefab", typeof(GameObject)) as GameObject;
		GameObject clPrefab = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Cl/Cl.prefab", typeof(GameObject)) as GameObject;

		createLevelOneOfNa (naPrefab);
		createLevelOneOfCl (clPrefab);

		setNextForLevelOneOfNa ();
		setNextForLevelOneOfCl ();

		//createLevelTwoOfNa (naPrefab);
		//createLevelTwoOfCl (clPrefab);

		//createLevelThreeOfNa (naPrefab);
		//createLevelThreeOfCl (clPrefab);
	}

	public void createLevelOneOfNa(GameObject naPrefab){
		listOfLevelOneNa = new List<Na> ();

		Na na1 = new Na ();
		na1.setX (0);
		na1.setY (0);
		na1.setZ (0);
		GameObject instantiated = na1.instantiate (naPrefab);
		na1.setInstantiated (instantiated);
		listOfLevelOneNa.Add (na1);

		Na na2 = new Na ();
		na2.setX (0);
		na2.setY (5);
		na2.setZ (0);
		instantiated = na2.instantiate (naPrefab);
		na2.setInstantiated (instantiated);
		listOfLevelOneNa.Add (na2);

		Na na3 = new Na ();
		na3.setX (10);
		na3.setY (0);
		na3.setZ (0);
		instantiated = na3.instantiate (naPrefab);
		na3.setInstantiated (instantiated);
		listOfLevelOneNa.Add (na3);

		/*instantiateAndMove(0, 0, 0, naPrefab);
		instantiateAndMove(0, 5, 0, naPrefab);
		instantiateAndMove(10, 0, 0, naPrefab);
		instantiateAndMove(10, 5, 0, naPrefab);
		instantiateAndMove(5, 2.5F, 0, naPrefab);*/
	}

	public void createLevelOneOfCl(GameObject clPrefab){
		listOfLevelOneCl = new List<Cl> ();

		Cl cl1 = new Cl ();
		cl1.setX (0);
		cl1.setY (2.5F);
		cl1.setZ (0);
		GameObject instantiated = cl1.instantiate (clPrefab);
		cl1.setInstantiated (instantiated);

		listOfLevelOneCl.Add (cl1);

		Cl cl2 = new Cl ();
		cl2.setX (5);
		cl2.setY (0);
		cl2.setZ (0);
		instantiated = cl2.instantiate (clPrefab);
		cl2.setInstantiated (instantiated);

		listOfLevelOneCl.Add (cl2);

		/*instantiateAndMove (0, 2.5F, 0, clPrefab);
		instantiateAndMove (5, 0, 0, clPrefab);
		instantiateAndMove (5, 5, 0, clPrefab);
		instantiateAndMove (10, 2.5F, 0, clPrefab);*/
	}

	public void setNextForLevelOneOfNa (){
		// TODO refactor it, so no need to call it on my own
		// TODO refactor from linesReverse to Up/Down

		Na na1 = listOfLevelOneNa [0];
		Na na2 = listOfLevelOneNa [1];
		Na na3 = listOfLevelOneNa [2];

		Cl cl1 = listOfLevelOneCl [0];
		Cl cl2 = listOfLevelOneCl [1];

		na1.getNext ().Add (cl1);
		na1.getNext ().Add (cl2);
		na1.drawLinesToNext ();

		na2.getNext ().Add (cl1);
		na2.drawLinesToNext ();

		na3.getNext ().Add (cl2);
		na3.drawLinesToNext ();


	}

	public void setNextForLevelOneOfCl(){
		Cl cl1 = listOfLevelOneCl [0];
		Cl cl2 = listOfLevelOneCl [1];

		Na na1 = listOfLevelOneNa [0];
		Na na2 = listOfLevelOneNa [1];

		cl1.getNext ().Add (na1);
		cl1.getNext ().Add (na2);
		cl1.drawLinesToNext ();

		cl2.getNext ().Add (na1);
		cl2.drawLinesToNext ();
	}

	public void createLevelTwoOfNa(GameObject naPrefab){
		/*instantiateAndMove (0, 2.5F, 5, naPrefab);
		instantiateAndMove (5, 0, 5, naPrefab);
		instantiateAndMove (5, 5, 5, naPrefab);
		instantiateAndMove (10, 2.5F, 5, naPrefab);*/
	}

	public void createLevelTwoOfCl(GameObject clPrefab){
		/*instantiateAndMove (0, 0, 5, clPrefab);
		instantiateAndMove (0, 5, 5, clPrefab);
		instantiateAndMove (5, 2.5F, 5, clPrefab);
		instantiateAndMove (10, 0, 5, clPrefab);
		instantiateAndMove (10, 5, 5, clPrefab);*/
	}

	public void createLevelThreeOfNa(GameObject naPrefab){
		/*instantiateAndMove(0, 0, 10, naPrefab);
		instantiateAndMove(0, 5, 10, naPrefab);
		instantiateAndMove(10, 0, 10, naPrefab);
		instantiateAndMove(10, 5, 10, naPrefab);
		instantiateAndMove(5, 2.5F, 10, naPrefab);*/
	}

	public void createLevelThreeOfCl(GameObject clPrefab){
		/*instantiateAndMove (0, 2.5F, 10, clPrefab);
		instantiateAndMove (5, 0, 10, clPrefab);
		instantiateAndMove (5, 5, 10, clPrefab);
		instantiateAndMove (10, 2.5F, 10, clPrefab);*/
	}
}

class Na : MonoBehaviour{
	private float x;
	private float y;
	private float z;

	private List<Cl> next;

	private GameObject instantiatedObj;

	private GameObject naCylinder = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Na/NaCylinder.prefab",
		typeof(GameObject)) as GameObject;

	public Na(){
		next = new List<Cl> ();
	}

	public GameObject instantiate(GameObject prefab){
		GameObject naObject = Instantiate(prefab) as GameObject;
		naObject.transform.position = new Vector3 (x, y, z);
		return naObject;
	}

	public void drawLinesToNext(){
		foreach (Cl item in next) {
			float newX = x - item.getX ();
			float newY = y - item.getY ();
			float newZ = z - item.getZ ();

			if ( newX < 0 ) drawLineByX (item);
			else 
				if ( newY < 0 ) drawLineByY (item);
				else
					if ( newZ < 0 ) drawLineByZ (item);

			if (newX > 0) drawLineReverseByX (item);
			else 
				if (newY > 0) drawLineReverseByY (item);
				else 
					if (newZ > 0) drawLineReverseByZ (item);
		}
	}

	private void drawLineByX(Cl next){
		GameObject naCylinder = Instantiate (getCylinder()) as GameObject;

		// All in cylinder is coming from center
		float cylinderPositionAndScale = ( next.getX () - getX () ) / 4;

		Vector3 scale = naCylinder.transform.localScale;
		scale.y = Vector3.Distance (getInstantiated().transform.position, next.getInstantiated().transform.position) / 4;

		naCylinder.transform.localScale = scale;
		naCylinder.transform.position = new Vector3 (scale.y, getY(), getZ());

		Vector3 rotation = new Vector3 (0, 0, 90);
		naCylinder.transform.Rotate (rotation);
	}

	private void drawLineReverseByX(Cl next){
		GameObject naCylinder = Instantiate (getCylinder()) as GameObject;

		// All in cylinder is coming from center

		Vector3 scale = naCylinder.transform.localScale;
		scale.y = Vector3.Distance (getInstantiated().transform.position, next.getInstantiated().transform.position) / 4;

		naCylinder.transform.localScale = scale;
		naCylinder.transform.position = new Vector3 ( (getX() - scale.y), getY(), getZ() );

		Vector3 rotation = new Vector3 (0, 0, 90);
		naCylinder.transform.Rotate (rotation);
	}

	private void drawLineByY(Cl next){
		GameObject naCylinder = Instantiate (getCylinder()) as GameObject;

		// All in cylinder is coming from center
		float cylinderPositionAndScale = ( next.getY () - getY () ) / 4;
	 
		Vector3 scale = naCylinder.transform.localScale;
		scale.y = Vector3.Distance (getInstantiated().transform.position, next.getInstantiated().transform.position) / 4;

		naCylinder.transform.localScale = scale;
		naCylinder.transform.position = new Vector3 (getX(), scale.y, getZ());
	}

	private void drawLineReverseByY(Cl next){
		GameObject naCylinder = Instantiate (getCylinder()) as GameObject;

		// All in cylinder is coming from center

		Vector3 scale = naCylinder.transform.localScale;
		scale.y = Vector3.Distance (getInstantiated().transform.position, next.getInstantiated().transform.position) / 4;

		naCylinder.transform.localScale = scale;
		naCylinder.transform.position = new Vector3 (getX(), (getY() - scale.y), getZ());
	}

	private void drawLineByZ(Cl next){
		GameObject naCylinder = Instantiate (getCylinder()) as GameObject;

		// All in cylinder is coming from center
		float cylinderPositionAndScale = ( next.getZ () - getZ () ) / 4;

		Vector3 scale = naCylinder.transform.localScale;
		scale.z = Vector3.Distance (getInstantiated().transform.position, next.getInstantiated().transform.position) / 4;

		naCylinder.transform.localScale = scale;
		naCylinder.transform.position = new Vector3 ( getX(), (getY() - scale.y), getZ() );

	}

	private void drawLineReverseByZ(Cl next){
		GameObject clCylinder = Instantiate (getCylinder()) as GameObject;

		// All in cylinder is coming from center

		Vector3 scale = clCylinder.transform.localScale;
		scale.y = Vector3.Distance (getInstantiated().transform.position, next.getInstantiated().transform.position) / 4;

		clCylinder.transform.localScale = scale;
		clCylinder.transform.position = new Vector3 (getX(), (scale.y * 3), getZ());
	}

	public float getX(){
		return x;
	}
	public void setX(float value){
		this.x = value;
	}

	public float getY(){
		return y;
	}
	public void setY(float value){
		this.y = value;
	}

	public float getZ(){
		return z;
	}
	public void setZ(float value){
		this.z = value;
	}

	public List<Cl> getNext(){
		return next;
	}

	public GameObject getCylinder(){
		return naCylinder;
	}

	public GameObject getInstantiated(){
		return instantiatedObj;
	}

	public void setInstantiated(GameObject obj){
		this.instantiatedObj = obj;
	}
}

class Cl : MonoBehaviour{
	private float x;
	private float y;
	private float z;

	private List<Na> next;

	private GameObject instantiatedObj;

	private GameObject clCylinder = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Cl/ClCylinder.prefab",
		typeof(GameObject)) as GameObject;


	public Cl(){
		next = new List<Na> ();
	}

	public GameObject instantiate(GameObject prefab){
		GameObject clObject = Instantiate(prefab) as GameObject;
		clObject.transform.position = new Vector3 (x, y, z);
		return clObject;
	}

	public void drawLinesToNext(){
		foreach (Na item in next) {
			float newX = x - item.getX ();
			float newY = y - item.getY ();
			float newZ = z - item.getZ ();

			if (newX < 0) drawLineByX (item);
			if (newY < 0) drawLineByY (item);	
			if (newZ < 0) drawLineByZ (item);

			if (newX > 0) drawLineReverseByX (item);
			if (newY > 0) drawLineReverseByY (item);
		}
	}

	private void drawLineByX(Na next){
		GameObject clCylinder = Instantiate (getCylinder()) as GameObject;

		// All in cylinder is coming from center

		Vector3 scale = clCylinder.transform.localScale;
		scale.y = Vector3.Distance (getInstantiated().transform.position, next.getInstantiated().transform.position) / 4;

		clCylinder.transform.localScale = scale;
		clCylinder.transform.position = new Vector3 (getX(), scale.y, getZ());
	}

	private void drawLineReverseByX(Na next){
		GameObject clCylinder = Instantiate (getCylinder()) as GameObject;

		// All in cylinder is coming from center

		Vector3 scale = clCylinder.transform.localScale;
		scale.y = Vector3.Distance (getInstantiated().transform.position, next.getInstantiated().transform.position) / 4;

		clCylinder.transform.localScale = scale;
		clCylinder.transform.position = new Vector3 ( (getX() - scale.y), getY(), getZ() );

		Vector3 rotation = new Vector3 (0, 0, 90);
		clCylinder.transform.Rotate (rotation);
	}

	private void drawLineByY(Na next){
		GameObject clCylinder = Instantiate (getCylinder()) as GameObject;

		// All in cylinder is coming from center

		Vector3 scale = clCylinder.transform.localScale;
		scale.y = Vector3.Distance (getInstantiated().transform.position, next.getInstantiated().transform.position) / 4;

		clCylinder.transform.localScale = scale;
		clCylinder.transform.position = new Vector3 (getX(), (getY() - scale.y), getZ());
	}

	private void drawLineReverseByY(Na next){
		GameObject clCylinder = Instantiate (getCylinder()) as GameObject;

		// All in cylinder is coming from center

		Vector3 scale = clCylinder.transform.localScale;
		scale.y = Vector3.Distance (getInstantiated().transform.position, next.getInstantiated().transform.position) / 4;

		clCylinder.transform.localScale = scale;
		clCylinder.transform.position = new Vector3 (getX(), (getY() + scale.y), getZ());
	}

	private void drawLineByZ(Na next){
		GameObject clCylinder = Instantiate (getCylinder()) as GameObject;

	}

	private void drawLineReverseByZ(Na next){
		GameObject clCylinder = Instantiate (getCylinder()) as GameObject;

		// All in cylinder is coming from center

		Vector3 scale = clCylinder.transform.localScale;
		scale.y = Vector3.Distance (getInstantiated().transform.position, next.getInstantiated().transform.position) / 4;

		clCylinder.transform.localScale = scale;
		clCylinder.transform.position = new Vector3 (getX(), (scale.y * 3), getZ());
	}


	public float getX(){
		return x;
	}
	public void setX(float value){
		this.x = value;
	}

	public float getY(){
		return y;
	}
	public void setY(float value){
		this.y = value;
	}

	public float getZ(){
		return z;
	}
	public void setZ(float value){
		this.z = value;
	}

	public List<Na> getNext(){
		return next;
	}

	public GameObject getCylinder(){
		return clCylinder;
	}

	public GameObject getInstantiated(){
		return instantiatedObj;
	}

	public void setInstantiated(GameObject obj){
		this.instantiatedObj = obj;
	}

}
