using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using testeBanco.DAO;
using testeBanco.Model;

namespace testeBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            IMGContext Db = new IMGContext();
            Db.Iniciar();

            Console.WriteLine("Lembre de alterar o diretório do arquivo");
            string DirArquivo = @"C:\Users\João Pedro\Desktop\";
            //using (WebClient cliente = new WebClient())
            //{
            //    cliente.DownloadFile("https://www.petz.com.br/blog/wp-content/uploads/2019/04/como-cuidar-de-um-coelho-filhote.jpg", DirArquivo);
            //}

            //Console.WriteLine("baixou");


            //Image img = Image.FromFile(DirArquivo);
            //String nome = "Coelho";

            //var i = new ObjImagem
            //{
            //    Imagem = Conversor.ImagemParaByte(img),
            //    Nome = nome,
            //    Id = 1
            //};
            //Db.Imagens.Add(i);
            //Db.SaveChanges();
            //Console.WriteLine("salvo");

            var imagens = Db.Imagens.ToList<ObjImagem>();
            foreach(var im in imagens)
            {
                Image img = Conversor.ByteParaImagem(im.Imagem);
                img.Save(DirArquivo);

            }

            Console.ReadLine();
        }
    }
}
