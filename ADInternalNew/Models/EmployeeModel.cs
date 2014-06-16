using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADInternalNew.DAL;
namespace ADInternalNew.Models
{
    public class EmployeeModel
    {
        AdmisInternalDataContext context = new AdmisInternalDataContext();
        public int shiftStart(int employeeid)
        {
            try
            {
                DateTime daystart,dayend;

                var objUserToShiftMapping = (from i in context.User_To_Shift_Mappings where i.User_Id == employeeid && i.Current_Status == Convert.ToInt32(Core.Enums.EmployeShiftStatus.Active) select i).FirstOrDefault();
                var shift = (from i in context.Shifts where i.Shift_Id == objUserToShiftMapping.Shift_Start_Time || i.Shift_Id == objUserToShiftMapping.Shift_End_Time select i).ToList();
                if(shift.Where(x=>x.Shift_Id==objUserToShiftMapping.Shift_Start_Time).Single().Shift_Time_Hr<shift.Where(x=>x.Shift_Id==objUserToShiftMapping.Shift_End_Time).Single().Shift_Time_Hr)
                {
                    daystart=new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,00,00,00);
                    dayend=new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second);

                    var login=(from i in context.User_Daily_ToTimeStamp_Mappings
                               join j in context.Time_Stamps on i.Time_Stamp_Id equals j.Time_Stamp_Id
                                
                               where j.Time_Stamp_Value >daystart && j.Time_Stamp_Value<dayend
                               select i
                                   ).FirstOrDefault();

                    if(login!=null)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    
                    daystart=new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,00,00,00);
                    dayend=new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second);

                    var login=(from i in context.User_Daily_ToTimeStamp_Mappings
                               join j in context.Time_Stamps on i.Time_Stamp_Id equals j.Time_Stamp_Id
                                
                               where j.Time_Stamp_Value >daystart && j.Time_Stamp_Value<dayend
                               select i
                                   ).FirstOrDefault();

                    if(login!=null)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }

                DateTime starttime=new DateTime(

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}