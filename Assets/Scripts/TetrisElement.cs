using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TetrisElement : MonoBehaviour {

    public float Fall = 0;
    public float Speed = 1;
    public bool CanRotate = true;
    public bool LimitRotate = false;

    private float _continousVerticalSpeed = 0.05f;
    private float _continuesHorizontalSpeed = 0.1f;

    private float _verticalTimer = 0;
    private float _horizontalTimer = 0;
    

	void Update ()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) ||
            Input.GetKeyUp(KeyCode.DownArrow))
        {
            _horizontalTimer = 0;
            _verticalTimer = 0;
        }

        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (_horizontalTimer < _continuesHorizontalSpeed)
            {
                _horizontalTimer += Time.deltaTime;
                return;
            }

            _horizontalTimer = 0;
            transform.position += new Vector3(-1, 0, 0);
            if (CheckCurPos() == false)
            {
                transform.position += new Vector3(1, 0, 0);
            }
            else
            {
                GameController.Instance.GridController.GridUpdate(this);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (_horizontalTimer < _continuesHorizontalSpeed)
                {
                    _horizontalTimer += Time.deltaTime;
                    return;
                }
            
            _horizontalTimer = 0;
            transform.position += new Vector3(1, 0, 0);
            if (CheckCurPos() == false)
            {
                transform.position += new Vector3(-1, 0, 0);
            }
            else
            {
                GameController.Instance.GridController.GridUpdate(this);
            }

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (CanRotate)
            {
                if (LimitRotate)
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
                    if(LimitRotate)
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
                    GameController.Instance.GridController.GridUpdate(this);
                }
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Time.time - Fall >= Speed)
        {

            if (_verticalTimer < _continousVerticalSpeed)
            {
                _verticalTimer += Time.deltaTime;
                return;
            }

            _verticalTimer = 0;
            transform.position += new Vector3(0, -1, 0);

            if (CheckCurPos() == false)
            {
                transform.position += new Vector3(0, 1, 0);

                if (GameController.Instance.GridController.IsOutOfGrid(this) == true)
                {
                    GameController.Instance.UiController.GameOver();
                }

                enabled = false;
                GameController.Instance.GridController.CheknDelete();
                GameController.Instance.SpawnController.spawn();
            }
            else
            {
                GameController.Instance.GridController.GridUpdate(this);
            }

            Fall = Time.time;

        }
    }

    public bool CheckCurPos()
    {
        foreach (Transform element in transform)
        {
            Vector2 pos = GameController.Instance.GridController.vecRound(element.position);

            if(GameController.Instance.GridController.IsInsideGrid(pos) == false)
            {
                return false;
            }
            if (GameController.Instance.GridController.GetTransformFromPos(pos) != null && GameController.Instance.GridController.GetTransformFromPos(pos).parent != transform )
            {
                return false;
            }
        }
        return true;
    }
}
