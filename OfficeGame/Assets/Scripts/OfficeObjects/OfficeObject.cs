using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OfficeObjects
{
    public class OfficeObject : MonoBehaviour
    {
        protected MeshRenderer meshRenderer;
        protected Material defaultMaterial;

        public virtual void Awake()
        {
            if (GetComponent<MeshRenderer>() != null)
            {
                meshRenderer = GetComponent<MeshRenderer>();
                defaultMaterial = meshRenderer.material;
            }
        }
        protected void SetMeshMaterial(Material material)
        {
            if(meshRenderer)
                meshRenderer.material = material;
        }

        protected void ResetMeshMaterial() {
            if(meshRenderer)
                meshRenderer.material = defaultMaterial;
        }
    }
}
