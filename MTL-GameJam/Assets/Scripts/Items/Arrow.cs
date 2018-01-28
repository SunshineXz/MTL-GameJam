using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public Direction direction;
    public Vector2 Position;

    public Arrow()
    {
        Position = Vector2.zero;
    }

    // Use this for initialization
    void Start()
    {
        transform.position = Position * 1.6f;
        if (direction == Direction.Down)
        {
            transform.Rotate(new Vector3(0, 0, -90));
        }
        else if (direction == Direction.Up)
        {
            transform.Rotate(new Vector3(0, 0, 90));
        }
        else if (direction == Direction.Left)
        {
            transform.Rotate(new Vector3(0, 0, 180));
        }
        else if (direction == Direction.Right)
        {
            transform.Rotate(new Vector3(0, 0, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, Position * 1.6f, 0.2f);

        if (Vector2.Distance(transform.position, Position * 1.6f) > 0.1f)
        {
            return;
        }

        Vector2 nextPosition = Position;
        if (direction == Direction.Down)
        {
            nextPosition.y--;
        }
        else if (direction == Direction.Up)
        {
            nextPosition.y++;
        }
        else if (direction == Direction.Left)
        {
            nextPosition.x--;
        }
        else if (direction == Direction.Right)
        {
            nextPosition.x++;
        }

        Tile tile = WorldManager.instance.GetTileAtPosition(nextPosition);
        if(tile)
        {
            float dis = Vector2.Distance(tile.transform.position, transform.position);
            if ((tile.TileType == TileTypeEnum.Wall || tile.Target != null)  && dis < 1.7f)
            {
                Destroy(this.gameObject);
                if(tile.Target != null)
                {
                    tile.Target.ActiveBridge();
                }
            }
            else
            {
                Position = nextPosition;
            }
        }
        else
        {
            float dis = Vector2.Distance(nextPosition * 1.6f, transform.position);
            if(dis < 1.7f)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Position = nextPosition;
            }
        }
    }
}