using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketBis
{
    internal class Pesanan
    {
        List<User> ListPenumpang = new List<User>();

        private string[] Jalur =
        {
            "Jakarta", "Semarang", "Yogyakarta", "Surabaya", "Tangerang"
        };
        private int PilihanKelas;
        public string Asal { get; set; } = string.Empty;
        public string Tujuan { get; set; } = string.Empty;
        public string Tanggal { get; set; } = string.Empty;
        public string Kelas { get; set; }
        public int Kursi { get; set; }

        public void pesan(User sendiri)
        {
            User penumpang;
            List<string> ListTujuan = new List<string>();

            int asal;
            char untukSendiri;
            bool flag = false;

            Console.Write("Jumlah Kursi\t: ");
            Kursi = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("=============== Pesan Tiket ===============");
            Console.WriteLine("Daftar Kelas\t: ");
            Console.WriteLine("1. Bisnis");
            Console.WriteLine("2. Eksekutif");
            Console.WriteLine("3. First Class");
            Console.WriteLine("-------------------------------------------");
            Console.Write("Pilih Kelas [1/2/3]\t: ");
            PilihanKelas = Convert.ToInt32(Console.ReadLine());
            Kelas = PilihanKelas == 1 ? "Bisnis" : PilihanKelas == 2 ? "Eksekutif" : "First Class";

            Console.Clear();
            Console.WriteLine("=============== Pesan Tiket ===============");
            for (int i = 0; i < Kursi; i++)
            {
                Console.WriteLine($"Data Penumpang ke-{i + 1}:");

                if (i == 0 && !sendiri.isEmpty())
                {
                    Console.Write("Untuk anda sendiri? [y/n] : ");
                    untukSendiri = Convert.ToChar(Console.ReadLine());

                    if (untukSendiri == 'Y' || untukSendiri == 'y')
                    {
                        ListPenumpang.Add(sendiri);

                        if (!sendiri.isVaksin(sendiri.NoVaksin))
                            flag = true;
                    }
                    else
                    {
                        penumpang = new User();

                        penumpang.setUser();

                        ListPenumpang.Add(penumpang);

                        if (!penumpang.isVaksin(penumpang.NoVaksin))
                            flag = true;
                    }
                }
                else
                {
                    penumpang = new User();

                    penumpang.setUser();

                    ListPenumpang.Add(penumpang);

                    if (!penumpang.isVaksin(penumpang.NoVaksin))
                        flag = true;
                }

                Console.WriteLine();
            }

            if (flag)
            {
                Console.Clear();
                Console.WriteLine("=============== Pesan Tiket ===============");
                Console.WriteLine("Maaf, Penumpang tanpa sertifikat vaksin tidak dapat melakukan pemesanan tiket.\nTekan apa saja untuk kembali!");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Masukkan Tanggal Keberangkatan Anda!");
                Console.Write("Tanggal : ");
                Tanggal = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("=============== Pesan Tiket ===============");
                Console.WriteLine("Daftar Terminal : ");

                for (int i = 0; i < Jalur.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Jalur[i]}");
                }

                Console.WriteLine("-------------------------------------------");
                Console.Write("Pilihan : ");
                asal = Convert.ToInt32(Console.ReadLine()) - 1;
                Asal = Jalur[asal];

                for (int i = 0; i < Jalur.Length; i++)
                {
                    if (i != asal)
                        ListTujuan.Add(Jalur[i]);
                }

                Console.Clear();
                Console.WriteLine("=============== Pesan Tiket ===============");
                Console.WriteLine("Daftar Tujuan : ");

                for (int i = 0; i < ListTujuan.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {ListTujuan[i]}");
                }

                Console.WriteLine("-------------------------------------------");
                Console.Write("Pilihan : ");
                Tujuan = ListTujuan[Convert.ToInt32(Console.ReadLine()) - 1];

                Console.Clear();
                Console.WriteLine("Terima kasih sudah mengisi data.\nTekan apa saja untuk kembali!");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void dataPenumpang()
        {
            for (int i = 0; i < ListPenumpang.Count; i++)
            {
                Console.WriteLine($"- Penumpang {i + 1} :");
                Console.WriteLine($"\tNama\t\t: {ListPenumpang[i].Nama}");
                Console.WriteLine($"\tNIK\t\t: {ListPenumpang[i].Nik}");
                Console.WriteLine($"\tTelepon\t\t: {ListPenumpang[i].Telepon}");
                Console.WriteLine($"\tAlamat\t\t: {ListPenumpang[i].Alamat}");
                Console.WriteLine($"\tNo. Vaksin\t: {ListPenumpang[i].NoVaksin}");
            }
        }
    }
}
