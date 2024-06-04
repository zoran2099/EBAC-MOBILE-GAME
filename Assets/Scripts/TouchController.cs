using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{


    [SerializeField]
    private Vector2 pastPosition;    
    public float acceleration;

    
    // Update is called once per frame
    void Update()
    {
        // Deve salvar posição do mouse somente quando o botão do mouse é pressionado
        // e assim evitar salvar a posição do mouse quando clicar fora da tela.
        // Isso corrige o bug onde pressinar o mouse fora da tela fazia mudar
        // a posição do Player Controller o que geralmente jogava o Player para
        // fora da pista

        if (Input.GetMouseButtonDown(0))
        {
            //  Sendo verdadeiro no quadro em que você clicou com o botão esquerdo do mouse.
            //  Nos quadros subsequentes, mesmo se o botão do mouse
            //  ainda estiver pressionado, essa função retornará falso. 
            // salva a posição do mouse

            pastPosition = Input.mousePosition;

        } else if (Input.GetMouseButton(0)) //Isso retornará verdadeiro em todos os quadros em que o botão esquerdo do mouse estiver pressionado.
        {
            
            Move( Input.mousePosition.x - pastPosition.x);
            pastPosition = Input.mousePosition;
        }



    }

    private void Move(float speed)
    {
        transform.position += Vector3.right * Time.deltaTime * speed * acceleration;
    }

   
}
