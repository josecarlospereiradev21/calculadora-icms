using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IcmsPneus;

namespace CalculaIcmsWeb.Pages
{
    public class PneuInput
    {
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }

    public class CalcularModel : PageModel
    {
        [BindProperty]
        public List<PneuInput> Pneus { get; set; } = new List<PneuInput>();

        public decimal? BaseCalculo { get; set; }
        public decimal? ValorIcms { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            var calc = new IcmsPneuCalculator();

            decimal totalBase = 0;
            decimal totalIcms = 0;

            foreach (var pneu in Pneus)
            {
                var resultado = calc.Calcular(pneu.Preco, pneu.Quantidade);

                totalBase += resultado.baseCalculo;
                totalIcms += resultado.valorIcms;
            }

            BaseCalculo = totalBase;
            ValorIcms = totalIcms;
        }
    }
}