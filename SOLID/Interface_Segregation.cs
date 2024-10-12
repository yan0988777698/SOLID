using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Interface_Segregation
{
    public class Document
    {
    }
    
    public interface IBadMachine
    {
        void Print(Document document);
        void Scan(Document document);
        void Fax(Document document);
    }
    public class MultiFuntionPrinter : IBadMachine
    {
        public void Fax(Document document)
        {
            Console.WriteLine($"Fax {document}");
        }

        public void Print(Document document)
        {
            Console.WriteLine($"Print {document}");
        }

        public void Scan(Document document)
        {
            Console.WriteLine($"Scan {document}");
        }
    }
    //Interface 只專注於特定功能
    public interface IPrinter
    {
        void Print(Document document);
    }
    public interface IScanner
    {
        void Scan(Document document);
    }
    public interface IGoodMachine : IPrinter, IScanner { }

    public class BetterMultiFuntionPrinter : IGoodMachine
    {
        private IPrinter _printer;
        private IScanner _scanner;

        public BetterMultiFuntionPrinter(IPrinter printer, IScanner scanner)
        {
            this._printer = printer;
            this._scanner = scanner;
        }
        public void Print(Document document)
        {
            this._printer.Print(document);
        }

        public void Scan(Document document)
        {
            this._scanner.Scan(document);
        }
    }
}
