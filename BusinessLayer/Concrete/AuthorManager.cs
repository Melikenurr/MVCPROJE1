using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorManager
    {

        Repository<Author> repoauthor = new Repository<Author>();
        public List<Author> getAll()
        {  //repoblogtan gelen verileri alma
            return repoauthor.List();
        }


        public int DeleteAuthorBL(int p)
        {
            Author author= repoauthor.Find(x => x.AuthorID == p);
            return repoauthor.Delete(author);
        }

        public int AddAuthorBL(Author p)
        {
            if(p.AuthorName==""|p.AuthorShort==""|p.AuthorTitle=="")
            {
                return -1;
            }
            return repoauthor.Insert(p);
        }
        //yazarı id değerine göre edit sayfasına taşıma
        public Author FindAuthor(int id)
        {
            return repoauthor.Find(x => x.AuthorID == id);
        }
        public int EditAuthor(Author p)
        {
            
            Author author = repoauthor.Find(x => x.AuthorID == p.AuthorID);
            author.AuthorID = p.AuthorID;
            author.AuthorName = p.AuthorName;
            author.AuthorShort = p.AuthorShort;
            author.AuthorImage = p.AuthorImage;
            author.AuthorAbout = p.AuthorAbout;
            author.AuthorTitle = p.AuthorTitle;
            author.Mail = p.Mail;
            author.Password = p.Password;

            return repoauthor.Update(author);
        }

     

    }
}