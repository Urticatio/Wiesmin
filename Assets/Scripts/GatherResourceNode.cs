using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceNodeType
{
    Undefined,
    Plant
}


[CreateAssetMenu(menuName = "Data/ToolAction/GatherResourceNode")]
public class GatherResourceNode : ToolAction
{
    [SerializeField] float sizeOfInteractableArea = 1f;
    [SerializeField] List<ResourceNodeType> canHitNodesOfType;
    public override bool OnApply(Vector2 worldPoint)
    {
        return false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(worldPoint, sizeOfInteractableArea);
        foreach (Collider2D c in colliders)
        {
            
            ToolHit hit = c.GetComponent<ToolHit>();
            if (hit != null)
            {
                if (hit.CanBeHit(canHitNodesOfType))
                {
                    hit.Hit();
                    return true;
                }
            }
        }
    return false;
    }


}
