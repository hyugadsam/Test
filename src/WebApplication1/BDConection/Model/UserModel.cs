using BDConection.Dto.Common;
using BDConection.Dto.Response;
using BDConection.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace BDConection.Model
{
    public class UserModel
    {
        public UserModel()
        {
        }

        public isValidResponse isValid(string UserLogin, string Password)
        {
            try
            {
                using (var context = new TempBDEntities())
                {
                    var result = context.st_isUserValid1(UserLogin).ToList();
                    if (result?.Count == 0)
                    {
                        return new isValidResponse
                        {
                            isSaved = false,
                            Message = "Usuario no encontrado"
                        };
                    }

                    var user = result.First();
                    if (user.Password.Equals(Hash.HashPasword(Password)))
                    {
                        return new isValidResponse
                        {
                            isSaved = true,
                            Message = "Success",
                            UserInfo = new User
                            {
                                BreakFast = user.BreakFast,
                                FirstLastName = user.FirstLastName,
                                InsertDate = user.InsertDate,
                                isActive = user.isActive,
                                Name = user.Name,
                                Roleid = user.Roleid,
                                Salary = user.Salary,
                                Savings = user.Savings,
                                SecondLastName = user.SecondLastName,
                                Userid = user.Userid,
                                UserLogin = user.UserLogin
                            }
                        };
                    }
                    else
                    {
                        return new isValidResponse
                        {
                            isSaved = false,
                            Message = "Contraseña invalida"
                        };
                    }

                }
            }
            catch (Exception ex)
            {
                return new isValidResponse
                {
                    isSaved = false,
                    Message = ex.Message
                };
            }
        }

        public GetUsersResponse GetUsers()
        {
            try
            {
                using (var context = new TempBDEntities())
                {
                    var result = context.st_GetUsers1().ToList();
                    if (result?.Count == 0)
                    {
                        return new GetUsersResponse
                        {
                            isSaved = false,
                            Message = "0 Users or Error"
                        };
                    }
                    List<User> users = result.Select(u => new User
                    {
                        BreakFast = u.BreakFast,
                        FirstLastName = u.FirstLastName,
                        InsertDate = u.InsertDate,
                        isActive = u.isActive,
                        Name = u.Name,
                        Roleid = u.Roleid,
                        Salary = u.Salary,
                        Savings = u.Savings,
                        SecondLastName = u.SecondLastName,
                        Userid = u.Userid,
                        UserLogin = u.UserLogin,
                        Password = u.Password
                    }).ToList();

                    return new GetUsersResponse
                    {
                        isSaved = true,
                        Message = "Success",
                        Users = users
                    };

                }
            }
            catch (Exception ex)
            {
                return new GetUsersResponse
                {
                    isSaved = false,
                    Message = ex.Message
                };
            }
        }

        public BasicResponse SaveUser(User user)
        {
            try
            {
                using (var context = new TempBDEntities())
                {
                    if (user.Userid > 0)
                    {
                        var u = context.st_isUserValid1(user.UserLogin).ToList();
                        if (u?.Count > 0)
                        {
                            if (u.First().Password != user.Password)
                            {
                                user.Password = Hash.HashPasword(user.Password);
                            }
                        }
                        else
                        {
                            return new BasicResponse
                            {
                                isSaved = false,
                                Message = "User not Found for update"
                            };
                        }
                    }
                    else
                    {
                        user.Password = Hash.HashPasword(user.Password);
                    }

                    System.Data.Entity.Core.Objects.ObjectParameter HasError = new System.Data.Entity.Core.Objects.ObjectParameter("HasError", false);
                    context.St_SaveUser1(user.Userid, user.Name, user.FirstLastName, user.SecondLastName, DateTime.Now, user.Salary, user.BreakFast, user.Savings, user.isActive, user.Roleid,
                        user.Password, user.UserLogin, HasError);


                    if (Convert.ToBoolean(HasError.Value))
                    {
                        return new BasicResponse
                        {
                            isSaved = false,
                            Message = "Insert error"
                        };
                    }
                    
                    return new BasicResponse
                    {
                        isSaved = true,
                        Message = user.Userid > 0 ? "Update Success" : "Insert Success",
                    };

                }
            }
            catch (Exception ex)
            {
                return new BasicResponse
                {
                    isSaved = false,
                    Message = ex.Message
                };
            }
        }


    }
}
