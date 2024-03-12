using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDTH
{
    public class PackDetails
    {
        public string PackID{get;set;}
        public string PackName{get;set;}
        public int Price{get;set;}
        public int Validity{get;set;}
        public int NoOfChannels{get;set;}


        public PackDetails(string packid, string packname, int price, int validity, int noofchannels)
        {
            PackID=packid;
            PackName=packname;
            Price=price;
            Validity=validity;
            NoOfChannels=noofchannels;
        }
    }
}