using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketBis
{
    internal class User
    {
        public string Nama { get; set; } = string.Empty;
        public string Nik { get; set; } = string.Empty;
        public string Telepon { get; set; } = string.Empty;
        public string NoVaksin { get; set; } = string.Empty;
        public string Alamat { get; set; } = string.Empty;

        public void setUser()
        {
            char vaksin;

            Console.Write("Nama\t: ");
            Nama = Console.ReadLine();

            Console.Write("NIK\t: ");
            Nik = Console.ReadLine();

            Console.Write("Telepon\t: ");
            Telepon = Console.ReadLine();

            Console.Write("Alamat\t: ");
            Alamat = Console.ReadLine();

            Console.Write("\nApakah anda sudah vaksin? [y/n] : ");
            vaksin = Convert.ToChar(Console.ReadLine());

            if (vaksin == 'Y' || vaksin == 'y')
            {
                Console.Write("Nomor Vaksin : ");
                NoVaksin = Console.ReadLine();
            }
        }

        public void getUser()
        {
            string vaksin = isVaksin(NoVaksin) ? "Sudah Vaksin" : "Belum Vaksin";

            Console.WriteLine($"Nama\t\t: {Nama}");
            Console.WriteLine($"NIK\t\t: {Nik}");
            Console.WriteLine($"Telepon\t\t: {Telepon}");
            Console.WriteLine($"Alamat\t\t: {Alamat}");
            Console.WriteLine($"Vaksin\t\t: {vaksin}");
            if (isVaksin(NoVaksin))
                Console.WriteLine($"Nomor Vaksin\t: {NoVaksin}");
        }

        public bool isEmpty()
        {
            return (Nama == "" || Nama.Length == 0);
        }

        public bool isVaksin(string NoVaksin)
        {
            return (NoVaksin != "" || NoVaksin.Length != 0);
        }
    }
}
