using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_010
{
    class Node
    {
        public int Nomor;
        public string Judul;
        public string Nama;
        public int Tahun;
        public Node next;
    }
    class list
    {
        Node START;
        public list()
        {
            START = null;
        }
        public void insert()
        {
            int no, th;
            string nm, jd;
            Console.Write("Masukkan Nomor Buku : ");
            no = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Nama Penulis : ");
            nm = Console.ReadLine();
            Console.Write("Masukkan Tahun Terbit : ");
            th = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Judul Buku : ");
            jd = Console.ReadLine();

            Node newnode = new Node();

            newnode.Nomor = no;
            newnode.Nama = nm;
            newnode.Tahun = th;
            newnode.Judul = jd;

            if (START == null || no <= START.Nomor)
            {
                if ((START != null) && (no == START.Nomor))
                {
                    Console.WriteLine("Duplikat nomor tidak diperbolehkan");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }
            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (no >= current.Nomor))
            {
                if (no == current.Nomor)
                {
                    Console.WriteLine("\nDuplikat nomor tidak diperbolehkan");
                    return;
                }
                previous = current;
                current = current.next;
            }
            newnode.next = current;
            previous.next = current;
        }
        public bool search(int th, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;


            while ((current != null) && (th != current.Tahun))
            {
                previous = current;
                current = current.next;
            }

            if (current == null)
                return (false);
            else
                return (true);

        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList kosong");
            else
            {
                Console.WriteLine("\nList data siswa : ");
                Console.Write("Nomor" + "   " + "Nama" + "    " + "Tahun Terbit Buku" + "   " + "Judul Buku" + "\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                {
                    Console.Write(currentNode.Nomor + "    " + currentNode.Nama + "    " + currentNode.Tahun + "         " + currentNode.Judul + "\n");
                }
                Console.WriteLine();
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        class Program
        {
            static void Main(string[] args)
            {
               list obj = new list();
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nMenu");
                        Console.WriteLine("1. Menambahkan data ke dalam list");
                        Console.WriteLine("2. Melihat semua data di dalam list");
                        Console.WriteLine("3. Mencari data di dalam list");
                        Console.WriteLine("4. Exit");
                        Console.Write("\nEnter your choice (1-4) : ");
                        char ch = Convert.ToChar(Console.ReadLine());
                        switch (ch)
                        {
                            case '1':
                                {
                                    obj.insert();
                                }
                                break;
                            case '2':
                                {
                                    obj.traverse();
                                }
                                break;
                            case '3':
                                {
                                    if (obj.listEmpty() == true)
                                    {
                                        Console.WriteLine("\nList is kosong");
                                        break;
                                    }
                                    Node previous, current;
                                    previous = current = null;
                                    Console.Write("\nmasukan tahun terbit buku yang ingin dicari : ");
                                    int num = Convert.ToInt32(Console.ReadLine());
                                    if (obj.search(num, ref previous, ref current) == false)
                                        Console.WriteLine("\nData tidak ditemukan");
                                    else
                                    {
                                        Node TH;
                                        for (TH = current; TH != null; TH = TH.next)
                                        {
                                            Console.WriteLine("\nData ditemukan");
                                            Console.WriteLine("\nNomor Buku: " + current.Nomor);
                                            Console.WriteLine("\nTahun Terbit : " + current.Tahun);
                                            Console.WriteLine("\nNama Pengarang: " + current.Nama);
                                            Console.WriteLine("\nJudul Buku: " + current.Judul);
                                        }
                                    }
                                }
                                break;
                            case '4':
                                return;
                            default:
                                {
                                    Console.WriteLine("\nInvalid Option");
                                    break;
                                }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nCheck for for the value entered");
                    }
                }
            }
        }
    }
}

//2. single link list 
//3. pop and push
//4. REAR and FRONT
//5. a. 5
//   b. (Inorder) pertama menampilkan data subtree di posisi kiri kemudian menampilkan akarnya dan terakhir menampilkan data subtree di sebelah kanan
//   maka urutan pada soal adalah (1,5,8,10,12,15,20,22,25,28,30,36,38,40,45,48,50)*/


