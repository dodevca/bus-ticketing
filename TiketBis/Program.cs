namespace TiketBis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            Pesanan tiket;

            List<Pesanan> ListPesanan = new List<Pesanan>();

            int menu;
            bool keluar = false;

            do
            {
                if (user.isEmpty())
                    Console.WriteLine("Lengkapi data anda! Agar proses pemesanan lebih cepat.\n");

                Console.WriteLine("========= Aplikasi Pemesanan Bis =========");
                Console.WriteLine("1. Pesan Tiket");
                Console.WriteLine("2. Tiket Dipesan");
                Console.WriteLine("3. Data Anda");
                Console.WriteLine("4. Keluar");
                Console.WriteLine("------------------------------------------");
                Console.Write("Pilihan : ");

                menu = Convert.ToInt32(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        tiket = new Pesanan();

                        Console.Clear();
                        Console.WriteLine("=============== Pesan Tiket ===============");

                        tiket.pesan(user);

                        ListPesanan.Add(tiket);

                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("=============== Pesan Tiket ===============");

                        for (int i = 0; i < ListPesanan.Count; i++)
                        {
                            Console.WriteLine($"Tiket {i + 1} :");
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine($"Kelas : {ListPesanan[i].Kelas}");
                            Console.WriteLine($"Perjalanan\t: {ListPesanan[i].Asal} - {ListPesanan[i].Tujuan}");
                            Console.WriteLine($"Tanggal\t\t: {ListPesanan[i].Tanggal}");
                            Console.WriteLine($"Penumpang\t:");

                            ListPesanan[i].dataPenumpang();

                            Console.WriteLine("-------------------------------------------\n");
                        }

                        Console.WriteLine("Tekan apa saja untuk kembali!");
                        Console.ReadKey();
                        Console.Clear();

                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("================ Data Anda ================");

                        if (user.isEmpty())
                        {
                            Console.WriteLine("Silahkan lengkapi data anda!");

                            user.setUser();

                            Console.Clear();
                            Console.WriteLine("Terima kasih sudah mengisi data.\nTekan apa saja untuk kembali!");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            user.getUser();

                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 4:
                        keluar = true;

                        break;
                    default:
                        Console.WriteLine("!! Menu tidak ditemukan. !!\n");

                        break;
                }
            } while (!keluar);
        }
    }
}