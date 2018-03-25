namespace WebServerSignalR.Objetos
{
    public class ParametroSql
    {
        public string Nome { get; set; }
        public object Valor { get; set; }
        public Enumeradores.TipoParametroSql Tipo { get; set; }

        public ParametroSql(string nome, object valor, Enumeradores.TipoParametroSql tipo)
        {
            this.Nome = nome;
            this.Valor = valor;
            this.Tipo = tipo;
        }
    }
}