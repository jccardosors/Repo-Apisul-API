using System.Web;
using Newtonsoft.Json;
using ProjApisul.Models;
using ProvaAdmissionalCSharpApisul;

namespace ProjApisul.Services
{
    public class ElevadorService : IElevadorService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ElevadorService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public List<int> AndarMenosUtilizado()
        {
            var andaresMenosUtilizado = new List<int>();
            var listaInputs = CarregarDados().OrderBy(p => p.Andar);
            var totalPorAndar = 1000000;

            for (int i = 0; i <= 15; i++)
            {
                var total = listaInputs!.Count(p => p.Andar == i);

                if (total > 0 && total <= totalPorAndar)
                {
                    totalPorAndar = total;
                    andaresMenosUtilizado.Add(i);
                }
            }

            return andaresMenosUtilizado;
        }

        public List<char> ElevadorMaisFrequentado()
        {
            var elevadoresMaisUtilizado = new List<char>();
            var listaInputs = CarregarDados().OrderBy(p => p.Elevador);
            var totalPorElevador = -1;
            List<string> elevadores = new List<string>() { "A", "B", "C", "D", "E" };

            foreach (var elevador in elevadores)
            {
                var total = listaInputs!.Count(p => p.Elevador == elevador);

                if (total >= totalPorElevador)
                {
                    totalPorElevador = total;
                    elevadoresMaisUtilizado.Add(Convert.ToChar(elevador));
                }
            }

            return elevadoresMaisUtilizado;
        }

        public List<char> ElevadorMenosFrequentado()
        {
            var elevadorMenosUtilizado = new List<char>();
            var listaInputs = CarregarDados().OrderBy(p => p.Elevador);
            List<string> elevadores = new List<string>() { "A", "B", "C", "D", "E" };
            List<Elevador> elevadorFrequencia = new List<Elevador>();

            foreach (var elevador in elevadores)
            {
                var total = listaInputs!.Count(p => p.Elevador == elevador);

                elevadorFrequencia.Add(new Elevador
                {
                    ElevadorNome = elevador,
                    Frequencia = total
                });
            }

            var maxFreq = elevadorFrequencia.MaxBy(p => p.Frequencia)!.Frequencia;

            foreach (var item in elevadorFrequencia.OrderBy(p => p.Frequencia))
            {
                if (item.Frequencia <= maxFreq && item.Frequencia > 0)
                {
                    maxFreq = item.Frequencia;
                    elevadorMenosUtilizado.Add(Convert.ToChar(item.ElevadorNome));
                }
            }

            return elevadorMenosUtilizado;
        }

        public float PercentualDeUsoElevadorA()
        {
            return CalcularPercentualPorElevador("A");
        }

        public float PercentualDeUsoElevadorB()
        {
            return CalcularPercentualPorElevador("B");
        }

        public float PercentualDeUsoElevadorC()
        {
            return CalcularPercentualPorElevador("C");
        }

        public float PercentualDeUsoElevadorD()
        {
            return CalcularPercentualPorElevador("D");
        }

        public float PercentualDeUsoElevadorE()
        {
            return CalcularPercentualPorElevador("E");
        }

        public List<char> PeriodoMaiorFluxoElevadorMaisFrequentado()
        {
            // Deve retornar uma List contendo o período de maior fluxo de cada um dos elevadores mais frequentados (se houver mais de um).
            var periodoMaiorFluxoElevadorUtilizado = new List<char>();
            var listaInputs = CarregarDados().OrderBy(p => p.Elevador);
            List<string> turnos = new List<string>() { "M", "V", "N" };
            List<Inputs> listaInputsAux = new List<Inputs>();
            var elevadoresMaisFrequentados = ElevadorMaisFrequentado();

            foreach (var item in elevadoresMaisFrequentados)
            {
                var itemListaAux = listaInputs.Where(p => p.Elevador == item.ToString());

                itemListaAux.ToList().ForEach(p => listaInputsAux.Add(p));
            }

            listaInputsAux = listaInputsAux.OrderBy(p => p.Turno).ToList();

            var totalMax = -1;
            foreach (var item in turnos)
            {
                var total = listaInputsAux.Count(p => p.Turno == item.ToString());
                if (total >= totalMax)
                {
                    totalMax = total;
                    periodoMaiorFluxoElevadorUtilizado.Add(Convert.ToChar(item));
                }
            }

            return periodoMaiorFluxoElevadorUtilizado;
        }

        public List<char> PeriodoMaiorUtilizacaoConjuntoElevadores()
        {
            //Deve retornar uma List contendo o(s) periodo(s) de maior utilização do conjunto de elevadores.
            var periodoMaiorUtilizacaoConjunto = new List<char>();
            var listaInputs = CarregarDados().OrderBy(p => p.Turno);
            List<string> turnos = new List<string>() { "M", "V", "N" };         

            var totalMax = -1;
            foreach (var item in turnos)
            {
                var total = listaInputs.Count(p => p.Turno == item.ToString());
                if (total >= totalMax)
                {
                    totalMax = total;
                    periodoMaiorUtilizacaoConjunto.Add(Convert.ToChar(item));
                }
            }

            return periodoMaiorUtilizacaoConjunto;
        }

        public List<char> PeriodoMenorFluxoElevadorMenosFrequentado()
        {
            var periodoMaiorFluxoElevadorUtilizado = new List<char>();
            var listaInputs = CarregarDados().OrderBy(p => p.Elevador);
            List<string> turnos = new List<string>() { "M", "V", "N" };
            List<Inputs> listaInputsAux = new List<Inputs>();
            var elevadoresMaisFrequentados = ElevadorMenosFrequentado();

            foreach (var item in elevadoresMaisFrequentados)
            {
                var itemListaAux = listaInputs.Where(p => p.Elevador == item.ToString());

                itemListaAux.ToList().ForEach(p => listaInputsAux.Add(p));
            }

            listaInputsAux = listaInputsAux.OrderBy(p => p.Turno).ToList();

            var totalMax = -1;
            foreach (var item in turnos)
            {
                var total = listaInputsAux.Count(p => p.Turno == item.ToString());
                if (total >= totalMax)
                {
                    totalMax = total;
                    periodoMaiorFluxoElevadorUtilizado.Add(Convert.ToChar(item));
                }
            }

            return periodoMaiorFluxoElevadorUtilizado;
        }

        #region Protected Metodos

        protected List<Inputs> CarregarDados()
        {
            var caminhoArquivo = Path.Combine($@"{_webHostEnvironment.ContentRootPath}\input.json");

            var json = File.ReadAllText(caminhoArquivo);

            var listaInputs = JsonConvert.DeserializeObject<List<Inputs>>(json);

            return listaInputs!;
        }

        protected float CalcularPercentualPorElevador(string elevador)
        {
            var percentualDeUsoElevador = 0f;
            var listaInputs = CarregarDados().OrderBy(p => p.Elevador);

            float total = listaInputs.Count();
            float totalElevador = listaInputs.Count(p => p.Elevador == elevador);

            float xx = totalElevador * 100 / total;
            percentualDeUsoElevador = float.Parse(xx.ToString("0.00"));

            return percentualDeUsoElevador;
        }

        #endregion
    }
}
