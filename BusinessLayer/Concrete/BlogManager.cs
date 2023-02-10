using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
 public  class BlogManager
    {
      
        Repository<Blog> repoblog = new Repository<Blog>();
      
        //blog listeleme
        public List<Blog> getAll()
        {  //repoblogtan gelen verileri alma
            return repoblog.List();
        }

        //BlogId ye göre listeleme
        public List<Blog>GetBlogByID(int id)
        {
            return repoblog.List(x => x.BlogID == id);
        }

        public List<Blog> GetBlogAuthorID(int id)
        {
            return repoblog.List(x => x.AuthorID == id);
        }

        public List<Blog> GetBlogByCategory(int id)
        {
            return repoblog.List(x => x.CategoryId == id);
        }
        public int BlogAddBL(Blog p)
        {
            if (p.BlogTitle == "" || p.BlogImage == "" || p.BlogTitle.Length <= 5 || p.BlogContent.Length <= 200)
            {
                return -1;
            }
            else { return repoblog.Insert(p); }
        }

        

        public int DeleteBlogBL(int p)
        {
            Blog blog = repoblog.Find(x => x.BlogID == p);//id buldurma
            //blog.BlogStatus = false;
            return repoblog.Delete(blog);
        }
        public Blog FindBlog(int id)
        {
            return repoblog.Find(x => x.BlogID == id);   
        }
    

        public int UpdateBlog(Blog p)
        {
            Blog blog = repoblog.Find(x => x.BlogID == p.BlogID);
            blog.BlogTitle = p.BlogTitle;
            blog.BlogContent = p.BlogContent;
            blog.BlogImage = p.BlogImage;
            blog.BlogDate = p.BlogDate;
            blog.CategoryId = p.CategoryId;
            blog.AuthorID = p.AuthorID;


            return repoblog.Update(blog);
        }
    
    
    
    }


}
