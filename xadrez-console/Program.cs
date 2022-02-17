using tabuleiro;
using xadrez_console;
using xadrez;

try
{
    PartidaDeXadrez partida = new PartidaDeXadrez();

    while (!partida.terminada)
    {
        try { 
        Console.Clear();
        Tela.imprimirPartida(partida);

        Console.Write("Origem: ");
        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
        partida.validarPosicaoDeOrigem(origem);

        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();


        Console.Clear();
        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

        Console.Write("Destino: ");
        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
            partida.validarPosicaoDeDestino(origem, destino);

        partida.realizaJogada(origem, destino);
        }
        catch (TabuleiroException ex)
        {
            Console.WriteLine(ex.ToString());
            Console.ReadKey();
        }
    }
    Console.Clear() ;
    Tela.imprimirPartida(partida);
}
catch (TabuleiroException ex)
{
    Console.WriteLine(ex.Message);
}
Console.ReadKey();