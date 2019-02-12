using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFace : MonoBehaviour {

    public Mesh mesh;
    public int meshGridXSize, meshGridYSize;
    Mesh[] meshArray;


    void Start () {
        
        mesh = GetComponent<MeshFilter>().mesh;

        mesh.Clear();

        meshArray = new Mesh[meshGridXSize * meshGridYSize];
        
        /*mesh.vertices = new Vector3[] { new Vector3(-1, 0, 0), new Vector3(0, 2, 0), new Vector3(1, 0, 0) };
        mesh.triangles = new int[] { 0, 1, 2 };
        mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };*/

        mesh.vertices = new Vector3[] { new Vector3(1, 0, 0), new Vector3(0, 2, 0), new Vector3(-1, 0, 0) };
        mesh.triangles = new int[] { 0, 1, 2 };
        mesh.uv = new Vector2[] { new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, 0) };

        /*
        for (int y = 0; y < meshGridYSize; y++)
        {
            for (int x = 0; x < meshGridXSize; x++)
            {
                meshArray[y * x + x - 1] = GetComponent<MeshFilter>().mesh;
                meshArray[y * x + x - 1].Clear();
                meshArray[y * x + x - 1].vertices = new Vector3[] { new Vector3(x, 0, 0), new Vector3(0, 2 * y, 0), new Vector3(-x, 0, 0) };
                meshArray[y * x + x - 1].triangles = new int[] { 0, 1, 2 };
                meshArray[y * x + x - 1].uv = new Vector2[] { new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, 0) };
            }
        }
        */
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        mesh = GetComponent<MeshFilter>().mesh;
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            Gizmos.DrawSphere(mesh.vertices[i], .2f);
        }
    }


}
