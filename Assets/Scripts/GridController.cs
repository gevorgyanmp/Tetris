using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public static int width = 10;
    public static int height = 20;

    public static Transform[,] grid = new Transform[width, height];

    public bool IsRowFull(int y)
    {
        for(int x = 0; x < width; x++)
        {
            if(grid[x,y] == null)
            {
                return false;
            }
        }
        return true;
    }

    public void DeleteRow(int y)
    {
        for (int x = 0; x < width; x++)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    public void PullDown(int y)
    {
        for(int i = y; i < height; i++)
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[x, i] != null)
                {
                    grid[x, i - 1] = grid[x, i];
                    grid[x, i] = null;
                    grid[x, i - 1].position += new Vector3(0, -1, 0);
                }
            }
        }
    }

    public void CheknDelete()
    {
        for(int y = 0; y < height; y++)
        {
            if(IsRowFull(y))
            {
                DeleteRow(y);
                PullDown(y);
                GameController.instance.scoreController.IncreaseScore();
                y--;
            }
        }
    }

    public void GridUpdate(TetrisElement tetris)
    {
        for(int y = 0; y < height; y++ )
        {
            for(int x = 0; x < width; x++)
            {
                if(grid[x,y] != null)
                {
                    if(grid[x,y].parent == tetris.transform)
                    {
                        grid[x, y] = null;
                    }
                }
            }
        }

        foreach(Transform element in tetris.transform)
        {
            Vector2 pos = vecRound(element.position);

            if(pos.y < height)
            {
                grid[(int)pos.x, (int)pos.y] = element;
            }

        }
    }

    public Transform GetTransformFromPos(Vector2 pos)
    {
        if (pos.y > height - 1)
        {
            return null;
        }
        else
        {
            return grid[(int)pos.x, (int)pos.y];
        }
    }
    

    public bool IsInsideGrid(Vector2 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x < width && (int)pos.y >= 0);
    }

    public Vector2 vecRound(Vector2 pos)
    {
       return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }

    public bool IsOutOfGrid(TetrisElement tetris)
    {
        for(int x = 0; x < width; x++)
        {
            foreach(Transform el in tetris.transform)
            {
                Vector2 pos = vecRound(el.position);
                if( pos.y > height -2)
                {
                    Debug.Log("true");
                    return true;
                }
            }
        }
        Debug.Log("false");

        return false;
    }

    

    public void Initialisation()
    {

    }
}
