using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADInternalNew.Core
{
    public static class Enums
    {
        public enum EmployeShiftStatus
        {
            Active=0,Deactive=-1,Advance=1
        }
        public enum OrderStatus
        {
            NewOrder = 1, Inprogress = 2, Waiting = 3, RequestForInformation = 4, Completed = 5, Sent = 6, Approved = 7, Revision = 8, QCRevision = 9,CancelOrder=10
        }
        public enum OrderActionStatus
        {
            LockFile=11,UpdateOrder=12,QuoteRevised=13,PriorityChange=14,FileUpload=15,BudgetProded=16,QuoteSent=17
        }
        public enum Roles
        {
            Admin=1,Client=2,CS=3,CSManager=4,Artist=5,ArtistManager=6,QC=7,QCManager=8,Company=9
        }
        public enum UserStatus
        {
            NewUser=1,Activated=2,Deactivated=3
        }
        public enum UserStatusAction
        {
            NewUser = 1, Activated = 2, Deactivated = 3,EditedProfile=4
        }
        public enum DailyLogStatus
        {
            ShiftStart=1,ShiftEnd=2,LongBreakStart=3,LongBreakEnd=4,ShortBreakStart=5,ShortBreakEnd=6,BioBreakStart=7,BioBreakEnd=8,LogOff=9,LogBack=10
        }
    }
}
