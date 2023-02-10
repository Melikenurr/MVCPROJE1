using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class MessageManager
    {
        Repository<Message> repomessage = new Repository<Message>();

        public List<Message> getAll()
        {  //repoblogtan gelen verileri alma
            return repomessage.List();
        }
        public int BLMessageAdd(Message p)
        {
            if (p.ReceiverMail == "" || p.Subject == "" || p.MessageAll == "" || p.Subject == "" || p.File == "" || p.ReceiverMail.Length <= 10 || p.Subject.Length <= 3)
            {
                return -1;
            }
            return repomessage.Insert(p);
        }

      
    }
}
