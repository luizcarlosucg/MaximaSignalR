namespace ClientConsoleSignalR.Objetos
{
    public class ParametroEntrada
    {
        public string NomeParametro { get; set; }
        public object Valor { get; set; }

        public ParametroEntrada(string nomeParametro, object valor)
        {
            this.NomeParametro = nomeParametro;
            this.Valor = valor;
        }
    }
}
