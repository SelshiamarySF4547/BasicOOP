using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDTH
{
    public class RechargeHistory
    {
        public static int s_rechargeID=100;
        public string RechargeID{get;set;}

        public string UserID{get;set;}
        public string PackID{get;set;}
        public DateTime RechargeDate{get;set;}
        public double RechargeAmount{get;set;}
        public DateTime ValidTill{get; set;}
        public int NumberOfChannels{get;set;}

        public RechargeHistory(string userid, string packid, DateTime rechargedate, double rechargeamount, DateTime validtill, int noofchannels)
        {
            RechargeID="RP"+ ++s_rechargeID;
            UserID=userid;
            PackID=packid;
            RechargeDate=rechargedate;
            RechargeAmount=rechargeamount;
            ValidTill=validtill;
            NumberOfChannels=noofchannels;
        }
    }
}