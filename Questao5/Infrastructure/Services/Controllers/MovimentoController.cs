using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Sqlite;
using System.Data;
using System.Data.SQLite;
using Xunit;
using static Questao5.Infrastructure.Services.Controllers.MovimentoController;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentoController : ControllerBase
    {

        [HttpPost(Name = "MovimentoConta")]
        public Task Post(MovimentoContaCorrente movimentoConta)
        //(SQLiteConnection connection, String connectionString, Boolean allowNameOnly)
        {
            // conferir se a conta existe

            string ApplicationDataBaseFolderPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "AppData");
            using var connection = new SqliteConnection(String.Format("Data Source={0};", Path.Combine(ApplicationDataBaseFolderPath, "database.sqlite")));

            //enviar data para tabela
            connection.Execute("INSERT INTO movimento(idmovimento, idcontacorrente, datamovimento, tipomovimento, valor) VALUES('"
                + movimentoConta.IdMovimento + "','"
                + movimentoConta.IdContacorrente + "','"
                + DateTime.Now.ToString("dd/MM/yyyy") + "','"
                + movimentoConta.TipoMovimento + "',"
                + movimentoConta.Valor + ");");

            return Task.CompletedTask;
        }
    }
}