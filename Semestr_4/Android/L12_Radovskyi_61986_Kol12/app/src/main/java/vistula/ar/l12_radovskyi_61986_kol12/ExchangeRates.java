package vistula.ar.l12_radovskyi_61986_kol12;

public class ExchangeRates {
    private static double UsdToJpy = 110.0; // 1 USD = 110 JPY
    private static double UsdToGbp = 0.73;  // 1 USD = 0.73 GBP
    private static double JpyToUsd = 1 / UsdToJpy; // 1 JPY = 0.0091 USD
    private static double GbpToUsd = 1 / UsdToGbp; // 1 GBP = 1.37 USD
    private static double JpyToGbp = UsdToGbp * JpyToUsd; // 1 JPY = 0.00663 GBP
    private static double GbpToJpy = 1 / JpyToGbp; // 1 GBP = 151 JPY
    public static void setUsdToJpy(double rate) {
        UsdToJpy = rate;
        JpyToUsd = 1 / rate;
        JpyToGbp = UsdToGbp * JpyToUsd;
        GbpToJpy = 1 / JpyToGbp;
    }

    public static void setUsdToGbp(double rate) {
        UsdToGbp = rate;
        GbpToUsd = 1 / rate;
        JpyToGbp = UsdToGbp * JpyToUsd;
        GbpToJpy = 1 / JpyToGbp;
    }

    public static void setJpyToUsd(double rate) {
        JpyToUsd = rate;
        UsdToJpy = 1 / rate;
        JpyToGbp = UsdToGbp * JpyToUsd;
        GbpToJpy = 1 / JpyToGbp;
    }

    public static void setGbpToUsd(double rate) {
        GbpToUsd = rate;
        UsdToGbp = 1 / rate;
        JpyToGbp = UsdToGbp * JpyToUsd;
        GbpToJpy = 1 / JpyToGbp;
    }

    public static void setJpyToGbp(double rate) {
        JpyToGbp = rate;
        GbpToJpy = 1 / rate;
    }

    public static void setGbpToJpy(double rate) {
        GbpToJpy = rate;
        JpyToGbp = 1 / rate;
    }

    private static double toUSD(double amount, String currency) {
        switch (currency) {
            case "USD":
                return amount;
            case "JPY":
                return amount * JpyToUsd;
            case "GBP":
                return amount * GbpToUsd;
            default:
               return 0;
        }
    }
    public static double convert(double amount, String fromCurrency, String toCurrency) {
        if (fromCurrency.equals(toCurrency)) {
            return amount;
        }

        double amountInUSD = toUSD(amount, fromCurrency);

        switch (toCurrency) {
            case "USD":
                return amountInUSD;
            case "JPY":
                return amountInUSD * UsdToJpy;
            case "GBP":
                return amountInUSD * UsdToGbp;
            default:
                return 0;
        }
    }


}
