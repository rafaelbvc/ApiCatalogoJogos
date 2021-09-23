using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("8f9aj4ne-3583-0194-09fr-ndj2kd94la01"), new Jogo{ Id = Guid.Parse("8f9aj4ne-3583-0194-09fr-ndj2kd94la01"), Nome = "Fifa 21", Produtora = "EA", Preco = 200  } },
            {Guid.Parse("fm5ka94k-3012-5603-0gs0-m3k5dfl902fm"), new Jogo{ Id = Guid.Parse("fm5ka94k-3012-5603-0gs0-m3k5dfl902fm"), Nome = "Fifa 20", Produtora = "JJ", Preco = 190  } },
            {Guid.Parse("b40dk39g-0375-9284-48fd-m2s94ns94md9"), new Jogo{ Id = Guid.Parse("b40dk39g-0375-9284-48fd-m2s94ns94md9"), Nome = "Fifa 19", Produtora = "HH", Preco = 180  } },
            {Guid.Parse("mc84j8aj-d9vc-p345-m4od-m1nsiodfmfnw"), new Jogo{ Id = Guid.Parse("mc84j8aj-d9vc-p345-m4od-m1nsiodfmfnw"), Nome = "Fifa 18", Produtora = "TT", Preco = 170  } },
            {Guid.Parse("zckl3mrk-od92-5694-6691-l3lfioqm4njf"), new Jogo{ Id = Guid.Parse("zckl3mrk-od92-5694-6691-l3lfioqm4njf"), Nome = "Fifa 17", Produtora = "YY", Preco = 80  } },
            {Guid.Parse("un5n5j20-45i2-verf-kkgw-ffk2omf2nm2a"), new Jogo{ Id = Guid.Parse("un5n5j20-45i2-verf-kkgw-ffk2omf2nm2a"), Nome = "Fifa 16", Produtora = "BB", Preco = 190  } },
        };

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora)
        {
            var retorno = new List<Jogo>();

            foreach (var jogo in jogos.Values)
            {
                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
                    retorno.Add(jogo);
            }

            return Task.FromResult(retorno);
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {

        }
    }
}
