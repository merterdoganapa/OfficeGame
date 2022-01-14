using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MaterialExtensions
{
    public static Material CreateMetarial(string shaderName,Color color) {
        Shader shader = Shader.Find(shaderName);
        Material newMaterail = new Material(shader);
        newMaterail.color = color;
        return newMaterail;
    }   
}
