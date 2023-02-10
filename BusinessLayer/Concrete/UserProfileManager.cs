using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class UserProfileManager
    {
        Repository<Author> repouser = new Repository<Author>();
        Repository<Blog> repouserBlog = new Repository<Blog>();
        public List<Author> GetAuthorByMail(string p)
        {
            return repouser.List(x => x.Mail == p);
        }
        public List<Blog> GetBlogByAuthor(int p)
        {
            return repouserBlog.List(x => x.AuthorID == p);
        }
        public int EditAuthor(Author p)
        {

            Author author = repouser.Find(x => x.AuthorID == p.AuthorID);
            author.AuthorID = p.AuthorID;
            author.AuthorName = p.AuthorName;
            author.AuthorShort = p.AuthorShort;
            author.AuthorImage = p.AuthorImage;
            author.AuthorAbout = p.AuthorAbout;
            author.AuthorTitle = p.AuthorTitle;
            author.Mail = p.Mail;
            author.Password = p.Password;

            return repouser.Update(author);
        }

    }
}
