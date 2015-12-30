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
	private GameObject pivotPoint;
	private int i;

	private int cubeScale = 2;
	// Axies
	private Vector3 centerPoint			= new Vector3(0,0,0);
	private Vector3 rightPivotPoint 	= new Vector3(cubeScale,0,0);
	private Vector3 leftPivotPoint		= new Vector3(-cubeScale,0,0);
	private Vector3 topPivotPoint		= new Vector3(0,cubeScale,0);
	private Vector3 bottomPivotPoint	= new Vector3(0,-cubeScale,0);
	private Vector3 frontPivotPoint		= new Vector3(0,0,cubeScale);
	private Vector3 backPivotPoint		= new Vector3(0,0,-cubeScale);
	
	// Use this for initialisation
	void Start () 
	{
		//All cubes tagged as Cube
		cubes = GameObject.FindGameObjectsWithTag("Cube");
		//9 cubes per face
		face = new GameObject[9];
		//Call Rotate function
		Rotate();
	}
	
	//Rotate the right face
	void Rotate()
	{
		//Reset Counter
		i = 0;
		//Create new pivot point
		pivotPoint = new GameObject("pivotPoint");
		//(2,1,1) is the center of my pivot point, this will change depending on rubiks cube size and individual cube size.
		//For this example I used 1 unit per cube
		//This point is also not world space relative, you would have to add the word space vector of the entire cube first.
		pivotPoint.transform.position = new Vector3(2,0,0);
		//Set the parent of the transform to the entire cube
		//This way if you rotate the entire cube the faces and the cubes inside them will follow this rotation
		pivotPoint.transform.parent = rubiks.transform;
		//Find right face cubes and set pivotPoint as their parent
		foreach(GameObject cube in cubes)
		{
			if(cube.transform.position.x == 2)
			{
				cube.transform.parent = pivotPoint.transform;
				cube.name = "Right Face Cube";
				face[i] = cube;
				i++;
			}
		}
	}
	
	//Perform rotation gradually (To prove concept)
	void Update()
	{
		pivotPoint.transform.RotateAround(pivotPoint.transform.position,Vector3.right,Time.deltaTime*50);
	}
}