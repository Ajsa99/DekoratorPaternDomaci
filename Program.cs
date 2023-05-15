using System;

namespace PaternDekoratorDomaci
{
    public abstract class ZakaziTermin
    {
        public abstract void Opis();
    }

    public class DatumTermina : ZakaziTermin
    {
        private DateTime _datumTermina;

        public DatumTermina(DateTime datumTermina)
        {
            _datumTermina = datumTermina;
        }

        public override void Opis()
        {
            Console.Write("Datum termina: " + _datumTermina.ToString("dd.MM.yyyy. "));
        }
    }

    public abstract class Dekorator : ZakaziTermin
    {
        protected ZakaziTermin _zakaziTermin;

        public Dekorator(ZakaziTermin zakaziTermin)
        {
            _zakaziTermin = zakaziTermin;
        }

        public override void Opis()
        {
            _zakaziTermin.Opis();
        }
    }

    public class Korisnik : Dekorator
    {
        private string _ime;
        private string _prezime;

        public Korisnik(ZakaziTermin zakaziTermin, string ime, string prezime) : base(zakaziTermin)
        {
            _ime = ime;
            _prezime = prezime;
        }

        public override void Opis()
        {
            _zakaziTermin.Opis();
            Console.Write("Korisnik koji se poziva na zahtev: " + _ime + " " + _prezime + ". ");
        }
    }

    public class Sluzbenik : Dekorator
    {
        private string _ime;
        private string _prezime;

        public Sluzbenik(ZakaziTermin zakaziTermin, string ime, string prezime) : base(zakaziTermin)
        {
            _ime = ime;
            _prezime = prezime;
        }

        public override void Opis()
        {
            _zakaziTermin.Opis();
            Console.Write("Sluzbenik koji radi u tom terminu: " + _ime + " " + _prezime + ".");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ZakaziTermin zakaziTermin = new DatumTermina(new DateTime(2023, 5, 15));
            zakaziTermin.Opis();
            Console.WriteLine();


            zakaziTermin = new Korisnik(zakaziTermin, "Ajsa", "Alibasic");
            zakaziTermin.Opis();
            Console.WriteLine();


            zakaziTermin = new Sluzbenik(zakaziTermin, "Sejla", "Dolicanin");
            zakaziTermin.Opis();
        }
    }
}
