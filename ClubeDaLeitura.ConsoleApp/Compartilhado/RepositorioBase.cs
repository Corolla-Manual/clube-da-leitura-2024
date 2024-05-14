using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    internal abstract class RepositorioBase<T> where T : EntidadeBase
    {
        protected List<T> registros = new List<T>();

        protected int contadorId = 1;

        public void Cadastrar(T novoRegistro)
        {
            novoRegistro.Id = contadorId++;

            registros.Add(novoRegistro);
        }

        public bool Editar(int id, T novaEntidade)
        {
            novaEntidade.Id = id;

            foreach (T entidade in registros)
            {
                if (entidade == null)
                    continue;

                else if (entidade.Id == id)
                {
                    entidade.AtualizarRegistro(novaEntidade);

                    return true;
                }
            }

            return false;
        }

        public bool Excluir(int id)
        {
            foreach (T entidade in registros)
            {
                if (entidade == null)
                    continue;

                else if (entidade.Id == id)
                {
                    registros.Remove(entidade);
                    return true;
                }
            }

            return false;
        }

        public List<T> SelecionarTodos()
        {
            return registros;
        }

        public T SelecionarPorId(int id)
        {
            foreach (T entidade in registros)
            {

                if (entidade == null)
                    continue;

                else if (entidade.Id == id)
                    return entidade;
            }

            return null;
        }

        public bool Existe(int id)
        {
            foreach (T entidade in registros)
            {
                if (entidade == null)
                    continue;

                else if (entidade.Id == id)
                    return true;
            }

            return false;
        }
    }
}
