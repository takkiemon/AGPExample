using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class GenerateFace : MonoBehaviour {

    public Mesh mesh;
    public int vertexGridXSize, vertexGridYSize;
    Vector3[] vertexArray;


    void Start () {

        mesh = new Mesh();

        vertexArray = new Vector3[vertexGridXSize * vertexGridYSize];
        int[] triangles = new int[(vertexGridXSize - 1) * (vertexGridYSize - 1) * 3];//fix number overflow (initialization of int can be a negative number, as is now)
        
        for (int y = 0; y < vertexGridYSize; y++)
        {
            for (int x = 0; x < vertexGridXSize; x++)
            {
                vertexArray[y * vertexGridXSize + x] = new Vector3(x, y, 0);
                
            }
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


        Debug.Log("vertexArray.Length: " + vertexArray.Length);
        Debug.Log("triangles.Length: " + triangles.Length);
        Debug.Log("vertexGridXSize: " + vertexGridXSize);

        StringBuilder logText = new StringBuilder();

        for (int triangleIterator = 0, vertexIterator = 0; vertexIterator < (vertexGridXSize * (vertexGridYSize - 1)); triangleIterator += 3, vertexIterator++)
        {
            logText.Append("t: " + triangleIterator + ", v: " + vertexIterator + ". ");
            if ((vertexIterator + 1) % vertexGridXSize != 0)
            {
                triangles[triangleIterator] = vertexIterator + 1;
                triangles[triangleIterator + 1] = vertexIterator + vertexGridXSize;
                triangles[triangleIterator + 2] = vertexIterator;
                logText.Append("Added Triangle[" + (vertexIterator + 1) + ", " + (vertexIterator + vertexGridXSize) + ", " + vertexIterator + "]");
            }
            else
            {
                logText.Append("else'd: t:" + triangleIterator + ", v: " + vertexIterator + ".");
            }
            logText.Append("\n");
        }
        logText.ToString();
        Debug.Log(logText);

        /*
        for (int i = 0, j = 0; i < triangles.Length; i += 3, j++)
        {
            Debug.Log("i: " + i + ", j: " + j + ".");
            triangles[i] = j;
            if (j + 1 < vertexArray.Length)
            {
                Debug.Log("1st 'if' of i: " + i);
                triangles[i + 1] = j + 1;
            }
            if (j + 2 < triangles.Length && j + vertexGridXSize < vertexArray.Length)
            {
                Debug.Log("2nd 'if' of i: " + i);
                triangles[i + 2] = j + vertexGridXSize;
                //triangles[i + 2] = j + 2;
            }
            Debug.Log("end of i: " + i + ", j: " + j + ".");
        }
        Debug.Log("testes002");
        */

        mesh.vertices = vertexArray;
        mesh.triangles = triangles;

        GetComponent<MeshFilter>().mesh = mesh;
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
