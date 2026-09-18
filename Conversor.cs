##Conversor de monedas


namespace ConversorMonedas
{
    public static class Conversor
    {
        private const double TasaUsdToDop = 60.0;
        private const double TasaEurToUsd = 1.08;

        public static double Convertir(double monto, string origen, string destino)
        {
            if (origen == destino) return monto;

            double montoEnUsd = 0;
            switch (origen)
            {
                case "USD":
                    montoEnUsd = monto;
                    break;
                case "DOP":
                    montoEnUsd = monto / TasaUsdToDop;
                    break;
                case "EUR":
                    montoEnUsd = monto * TasaEurToUsd;
                    break;
            }

            switch (destino)
            {
                case "USD":
                    return montoEnUsd;
                case "DOP":
                    return montoEnUsd * TasaUsdToDop;
                case "EUR":
                    return montoEnUsd / TasaEurToUsd;
                default:
                    return 0;
            }
        }
    }
}
