using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADInternalNew.DAL;
using ADInternalNew.CORE.Data;
using System.Transactions;
namespace ADInternalNew.Models
{
    public class ClientModel
    {
        AdmisInternalDataContext context = new AdmisInternalDataContext();

        /// <summary>
        /// add user basic detail's of user
        /// </summary>
        /// <param name="firstName">first name of user</param>
        /// <param name="lastName">last name of user</param>
        /// <param name="phone"> Object of phone number master class</param>
        /// <param name="email">email address of user</param>
        /// <returns>user id </returns>
        public int signUp(string firstName, string lastName, Phone_Number_Master phone, string email)
        {
            try
            {

                if (!checkEmailExist(email))
                {
                    using (TransactionScope t = new TransactionScope())
                    {
                        AdmisInternalDataContext contextInner = new AdmisInternalDataContext();
                        User objuser = new User();
                        objuser.First_Name = firstName;
                        objuser.Last_Name = lastName;
                        objuser.Email_Address = email;
                        objuser.User_Status_Id=Convert.ToInt32(Core.Enums.UserStatus.NewUser);
                        contextInner.Users.InsertOnSubmit(objuser);
                        contextInner.SubmitChanges();

                        contextInner.Phone_Number_Masters.InsertOnSubmit(phone);
                        contextInner.SubmitChanges();

                        User_To_Phone_Mapping objUser_To_Phone_Mapping = new User_To_Phone_Mapping();
                        objUser_To_Phone_Mapping.Phone_Id = phone.Phone_Id;
                        objUser_To_Phone_Mapping.User_Id = objuser.User_Id;
                        contextInner.User_To_Phone_Mappings.InsertOnSubmit(objUser_To_Phone_Mapping);
                        contextInner.SubmitChanges();
                        t.Complete();

                        Time_Stamp objstamp = new Time_Stamp();
                        objstamp.Time_Stamp_Value = DateTime.Now;
                        context.Time_Stamps.InsertOnSubmit(objstamp);
                        context.SubmitChanges();

                        User_Status_Time_Stamp_Mapping objUser_Status_Time_Stamp_Mapping = new User_Status_Time_Stamp_Mapping();
                        objUser_Status_Time_Stamp_Mapping.Time_Stamp_Id = objstamp.Time_Stamp_Id;
                        objUser_Status_Time_Stamp_Mapping.User_Status_Id = Convert.ToInt32(Core.Enums.UserStatusAction.NewUser);
                        objUser_Status_Time_Stamp_Mapping.User_Id_By = objuser.User_Id;
                        objUser_Status_Time_Stamp_Mapping.User_Id_Of = objuser.User_Id;
                        context.User_Status_Time_Stamp_Mappings.InsertOnSubmit(objUser_Status_Time_Stamp_Mapping);
                        context.SubmitChanges();
                        return objuser.User_Id;
                    }
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public bool checkEmailExist(string email)
        {
            var user = (from i in context.Users where i.Email_Address == email select i).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<User> GetClients(string term)
        {
            //var subquery = (from role in context.Roles where role.Role_Name=="Client" select role.Role_Id).Single();
            var result = (from client in context.Users
                          join role in context.User_To_Role_Mappings on client.User_Id equals role.User_Id
                          where (client.First_Name.ToLower().Contains(term.ToLower()) || client.Last_Name.ToLower().Contains(term.ToLower())) && role.Role_Id == Convert.ToInt32(Enums.Roles.Client)
                          select client).ToList();
            return result.ToList<User>();
        }
    }
}