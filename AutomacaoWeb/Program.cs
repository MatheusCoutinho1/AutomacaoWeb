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
            // Localiza o elemento pai comum
            var parentElement = driver.FindElement(By.CssSelector(".b1hJbf"));

            // Localiza o elemento filho que exibe o valor do dólar dentro do elemento pai
            var exchangeRateElement = parentElement.FindElement(By.CssSelector(".DFlfde.SwHCTb"));

            // Obtém o valor do dólar em relação ao real e a data/hora da cotação
            var exchangeRateText = exchangeRateElement.Text;
            var dateTime = DateTime.Now;

            // Cria uma string com o valor do dólar e a data/hora da cotação
            var outputString = $"Valor do dólar: {exchangeRateText} - Data/hora da cotação: {dateTime}";

            // Escreve a string no bloco de notas
            System.IO.File.WriteAllText(@"C:\Users\Matheus\Documents\ValorDolar.txt", outputString);

            Console.WriteLine("Valor do dólar escrito com sucesso no bloco de notas.");
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("Elemento não encontrado.");
        }

        // Fecha o driver do Chrome
        driver.Quit();
    }
}
