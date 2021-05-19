using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CicloDeVidaIDController : ControllerBase
    {
        public readonly ISingleton _singleton1;
        public readonly ISingleton _singleton2;

        public readonly IScoped _scoped1;
        public readonly IScoped _scoped2;

        public readonly ITransient _transient1;
        public readonly ITransient _transient2;

        public CicloDeVidaIDController(ISingleton Singleton1,
                                       ISingleton Singleton2,
                                       IScoped Scoped1,
                                       IScoped Scoped2,
                                       ITransient Transient1,
                                       ITransient Transient2)
        {
            _singleton1 = Singleton1;
            _singleton2 = Singleton2;
            _scoped1 = Scoped1;
            _scoped2 = Scoped2;
            _transient1 = Transient1;
            _transient2 = Transient2;
        }

        [HttpGet]
        public Task<string> Get()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Singleton 1: {_singleton1.Id}");
            stringBuilder.AppendLine($"Singleton 2: {_singleton2.Id}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Scoped 1: {_scoped1.Id}");
            stringBuilder.AppendLine($"Scoped 2: {_scoped2.Id}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Transient 1: {_transient1.Id}");
            stringBuilder.AppendLine($"Transient 2: {_transient2.Id}");

            return Task.FromResult(stringBuilder.ToString());
        }

    }

    public interface IGeral
    {
        public Guid Id { get; }
    }

    public interface ISingleton :IGeral
    { }

    public interface IScoped : IGeral
    { }

    public interface ITransient : IGeral
    { }

    public class CicloDeVida : ISingleton, IScoped, ITransient
    {
        private readonly Guid _guid;

        public CicloDeVida()
        {
            _guid = Guid.NewGuid();
        }

        public Guid Id => _guid;
    }

}
