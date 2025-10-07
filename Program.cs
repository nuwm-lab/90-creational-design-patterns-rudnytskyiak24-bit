using System;

namespace DocumentFactoryExample
{
    // Продукт — інтерфейс документа
    public interface IDocument
    {
        void Open();
        void Save(string path);
    }

    // Конкретний продукт Word
    public class WordDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("WordDocument: відкрито документ Word.");
        }

        public void Save(string path)
        {
            Console.WriteLine($"WordDocument: збережено документ Word за шляхом: {path}");
        }
    }

    // Конкретний продукт PDF
    public class PdfDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("PdfDocument: відкрито документ PDF.");
        }

        public void Save(string path)
        {
            Console.WriteLine($"PdfDocument: збережено документ PDF за шляхом: {path}");
        }
    }

    // Абстрактна фабрика для створення документів
    public abstract class DocumentFactory
    {
        public abstract IDocument CreateWordDocument();
        public abstract IDocument CreatePdfDocument();
    }

    // Конкретна фабрика, яка створює Word та PDF документи
    public class StandardDocumentFactory : DocumentFactory
    {
        public override IDocument CreateWordDocument()
        {
            return new WordDocument();
        }

        public override IDocument CreatePdfDocument()
        {
            return new PdfDocument();
        }
    }

    // Інша фабрика, якщо треба іншим способом
    // Наприклад, фабрика, яка працює з шаблонами, або документами іншого формату
    public class TemplateDocumentFactory : DocumentFactory
    {
        public override IDocument CreateWordDocument()
        {
            // Можна створити WordDocument з шаблоном
            return new WordDocument();
        }

        public override IDocument CreatePdfDocument()
        {
            // Можна створити PdfDocument з якимось іншим механізмом
            return new PdfDocument();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Вибір фабрики (можна читати з конфігурації або ввести)
            DocumentFactory factory = new StandardDocumentFactory();

            // Створюємо Word-документ
            IDocument wordDoc = factory.CreateWordDocument();
            wordDoc.Open();
            wordDoc.Save("report.docx");

            Console.WriteLine();

            // Створюємо PDF-документ
            IDocument pdfDoc = factory.CreatePdfDocument();
            pdfDoc.Open();
            pdfDoc.Save("report.pdf");

            Console.WriteLine("\nГотово.");
        }
    }
}
