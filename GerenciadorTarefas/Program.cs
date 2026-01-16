using System;
using System.Collections.Generic; // Permite usar Listas

namespace GerenciadorTarefas
{
    // 1. A CLASSE TAREFA: O "Molde" do nosso dado
    class Tarefa
    {
        public string Descricao { get; set; }
        public bool Concluida { get; set; }
    }

    class Program
    {
        // 2. A LISTA: Onde vamos guardar as tarefas na memória
        static List<Tarefa> listaDeTarefas = new List<Tarefa>();

        static void Main(string[] args)
        {
            // 3. O MENU: Um loop infinito até o usuário sair
            while (true)
            {
                Console.Clear(); // Limpa a tela
                Console.WriteLine("=== MEU GERENCIADOR DE TAREFAS ===");
                Console.WriteLine("1 - Adicionar Tarefa");
                Console.WriteLine("2 - Listar Tarefas");
                Console.WriteLine("3 - Remover Tarefa");
                Console.WriteLine("4 - Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                // Decisão do que fazer
                switch (opcao)
                {
                    case "1":
                        AdicionarTarefa();
                        break;
                    case "2":
                        ListarTarefas();
                        break;
                    case "3":
                        RemoverTarefa();
                        break;
                    case "4":
                        return; // Encerra o programa
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        // 4. FUNÇÃO DE ADICIONAR
        static void AdicionarTarefa()
        {
            Console.Write("Digite a descrição da tarefa: ");
            string descricao = Console.ReadLine();

            // Cria um novo objeto Tarefa
            Tarefa novaTarefa = new Tarefa();
            novaTarefa.Descricao = descricao;
            novaTarefa.Concluida = false;

            // Joga dentro da lista
            listaDeTarefas.Add(novaTarefa);
            Console.WriteLine("Tarefa adicionada com sucesso!");
        }

        // 5. FUNÇÃO DE LISTAR
        static void ListarTarefas()
        {
            Console.WriteLine("\n--- Lista de Tarefas ---");

            // Loop para ler cada item da lista
            for (int i = 0; i < listaDeTarefas.Count; i++)
            {
                // Pega a tarefa na posição 'i'
                Tarefa t = listaDeTarefas[i];
                Console.WriteLine($"ID: {i} | {t.Descricao} - {(t.Concluida ? "[Feita]" : "[Pendente]")}");
            }
        }

        // 6. FUNÇÃO DE REMOVER
        static void RemoverTarefa()
        {
            ListarTarefas();
            Console.Write("Digite o ID da tarefa para remover: ");

            // Tenta converter o texto digitado para número
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (id >= 0 && id < listaDeTarefas.Count)
                {
                    listaDeTarefas.RemoveAt(id);
                    Console.WriteLine("Tarefa removida!");
                }
                else
                {
                    Console.WriteLine("ID não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Por favor, digite um número válido.");
            }
        }
    }
}