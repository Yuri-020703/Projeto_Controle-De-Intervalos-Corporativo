using Controle_de_Intervalos_Corporativo.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
            Console.WriteLine("SISTEMA CONTROLADOR DE INTERVALOS NO TRABALHO:");
            Console.WriteLine("---------------------");
            Console.WriteLine("Café da manhã: 30 minutos");
            Console.WriteLine("Almoço : 1h30");
            Console.WriteLine("Café da tarde: 15 minutos");
            Console.WriteLine();

        using AppDbContext db = new AppDbContext();
        db.Database.EnsureCreated();
        db.SaveChanges();

        int opc = 1;

            while (opc == 1)
            {
                try
                {
                    Console.WriteLine("Digite 1 : Fazer uma intervalo");
                    Console.WriteLine("Digite 2 : Consultar intervalos");
                    Console.WriteLine("Digite 3 : Remover um registro");
                    Console.WriteLine("Digite 4 : Fechar programa");
                    Console.WriteLine("Digite 5 : Ver histórico");

                    Console.Write("Escolha uma opção: ");
                    int escolha = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                switch (escolha)
                    {

                        case 1:
                            Console.WriteLine("Digite 1 : Café da manhã - 30 minutos");
                            Console.WriteLine("Digite 2 : Almoço - 1h30");
                            Console.WriteLine("Digite 3 : Café da tarde - 15 minutos");
                            Console.Write("Qual intervalo você deseja fazer ? ");
                            int tipoPausa = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            if (tipoPausa == 1)
                            {
                                Intervalo pausa = new Intervalo(DateTime.Now);
                                pausa.PausaCafeDaManha();
                                db.Intervalos.Add(pausa);
                                db.SaveChanges();

                                Console.WriteLine($"Registro feito com SUCESSO! ID do registro: {pausa.Id}");
                                Console.WriteLine($"Volte {pausa.Retorno.ToString("dd/MM/yyyy HH:mm")}");
                                Console.WriteLine();
                            }
                            else if (tipoPausa == 2)
                            {
                                Intervalo pausa = new Intervalo(DateTime.Now);
                                pausa.PausaAlmoço();
                                db.Intervalos.Add(pausa);
                                db.SaveChanges();

                                Console.WriteLine($"Registro feito com SUCESSO! ID do registro: {pausa.Id}");
                                Console.WriteLine($"Volte {pausa.Retorno.ToString("dd/MM/yyyy HH:mm")}");
                                Console.WriteLine();
                            }
                            else if (tipoPausa == 3)
                            {
                                Intervalo pausa = new Intervalo(DateTime.Now);
                                pausa.PausaCafeDaTarde();
                                db.Intervalos.Add(pausa);
                                db.SaveChanges();

                                Console.WriteLine($"Registro feito com SUCESSO! ID do registro: {pausa.Id}");
                                Console.WriteLine($"Volte {pausa.Retorno.ToString("dd/MM/yyyy HH:mm")}");
                                Console.WriteLine();
                            }
                            break;

                        case 2:
                            Console.WriteLine("Você vai precisar digitar o ID do registro, se foi o primeiro, o ID será 1. Se foi o segundo, o ID será 2... Assim em diante");
                            Console.Write("Digite o ID do registro ");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            var result = db.Intervalos.Where(x => x.Id == id);
                            foreach (Intervalo obj in result)
                            {
                                Console.WriteLine($"Id: {obj.Id}, Hora do intervalo: {obj.HoraIntervalo.ToString("dd/MM/yyyy HH:mm")}, Hora do retorno: {obj.Retorno.ToString("dd/MM/yyyy HH:mm")}");
                            }
                            Console.WriteLine();
                            break;

                        case 3:
                            foreach (Intervalo obj in db.Intervalos)
                            {
                                Console.WriteLine($"ID: {obj.Id}, Hora do intervalo {obj.HoraIntervalo.ToString("dd/MM/yyyy HH:mm")}, Hora do retorno: {obj.Retorno.ToString("dd/MM/yyyy HH:mm")}");
                            }
                            Console.WriteLine();
                            Console.Write("Digite o ID do registro que vcoê deseja remover: ");
                            int idRemove = int.Parse(Console.ReadLine());
                            var resultRemove = db.Intervalos.FirstOrDefault(x => x.Id == idRemove);
                            db.Intervalos.Remove(resultRemove);
                            db.SaveChanges();
                            Console.WriteLine();
                            Console.WriteLine("Registro removido com SUCESSO!");
                            Console.WriteLine();

                            foreach (Intervalo obj in db.Intervalos)
                            {
                                Console.WriteLine($"ID: {obj.Id}, Hora do intervalo {obj.HoraIntervalo.ToString("dd/MM/yyyy HH:mm")}, Hora do retorno: {obj.Retorno.ToString("dd/MM/yyyy HH:mm")}");
                            }
                            Console.WriteLine();
                            break;
                        case 4:
                        opc = 0;
                            break;
                        case 5:
                            foreach (Intervalo obj in db.Intervalos)
                            {
                                Console.WriteLine($"ID: {obj.Id}, Hora do intervalo {obj.HoraIntervalo.ToString("dd/MM/yyyy HH:mm")}, Hora do retorno: {obj.Retorno.ToString("dd/MM/yyyy HH:mm")}");
                            }
                            Console.WriteLine();
                            break;

                        default:
                            Console.WriteLine("❌ Opção inválida! Digite um número de 1 a 5");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("❌ Entrada inválida! Digite apenas números.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ Erro inesperado: " + ex.Message + "\n");
                }
            }
    }
}




