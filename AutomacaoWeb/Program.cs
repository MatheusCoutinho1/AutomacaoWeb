using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

class Program
{
    static void Main(string[] args)
    {
        // Inicializa o driver do Chrome
        var options = new ChromeOptions();
        options.AddArgument("start-maximized");
        var driver = new ChromeDriver(options);

        // Navega até a página de cotação do dólar
        driver.Navigate().GoToUrl("https://www.google.com/search?q=dolar+para+real");

        try
        {
            // Localiza o elemento pai comum para o valor do dólar
            var parentElementDolar = driver.FindElement(By.CssSelector(".b1hJbf"));

            // Localiza o elemento filho que exibe o valor do dólar dentro do elemento pai
            var exchangeRateElementDolar = parentElementDolar.FindElement(By.CssSelector(".DFlfde.SwHCTb"));

            // Obtém o valor do dólar em relação ao real e a data/hora da cotação
            var exchangeRateTextDolar = exchangeRateElementDolar.Text;

            // Navega até a página de cotação do euro
            driver.Navigate().GoToUrl("https://www.google.com/search?q=euro+para+real");

            // Localiza o elemento pai comum para o valor do euro
            var parentElementEuro = driver.FindElement(By.CssSelector(".b1hJbf"));

            // Localiza o elemento filho que exibe o valor do euro dentro do elemento pai
            var exchangeRateElementEuro = parentElementEuro.FindElement(By.CssSelector(".DFlfde.SwHCTb"));

            // Obtém o valor do euro em relação ao real e a data/hora da cotação
            var exchangeRateTextEuro = exchangeRateElementEuro.Text;

            // Obtém a data/hora da cotação
            var dateTime = DateTime.Now;

            // Cria uma string com os valores do dólar, euro e a data/hora da cotação
            var outputString = $"{dateTime} - Valor do dólar: {exchangeRateTextDolar}\r\n{dateTime} - Valor do euro: {exchangeRateTextEuro}";

            // Escreve a string no bloco de notas
            System.IO.File.WriteAllText(@"C:\Users\Matheus\Documents\ValorMoedas\ValorMoedas.txt", outputString);

            Console.WriteLine("Valores das moedas escritos com sucesso no bloco de notas.");
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Elemento não encontrado.");
        }

        // Fecha o driver do Chrome
        driver.Quit();
    }
}

