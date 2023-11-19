using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Declaraci�n de objetos de texto en Unity que mostrar�n el resultado y los contadores.
    public TMP_Text resultadoText;
    public TMP_Text contadorJugadorText;
    public TMP_Text contadorIAText;

    // Variables para llevar el registro de las victorias del jugador y de la IA.
    private int contadorJugador = 0;
    private int contadorIA = 0;

    // Enumeraci�n que representa las opciones posibles del juego.
    private enum Opcion { PIEDRA, PAPEL, TIJERAS }

    // M�todo que se llama cuando se quiere jugar una partida.
    public void JugarPartida()
    {
        // Se elige aleatoriamente la opci�n del jugador y de la IA.
        Opcion opcionUsuario = (Opcion)Random.Range(0, 3);
        Opcion opcionIA = (Opcion)Random.Range(0, 3);

        // Se llama a la funci�n para mostrar el resultado y se actualizan los contadores.
        MostrarResultado(opcionUsuario, opcionIA);
        ActualizarContadores();
    }

    // M�todo para mostrar el resultado de la partida.
    private void MostrarResultado(Opcion opcionUsuario, Opcion opcionIA)
    {
        // Comprobaci�n de las condiciones para determinar el ganador de la partida.
        if (opcionUsuario == opcionIA)
        {
            resultadoText.text = "Empate";
        }
        else if (
            (opcionUsuario == Opcion.PIEDRA && opcionIA == Opcion.TIJERAS) ||
            (opcionUsuario == Opcion.PAPEL && opcionIA == Opcion.PIEDRA) ||
            (opcionUsuario == Opcion.TIJERAS && opcionIA == Opcion.PAPEL)
        )
        {
            resultadoText.text = "�Ganaste!";
            contadorJugador++;
        }
        else
        {
            resultadoText.text = "Perdiste.";
            contadorIA++;
        }
    }

    // M�todo para actualizar los contadores en la interfaz de usuario.
    private void ActualizarContadores()
    {
        contadorJugadorText.text = $"Jugador: {contadorJugador}";
        contadorIAText.text = $"IA: {contadorIA}";
    }
}
