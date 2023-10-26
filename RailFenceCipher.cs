using BenchmarkDotNet.Attributes;
using System.Text;
/// <summary>
/// Codificador de rieles global
/// </summary>
[MemoryDiagnoser]
public class RailFenceCipher
{
    /// <summary>
    /// Inicializa el rail central
    /// </summary>
    /// <param name="rails">Modo o numero de railes centrales</param>
    public RailFenceCipher(int rails)
        => _Rails = rails;
    /// <summary>
    /// Codifica un mensaje en base a los rieles establecidos
    /// </summary>
    /// <param name="input">Mensaje de entrada</param>
    /// <returns>Mensaje codificado</returns>
    [Benchmark]
    public string Encode(string input)
    {
        var moldingInput = MolderCode(input);

        var messageEncoder = new StringBuilder();

        for (int x = 0; x < _Rails; x++)
        {
            for (int y = 0; y < input.Length; y++)
            {
                if (moldingInput[x, y] is not '\0')
                {
                    messageEncoder.Append(moldingInput[x, y]);
                }
            }
        }

        return messageEncoder.ToString();
    }
    /// <summary>
    /// Retorna un Char[,] que representa el texto de entrada zigzagueado en función de los rieles establecidos
    /// </summary>
    /// <param name="input">Texto que se va a ralear</param>
    /// <returns>Texto zigzagueado</returns>
    private char[,] MolderCode(ReadOnlySpan<char> input)
    {
        var collectionCharacter = new char[_Rails, input.Length];

        var MesseguerMolderDirection = (Fila: 0, Columna: 0, Direction: true);

        var flagExit = input.Length - 1;

        for (int i = 0; i < input.Length; i++)
        {
            collectionCharacter[MesseguerMolderDirection.Fila, MesseguerMolderDirection.Columna] = input[i];

            if (i != flagExit)
            {
                if (MesseguerMolderDirection.Direction)
                {
                    MesseguerMolderDirection.Fila++;
                }
                else
                {
                    MesseguerMolderDirection.Fila--;
                }
                if (MesseguerMolderDirection.Fila == _Rails - 1 || (MesseguerMolderDirection.Fila == 0 && MesseguerMolderDirection.Columna is not 0))
                {
                    MesseguerMolderDirection.Direction = !MesseguerMolderDirection.Direction;
                }

                MesseguerMolderDirection.Columna++;
            }
            else
            {
                break;
            }
        }

        return collectionCharacter;
    }
    /// <summary>
    /// Decodifica un mensaje en base a los rieles establecidos
    /// </summary>
    /// <param name="input">Mensaje codificado</param>
    /// <returns>Mensaje descodificado</returns>
    [Benchmark]
    public string Decode(string input)
    {
        //Guardamos la palabra para solo su lectura como referencia
        var indexInput = 0;
        //Necesitamos los espacios donde se encuentran el mensaje y una forma seria encriptando el mensaje de nuevo
        //para mutar las posiciones 
        var molderDecode = MolderCode(input);
        //Cambiamos los espacios de las letras por los caracteres de referencia
        for (int fila = 0; fila < _Rails; fila++)
        {
            for (int columna = 0; columna < input.Length; columna++)
            {
                if (molderDecode[fila,columna] is not '\0')
                {
                    molderDecode[fila, columna] = input[indexInput];
                    indexInput++;
                }
            }
        }

        return DesMolderCode(ref molderDecode,input.Length);
    }
    /// <summary>
    /// Retorna la reversión del zigzagueado
    /// </summary>
    /// <param name="modelCode">Mensaje zigzagueado</param>
    /// <param name="outputLength">Tamaño del mensaje original</param>
    /// <returns></returns>
    private string DesMolderCode(ref char[,] modelCode,in int outputLength)
    {
        var messengerMolderDirection = (Fila: 0, Columna: 0, Direction: true);

        var flagExit = outputLength - 1;

        var messengerDesMolder = new StringBuilder();

        for (int i = 0; i < outputLength; i++)
        {
            messengerDesMolder.Append(modelCode[messengerMolderDirection.Fila, messengerMolderDirection.Columna]);

            if (i != flagExit)
            {
                if (messengerMolderDirection.Direction)
                {
                    messengerMolderDirection.Fila++;
                }
                else
                {
                    messengerMolderDirection.Fila--;
                }
                if (messengerMolderDirection.Fila == _Rails - 1 || (messengerMolderDirection.Fila == 0 && messengerMolderDirection.Columna is not 0))
                {
                    messengerMolderDirection.Direction = !messengerMolderDirection.Direction;
                }

                messengerMolderDirection.Columna++;
            }
            else
            {
                break;
            }
        }

        return messengerDesMolder.ToString();
    }

    public readonly int _Rails;
}