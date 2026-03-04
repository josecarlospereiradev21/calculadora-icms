namespace IcmsPneus
{
    public class IcmsPneuCalculator
    {
        public (decimal baseCalculo, decimal valorIcms) Calcular (decimal precoUnitario, int quantidade, decimal baseCalculoIcms = 0.4166m, decimal valorIcms = 0.18m)
        {
            decimal valorOperacao = precoUnitario * quantidade;

            decimal calculoBase = valorOperacao * (1 + baseCalculoIcms);

            decimal calculoValor = calculoBase * valorIcms;

            return (calculoBase, calculoValor);
            
        }
    }
}