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
            //iniciar banco
            IMGContext Db = new IMGContext();
            Db.Iniciar();

            Console.WriteLine("Lembre de alterar o diretório do arquivo \ne string de conexão do banco");
           //diretórios para salvar a imagem
            string DirArquivo1 = @"C:\Users\João Pedro\Desktop\";
            string DirArquivo2 = @"C:\Users\João Pedro\Downloads\";
            string DirCompleto = DirArquivo1 + "Coelho.png";
            
            //fazendo o download da imagem pela internet
            using (WebClient cliente = new WebClient())
            {
                cliente.DownloadFile("https://www.petz.com.br/blog/wp-content/uploads/2019/04/como-cuidar-de-um-coelho-filhote.jpg", DirCompleto);
            }
            Console.WriteLine("baixou");

            //salvando no banco de dados
            Image img = Image.FromFile(DirCompleto);
            String nome = "Coelho";
            var i = new ObjImagem
            {
                Imagem = Conversor.ImagemParaByte(img),
                Nome = nome
            };
            Db.Imagens.Add(i);
            Db.SaveChanges();
            Console.WriteLine("Salvo no banco");

            //recuperando imagem do banco de dados
            var imagens = Db.Imagens.ToList<ObjImagem>();
            foreach(var im in imagens)
            {
                Image ImagemDoBanco = Conversor.ByteParaImagem(im.Imagem);
                ImagemDoBanco.Save(DirArquivo2 + im.Nome + ".png");
                Console.WriteLine("Salvo em: " + DirArquivo2 + im.Nome + ".png");

            }

            Console.ReadLine();
        }
    }
}
