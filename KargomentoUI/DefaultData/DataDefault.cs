using KargomentoEL.ViewModels;
using ClosedXML.Excel;
using KargomentoBL.ImplementationsOfManagers;
using KargomentoBL.InterfacesOfManagers;
using KargomentoDL.ImplementationsOfRepo;
using KargomentoEL.IdentityModels;
using KargomentoEL.Models;
using KargomentoEL.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace KargomentoUI.DefaultData
{
    public class DataDefault
    {
        public void CheckAndCreateRoles(RoleManager<AppRole> roleManager)
        {
            try
            {
                //admin // customer  // misafir vb...
                string[] roles = new string[] { "Admin", "BranchManager", "Employee" };

                // rolleri tek tek dönüp sisteme olup olmadığına bakacağız. Yoksa ekleyeceğiz.
                foreach (var item in roles)
                {
                    // ROLDEN YOK MU? 
                    if (!roleManager.RoleExistsAsync(item.ToLower()).Result)
                    {
                        //rolden yokmuş ekleyelim
                        AppRole role = new AppRole()
                        {
                            Name = item
                        };

                        var result = roleManager.CreateAsync(role).Result;
                    }
                }



            }
            catch (Exception ex)
            {
                // ex loglanabilşr
                // yazılımcıya acil başlıklı email gönderilebilir
            }
        }

        public void CreateAllCities(ICityManager cityManager)
        {
            try
            {
                //1) Veritbaanındaki illeri listeye ekleyelim
                //2)Exceli açıp satır satır okuyup 
                //2,5)Olmayan ili veri tabanına ekleyelim
                var cityList = cityManager.GetAll(x => !x.IsRemoved).Data;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Excels");
                string fileName = Path.GetFileName("Cities.xlsx");
                string filePath = Path.Combine(path, fileName);

                using (var excelBook = new XLWorkbook(filePath))
                {
                    var rows = excelBook.Worksheet(1).RowsUsed(); //82
                    foreach (var item in rows)
                    {
                        if (item.RowNumber() > 1) //1.Satırda başlık var
                        {
                            //satırdaki hücrelere ulaşabiliriz.
                            string? cityName = item.Cell(1).Value.ToString()?.Trim();
                            string? plateCode = item.Cell(2).Value.ToString()?.Trim();
                            //bu cityName'den listede var mı yok mu
                            if (cityList.Count(x => x.Name.ToLower() == cityName?.ToLower()) == 0)
                            {
                                CityVM c = new CityVM()
                                {
                                    CreatedDate = DateTime.Now,
                                    Name = cityName,
                                    PlateCode = plateCode
                                };
                                cityManager.Add(c);
                            }
                        } //if bitti
                    } //foreach bitti
                }
            }
            catch (Exception ex)
            {
                //loglanacak
            }
        }

        public void CreateAllDistricts(IDistrictManager districtManager)
        {
            try
            {
                var districts = districtManager.GetAll(x => !x.IsRemoved).Data;

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Excels");
                string filePath = Path.Combine(path, "Districts.xlsx");

                using (var excelBook = new XLWorkbook(filePath)) //C:Users/.../wwwroot/Excels/Cities.xlsx
                {
                    var rows = excelBook.Worksheet(1).RowsUsed();

                    foreach (var item in rows)
                    {
                        if (item.RowNumber() > 1) // 1. satırda başlık var
                        {

                            string districtName = item.Cell(1).Value.ToString().Trim();
                            // Beşiktaş

                            int cityId = Convert.ToInt32(item.Cell(2).Value.ToString().Trim()); //34


                            if (districts.Count(x => x.Name.ToLower() == districtName.ToLower()
                                                     && x.CityId == cityId) == 0)
                            {
                                DistrictVM d = new DistrictVM()
                                {
                                    CreatedDate = DateTime.Now,
                                    Name = districtName,
                                    CityId = cityId
                                };

                                districtManager.Add(d);
                            }
                        } // if bitt
                    } // foreach bitti
                } // using bitti
            }
            catch (Exception)
            {

            }
        }

        public void CreateAllCargoStatus(ICargoStatusManager cargoStatusManager)
        {
            try
            {

                var cargoStatusList = cargoStatusManager.GetAll(x => !x.IsRemoved).Data;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Excels");
                string fileName = Path.GetFileName("CargoStatus.xlsx");
                string filePath = Path.Combine(path, fileName);

                using (var excelBook = new XLWorkbook(filePath))
                {
                    var rows = excelBook.Worksheet(1).RowsUsed();
                    foreach (var item in rows)
                    {
                        if (item.RowNumber() > 1)
                        {

                            string? statusName = item.Cell(1).Value.ToString()?.Trim();
                            if (cargoStatusList.Count(x => x.StatusName.ToLower() == statusName.ToLower())==0)
                            {
                                CargoStatusVM  s = new CargoStatusVM()
                                {
                                    CreatedDate = DateTime.Now,
                                    StatusName=statusName
                                   
                                };

                                cargoStatusManager.Add(s);
                            }
                        } // if bitt

                    } //foreach bitti
                    
                }
            }
            catch (Exception ex)
            {
            }


        }


        public void CreateAFewEmployee(UserManager<AppUser> userManager,    RoleManager<AppRole> roleManager, IEmployeeBranchManager employeeBranchManager)
        {
            try
            {
                List<AppUser> userList= new List<AppUser>();
                
                AppUser user = new AppUser
                {
                    Name="Betül",
                    Surname="Akşan",
                    TcNo="31471487892",
                    PhoneNumber="5396796650",
                    Email="betulaksan1992@gmail.com",
                    EmailConfirmed=false,
                    UserName= "31471487892"
                };
                
                userList.Add(user);
                

                foreach (var item in userList)
                {
                    if (userManager.FindByEmailAsync(item.Email).Result==null &&
                        userManager.FindByNameAsync(item.UserName).Result==null)
                        
                    {
                        var userResult = userManager.CreateAsync(item, "k1234").Result;

                        var roleResult =
                            userManager.AddToRoleAsync(item, "Employee").Result;
                        EmployeeBranchVM b = new EmployeeBranchVM
                        {
                            BranchId = 1,
                            CreatedDate = DateTime.Now,
                            IsRemoved = false,
                            EmployeeId = item.Id,
                        };
                        employeeBranchManager.Add(b);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
