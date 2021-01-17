using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public bool useOffsetValues;
    public float rotateSpeed;
    public Transform pivot;

    public float maxViewAngle;
    public float minViewAngle;

    public bool invertY;
    void Start()
    {
        if (!useOffsetValues)
        {
            offset = target.position - transform.position;
        }

        //Quando o jogo começar mover o pivot para onde está o jogador
        //e tornar o pivot num child do jogador
        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // LateUpdate acontece depois de update (Para a camara se mover depois do jogador)
    void LateUpdate()
    {
        //Ir buscar a posição X do rato e rodar o alvo
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0, horizontal, 0);

        //Ir buscar a posição Y do rato e rodar o pivot
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        if (invertY)
        {
            pivot.Rotate(vertical, 0, 0);
        }
        else
        {
            pivot.Rotate(-vertical, 0, 0);
        }
        

        //Limitar rotação cima/baixo da camara
        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
            //de 0 a -180 é o mesmo que 180 a 360
        }
        //315 porque 360 - 45 = 315
        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minViewAngle)
        {
            pivot.rotation = Quaternion.Euler(360f + minViewAngle, 0, 0);
        }

        //Mover a camara baseando-se na rotação do alvo e do offset original
        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotation * offset);

        //transform.position = target.position - offset;
        if(transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y - 0.5f, transform.position.z);
        }

        transform.LookAt(target.transform);
    }
}
