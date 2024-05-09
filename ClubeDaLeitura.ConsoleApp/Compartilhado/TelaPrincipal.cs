namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    internal static class TelaPrincipal
    {
        public static char ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|           Clube de Leitura           |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Gerenciamento de Amigos");
            Console.WriteLine("2 - Gerenciamento de Caixas");
            Console.WriteLine("3 - Gerenciamento de Revistas");
            Console.WriteLine("4 - Gerenciamento de Reservas");
            Console.WriteLine("5 - Gerenciamento de Empréstimo");
            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");

            char opcaoEscolhida = Console.ReadLine()[0];

            return opcaoEscolhida;
        }
    }
}
