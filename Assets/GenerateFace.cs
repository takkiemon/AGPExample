using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFace : MonoBehaviour {

    public Mesh mesh;
    public int vertexGridXSize, vertexGridYSize;
    Vector3[] vertexArray;


    void Start () {
        
        mesh = GetComponent<MeshFilter>().mesh;

        mesh.Clear();

        //vertexArray = new Mesh[vertexGridXSize * vertexGridYSize];


        /*mesh.vertices = new Vector3[] { new Vector3(-1, 0, 0), new Vector3(0, 2, 0), new Vector3(1, 0, 0) };
        mesh.triangles = new int[] { 0, 1, 2 };
        mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };*/




        /*for (int y = 0; y < meshGridYSize; y++)
        {
            for (int x = 0; x < meshGridXSize; x++)
            {
                meshArray[y * x + x - 1] = new Mesh();
                meshArray[y * x + x - 1] = GetComponent<MeshFilter>().mesh;
                //meshArray[y * x + x - 1].Clear();
                meshArray[y * x + x - 1].vertices = new Vector3[] { new Vector3(x, 0, 0), new Vector3(0, 2 * y, 0), new Vector3(-x, 0, 0) };
                meshArray[y * x + x - 1].triangles = new int[] { 0, 1, 2 };
                meshArray[y * x + x - 1].uv = new Vector2[] { new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, 0) };
            }
        }*/

        vertexArray = new Vector3[vertexGridXSize * vertexGridYSize];
        int[] triangles = new int[(vertexGridXSize - 1) * (vertexGridYSize - 1) * 2 * 3];//fix number overflow (initialization of int can be a negative number, as is now)
        
        //mesh.uv = new Vector2[(vertexGridXSize - 1) * (vertexGridYSize - 1) * 2 * 3];
        //mesh.uv = new Vector2[vertexGridXSize * vertexGridYSize];

        for (int y = 0; y < vertexGridYSize; y++)
        {
            for (int x = 0; x < vertexGridXSize; x++)
            {
                Debug.Log("index: " + (y * vertexGridXSize + x) + ", with vertexGridXSize: " + vertexGridXSize + " and vertexGridYSize: " + vertexGridYSize);
                vertexArray[y * vertexGridXSize + x] = new Vector3(x, y, 0);
                
            }
            Debug.Log("testes");
        }

        /*
        for (int ti = 0, vi = 0, x = 0; x < vertexGridXSize; x++, ti += 6, vi++)
        {
            triangles[ti] = vi;
            triangles[ti + 1] = vi + 1;
            triangles[ti + 2] = vi + 1 + vertexGridXSize;

            triangles[ti + 3] = vi + 1;
            triangles[ti + 4] = vi + 1 + vertexGridXSize;
            triangles[ti + 5] = vi + vertexGridXSize + 2;
            Debug.Log(vi + vertexGridXSize + 2);
        }
        */

        
        for (int i = 0; i < triangles.Length; i += 3)
        {
            triangles[i] = i;
            if (i + 1 < triangles.Length)
            {
                triangles[i + 1] = i + 1;
            }
            if (i + 2 < triangles.Length)
            {
                triangles[i + 2] = i + vertexGridXSize;
            }
        }
        

        mesh.vertices = vertexArray;
        mesh.triangles = triangles;
        //mesh.triangles = new int[] { 0, 1, 5, 6, 1, 5 };
        //mesh.uv = new Vector2[] { new Vector2(1, 1), new Vector2(0, 1), new Vector2(0, 0) };
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
