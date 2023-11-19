using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Declaración de objetos de texto en Unity que mostrarán el resultado y los contadores.
    public TMP_Text resultadoText;
    public TMP_Text contadorJugadorText;
    public TMP_Text contadorIAText;

    // Variables para llevar el registro de las victorias del jugador y de la IA.
    private int contadorJugador = 0;
    private int contadorIA = 0;

    // Enumeración que representa las opciones posibles del juego.
    private enum Opcion { PIEDRA, PAPEL, TIJERAS }

    // Método que se llama cuando se quiere jugar una partida.
    public void JugarPartida()
    {
        // Se elige aleatoriamente la opción del jugador y de la IA.
        Opcion opcionUsuario = (Opcion)Random.Range(0, 3);
        Opcion opcionIA = (Opcion)Random.Range(0, 3);

        // Se llama a la función para mostrar el resultado y se actualizan los contadores.
        MostrarResultado(opcionUsuario, opcionIA);
        ActualizarContadores();
    }

    // Método para mostrar el resultado de la partida.
    private void MostrarResultado(Opcion opcionUsuario, Opcion opcionIA)
    {
        // Comprobación de las condiciones para determinar el ganador de la partida.
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
            resultadoText.text = "¡Ganaste!";
            contadorJugador++;
        }
        else
        {
            resultadoText.text = "Perdiste.";
            contadorIA++;
        }
    }

    // Método para actualizar los contadores en la interfaz de usuario.
    private void ActualizarContadores()
    {
        contadorJugadorText.text = $"Jugador: {contadorJugador}";
        contadorIAText.text = $"IA: {contadorIA}";
    }
}
