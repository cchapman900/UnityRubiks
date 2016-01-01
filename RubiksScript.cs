using UnityEngine;
using System.Collections;

//Class to control rubik's cube rotation
public class RubiksScript : MonoBehaviour 
{
	//Public Variables
	public GameObject rubiks;
	//Private Variables
	private GameObject[] cubes;
	private GameObject[] face;
	private GameObject rightPivot;
	private int i;
	
	// Use this for initialisation
	void Start () 
	{
		//All cubes tagged as Cube
		cubes = GameObject.FindGameObjectsWithTag("Cube");
		//9 cubes per face
		face = new GameObject[9];
		//Call RotateRight function
		RotateRight();
	}
	
	//Rotate the right face
	void RotateRight()
	{
		//Reset Counter
		i = 0;
		//Create new pivot point
		rightPivot = new GameObject("rightPivot");
		//(2,1,1) is the center of my pivot point, this will change depending on rubiks cube size and individual cube size.
		//For this example I used 1 unit per cube
		//This point is also not world space relative, you would have to add the word space vector of the entire cube first.
		rightPivot.transform.position = new Vector3(2,0,0);
		//Set the parent of the transform to the entire cube
		//This way if you rotate the entire cube the faces and the cubes inside them will follow this rotation
		rightPivot.transform.parent = rubiks.transform;
		//Find right face cubes and set rightPivot as their parent
		foreach(GameObject cube in cubes)
		{
			if(cube.transform.position.x == 2)
			{
				cube.transform.parent = rightPivot.transform;
				cube.name = "Right Face Cube";
				face[i] = cube;
				i++;
			}
		}
	}
	
	//Perform rotation gradually (To prove concept)
	void Update()
	{
		rightPivot.transform.RotateAround(rightPivot.transform.position,Vector3.right,Time.deltaTime*50);
	}
}