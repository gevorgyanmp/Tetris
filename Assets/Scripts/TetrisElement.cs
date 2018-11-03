using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TetrisElement : MonoBehaviour {

    public float fall = 0;
    public float speed = 1;
    public bool canRotate = true;
    public bool limitRotate = false;

    

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (CheckCurPos() == false)
            {
                transform.position += new Vector3(1, 0, 0);
            }
            else
            {
                GameController.instance.gridController.GridUpdate(this);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (CheckCurPos() == false)
            {
                transform.position += new Vector3(-1, 0, 0);
            }
            else
            {
                GameController.instance.gridController.GridUpdate(this);
            }

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (canRotate)
            {
                if (limitRotate)
                {
                    if (transform.rotation.eulerAngles.z >= 90)
                    {
                        transform.Rotate(0, 0, -90);
                    }
                    else
                    {
                        transform.Rotate(0, 0, 90);
                    }
                }
                else
                {
                    transform.Rotate(0, 0, 90);
                }

                if (CheckCurPos() == false)
                {
                    if(limitRotate)
                    {
                        if (transform.rotation.eulerAngles.z >= 90)
                        {
                            transform.Rotate(0, 0, -90);
                        }
                        else
                        {
                            transform.Rotate(0, 0, 90);
                        }
                    }
                    else
                    {
                        transform.Rotate(0, 0, -90);
                    }
                }
                else
                {
                    GameController.instance.gridController.GridUpdate(this);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - fall >= speed)
        {
            transform.position += new Vector3(0, -1, 0);

            if (CheckCurPos() == false)
            {
                transform.position += new Vector3(0, 1, 0);

                enabled = false;
                GameController.instance.gridController.CheknDelete();
                GameController.instance.spawnController.spawn();
            }
            else
            {
                GameController.instance.gridController.GridUpdate(this);
            }

            fall = Time.time;

        }
    }

    public bool CheckCurPos()
    {
        foreach (Transform element in transform)
        {
            Vector2 pos = GameController.instance.gridController.vecRound(element.position);

            if(GameController.instance.gridController.IsInsideGrid(pos) == false)
            {
                return false;
            }
            if (GameController.instance.gridController.GetTransformFromPos(pos) != null && GameController.instance.gridController.GetTransformFromPos(pos).parent != transform )
            {
                return false;
            }
        }
        return true;
    }
}
