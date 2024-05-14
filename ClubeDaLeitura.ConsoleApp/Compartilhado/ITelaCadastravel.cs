namespace ClubeDaLeitura.ConsoleApp
{
    public interface ITelaCadastravel
    {
        char ApresentarMenu();
        void Registrar();
        void Editar();
        void Excluir();
        void VisualizarRegistros(bool exibirTitulo);
    }
}

