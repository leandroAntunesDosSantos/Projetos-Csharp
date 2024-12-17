using CadastroVeiculos.Dominio.Entidades;
using CadastroVeiculos.Dominio.Interfaces;
using CadastroVeiculos.Infraestrutura.DB;

namespace CadastroVeiculos.Dominio.Servicos
{
    public class VeiculoServico : IVeiculoServico
    {
        private readonly DbContexto _contexto;

        public VeiculoServico(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public void Incluir(Veiculo veiculo)
        {
            _contexto.Veiculos.Add(veiculo);
            _contexto.SaveChanges();
        }

        public void Apagar(Veiculo veiculo)
        {
            _contexto.Veiculos.Remove(veiculo);
            _contexto.SaveChanges();
        }

        public void Atualizar(Veiculo veiculo)
        {
            _contexto.Veiculos.Update(veiculo);
            _contexto.SaveChanges();
        }

        public Veiculo BuscaPorId(int id)
        {
            var veiculo = _contexto.Veiculos.FirstOrDefault(x => x.Id == id);
            if (veiculo == null)
            {
                throw new Exception("Veículo não encontrado");
            }
            return veiculo;
        }


        public List<Veiculo> ListarVeiculos(int pagina, string? nome, string? marca)
        {
            var veiculos = _contexto.Veiculos.AsQueryable();
            if (!string.IsNullOrEmpty(nome))
            {
                veiculos = veiculos.Where(x => x.Nome.Contains(nome));
            }
            if (!string.IsNullOrEmpty(marca))
            {
                veiculos = veiculos.Where(x => x.Marca.Contains(marca));
            }
            return veiculos.Skip((pagina - 1) * 10).Take(10).ToList();
        }

    }
}
