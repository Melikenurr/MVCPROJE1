﻿using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
  public  class SubscribeMailManager
    {

        Repository<SubscribeMail> reposubscribemail = new Repository<SubscribeMail>();
        public int BLAdd(SubscribeMail p)
        {
            //@gmail.com
            if(p.Mail.Length<=10 || p.Mail.Length >= 50)
            {
                //11 ve 49 arasında değilse 
                return -1;
            }
            return reposubscribemail.Insert(p);

        }
    }
}
