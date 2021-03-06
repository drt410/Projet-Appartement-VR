﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalFlip : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Mesh mesh = this.GetComponent<MeshFilter>().mesh;

        Vector3[] normals = mesh.normals;

        for(int i =0; i < normals.Length; i++)
        {
            normals[i] = -1 * normals[i];
        }

        for(int i = 0; i < mesh.subMeshCount; i++)
        {
            int[] tri = mesh.GetTriangles(i);
            for (int j = 0;  j < tri.Length; j =+3)
            {
                int temp = tri[j];
                tri[j] = tri[j + 1];
                tri[j + 1] = temp;
            }
            mesh.SetTriangles(tri, i);
        }

	}

}
