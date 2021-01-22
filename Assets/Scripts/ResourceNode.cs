using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class ResourceNode : ToolHit
{
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] float spread = 0.05f;

    [SerializeField] Item item;
    [SerializeField] int intemCountInOneDrop = 1;
    [SerializeField] int dropCount = 5;
    [SerializeField] ResourceNodeType nodeType;
    [SerializeField] int hp;

    public override void Hit()
    {
        hp--;
        if(hp<0)
        {
            while (dropCount > 0)
            {
                dropCount -= 1;

                Vector3 position = transform.position;
                position.x += spread * (UnityEngine.Random.value - 0.5f);
                position.y += spread * (UnityEngine.Random.value - 0.5f);
                GameObject go = Instantiate(pickUpDrop);
                go.transform.position = position;

            }
            Destroy(gameObject);
        }
        Debug.Log("hit");
    }

    public override bool CanBeHit(List<ResourceNodeType> canBeHit)
    {
        return canBeHit.Contains(nodeType);
    }
}
