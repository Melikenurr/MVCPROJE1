using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager
    {
        Repository<Contact> repocontact = new Repository<Contact>();
        public List<Contact> getAll()
        {  //repoblogtan gelen verileri alma
            return repocontact.List();
        }
        public int BLContactAdd(Contact p)
        {
            if (p.Mail == "" || p.Message == "" || p.Name == "" || p.Subject == "" || p.Surname == "" || p.Mail.Length <= 10 || p.Message.Length <= 3)
            {
                return -1;
            }
            return repocontact.Insert(p);
        }

        public Contact GetContactDetails(int id)
        {
            //id ye göre bilgilerin getirilmesi
            return repocontact.Find(x => x.ContactID == id);
        }

















        //public int BLMessageAdd(Contact p)
        //{
        //    if (p.Mail == "" || p.Message == "" || p.Name == "" || p.Subject == "" || p.Surname == "" || p.Mail.Length <= 10 || p.Subject.Length <= 3)
        //    {
        //        return -1;
        //    }
        //    return repocontact.Insert(p);
        //}






        //public Contact FindMesaage(int id)
        //{
        //    return repocontact.Find(x => x.ContactID == id);

        //}
        //public Contact GetContactByID(int id)

        //{
        //    //ıd ye göre bilgi getirme

        //    return repocontact.Find(x => x.ContactID == id);

        //}

        ////public List<Contact> GetContactByID(int id)
        ////{
        ////    return repocontact.List().Where(x => x.ContactID == id).ToList();
        ////}
        //public Contact GetContactDetails(int id)
        //{
        //    return repocontact.Find(x => x.ContactID == id);
        //}



    }
}
